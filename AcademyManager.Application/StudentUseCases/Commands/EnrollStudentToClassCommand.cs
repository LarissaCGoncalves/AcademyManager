using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.StudentUseCases.Commands
{
    public class EnrollStudentToClassCommand : IRequest<Result>
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }
}
