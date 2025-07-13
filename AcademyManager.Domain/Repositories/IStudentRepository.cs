using AcademyManager.Domain.Entities;

namespace AcademyManager.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetById(int id);
    }
}
