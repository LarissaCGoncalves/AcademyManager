using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories;
using AcademyManager.Infra.Context;
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
        public async Task<ClassGroup> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
