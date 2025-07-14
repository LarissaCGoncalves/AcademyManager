using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories;
using AcademyManager.Infra.Context;
using AcademyManager.Shared.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infra.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AcademyManagerContext _context;
        private readonly DbSet<Student> _dbSet;

        public StudentRepository(AcademyManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<Student>();
        }

        public IUnitOfWork ContextUnitOfWork => _context;

        public void Add(Student student)
        {
            _dbSet.Add(student);
        }

        public void Update(Student student)
        {
            _dbSet.Update(student);
        }

        public async Task<Student?> GetById(int id)
        {
            return await _dbSet
                .Include(s => s.Enrollments)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> CheckIfExistsByEmail(string email)
        {
            return await _dbSet.AnyAsync(s => s.Email.Address.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<bool> CheckIfExistsByCpf(string cpf)
        {
            return await _dbSet.AnyAsync(s => s.Cpf.CpfNumber.Equals(cpf));
        }

        public async Task<List<Student>> GetAll(int skip, int take, string? search = null)
        {
            var query = _dbSet
                .Include(s => s.Enrollments)                     
                .ThenInclude(e => e.ClassGroup)
                .ThenInclude(cg => cg.Name)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(s => s.Name.Value.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            return await query
                .OrderBy(s => s.Name.Value)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}
