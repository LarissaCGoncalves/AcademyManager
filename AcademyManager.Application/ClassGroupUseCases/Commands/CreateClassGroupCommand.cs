using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.ClassGroupUseCases.Commands
{
    public class CreateClassGroupCommand : IRequest<ResultT<int?>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
