using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.ClassGroup.Commands
{
    public class CreateClassGroupCommand : IRequest<Result<bool>>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
