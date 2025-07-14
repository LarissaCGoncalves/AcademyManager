using AcademyManager.Domain.Repositories;
using AcademyManager.Shared.Dtos;
using AcademyManager.Shared.Results;

namespace AcademyManager.Application.StudentUseCases.Queries
{
    public class StudentQueries : IStudentQueries
    {
        private readonly IStudentRepository _repository;

        public StudentQueries(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultT<IEnumerable<StudentDto>>> GetAll(int page, int pageSize, string? search)
        {
            var classGroups = await _repository.GetAll(page, pageSize, search);

            var dto = classGroups.Select(c => new StudentDto
            {
                Id = c.Id,
                Name = c.Name.Value,
                BirthDate = c.BirthDate,
                Email = c.Email.Address,
                Cpf = c.Cpf.CpfNumber
            });

            return ResultT<IEnumerable<StudentDto>>.Success(dto);
        }
    }
}
