using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories;
using AcademyManager.Infra.Context;
using AcademyManager.Shared.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infra.Repositories
{
    public class ClassGroupRepository : IClassGroupRepository
    {
        private readonly AcademyManagerContext _context;
        private readonly DbSet<ClassGroup> _dbSet;

        public ClassGroupRepository(AcademyManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<ClassGroup>();
        }

        public IUnitOfWork ContextUnitOfWork => _context;

        public void Add(ClassGroup classGroup)
        {
            _dbSet.Add(classGroup);
        }

        public void Update(ClassGroup classGroup)
        {
            _dbSet.Update(classGroup);
        }

        public async Task<ClassGroup?> GetById(int id)
        {
            return await _dbSet
                .Include(cg => cg.Enrollments)
                .FirstOrDefaultAsync(cg => cg.Id == id);
        }

        public async Task<List<ClassGroup>> GetAll(int skip, int take)
        {
            return await _dbSet
                .Include(cg => cg.Enrollments)
                .OrderBy(cg => cg.Name.Value)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}
