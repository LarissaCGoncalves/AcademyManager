using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.StudentUseCases.Commands
{
    public class UpdateStudentCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
