using AcademyManager.Domain.Entities;
using AcademyManager.Shared.UnitOfWork;

namespace AcademyManager.Domain.Repositories
{
    public interface IClassGroupRepository : IContextUnitOfWork
    {
        void Add(ClassGroup classGroup);
        void Update(ClassGroup classGroup);
        Task<ClassGroup?> GetById(int id);
        Task<List<ClassGroup>> GetAll(int skip, int take);
    }
}
