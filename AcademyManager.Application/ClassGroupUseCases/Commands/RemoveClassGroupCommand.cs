using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.ClassGroupUseCases.Commands
{
    public class RemoveClassGroupCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
