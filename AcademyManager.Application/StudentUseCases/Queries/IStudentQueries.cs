using AcademyManager.Shared.Dtos;
using AcademyManager.Shared.Results;

namespace AcademyManager.Application.StudentUseCases.Queries
{
    public interface IStudentQueries
    {
        Task<ResultT<IEnumerable<StudentDto>>> GetAll(int skip, int take, string? search);
    }
}
