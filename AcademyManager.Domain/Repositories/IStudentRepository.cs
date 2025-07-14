using AcademyManager.Domain.Entities;
using AcademyManager.Shared.UnitOfWork;

namespace AcademyManager.Domain.Repositories
{
    public interface IStudentRepository : IContextUnitOfWork
    {
        void Add(Student student);
        void Update(Student student);
        Task<Student?> GetById(int id);
        Task<List<Student>> GetAll(int skip, int take, string? search = null);
        Task<bool> CheckIfExistsByEmail(string email);
        Task<bool> CheckIfExistsByCpf(string cpf);
    }
}