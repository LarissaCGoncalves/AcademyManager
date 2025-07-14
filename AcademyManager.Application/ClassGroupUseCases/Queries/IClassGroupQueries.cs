using AcademyManager.Shared.Dtos;
using AcademyManager.Shared.Results;

namespace AcademyManager.Application.ClassGroupUseCases.Queries
{
    public interface IClassGroupQueries
    {
        Task<ResultT<IEnumerable<ClassGroupDto>>> GetAll(int skip, int take);
    }
}
