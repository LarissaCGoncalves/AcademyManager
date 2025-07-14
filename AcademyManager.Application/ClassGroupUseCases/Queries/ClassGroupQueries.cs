using AcademyManager.Domain.Repositories;
using AcademyManager.Shared.Dtos;
using AcademyManager.Shared.Results;

namespace AcademyManager.Application.ClassGroupUseCases.Queries
{
    public class ClassGroupQueries : IClassGroupQueries
    {
        private readonly IClassGroupRepository _repository;

        public ClassGroupQueries(IClassGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultT<IEnumerable<ClassGroupDto>>> GetAll(int page, int pageSize)
        {
            var classGroups = await _repository.GetAll(page, pageSize);

            var dto = classGroups.Select(c => new ClassGroupDto
            {
                Id = c.Id,
                Name = c.Name.Value,
                Description = c.Description,
                NumberOfStudents = c.Enrollments.Count
            });

            return ResultT<IEnumerable<ClassGroupDto>>.Success(dto);
        }
    }
}
