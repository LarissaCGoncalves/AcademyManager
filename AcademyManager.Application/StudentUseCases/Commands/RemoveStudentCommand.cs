using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.StudentUseCases.Commands
{
    public class RemoveStudentCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
