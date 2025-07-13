using AcademyManager.Domain.Entities;

namespace AcademyManager.Domain.Repositories
{
    public interface IClassGroupRepository
    {
        Task<ClassGroup> GetById(int id);
    }
}
