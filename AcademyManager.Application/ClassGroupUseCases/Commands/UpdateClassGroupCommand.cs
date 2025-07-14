using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.ClassGroupUseCases.Commands
{
    public class UpdateClassGroupCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
