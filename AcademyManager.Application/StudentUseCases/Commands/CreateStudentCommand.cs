using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.StudentUseCases.Commands
{
    public class CreateStudentCommand : IRequest<ResultT<int?>>
    {
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
