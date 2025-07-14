using AcademyManager.Domain.Entities;
using AcademyManager.Shared.UnitOfWork;
using System.Linq.Expressions;

namespace AcademyManager.Domain.Repositories
{
    public interface IStudentRepository : IContextUnitOfWork
    {
        void Add(Student student);
        void Update(Student student);
        Task<Student?> GetById(int id);
        Task<Student?> GetById(int id, Expression<Func<Student, object>> includeExpression);
        Task<List<Student>> GetAll(int page, int pageSize, string? search = null);
        Task<bool> CheckIfExistsByEmail(string email);
        Task<bool> CheckIfExistsByCpf(string cpf);
    }
}