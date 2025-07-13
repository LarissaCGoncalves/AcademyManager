using AcademyManager.Application.ClassGroup.Commands;
using AcademyManager.Shared.Results;
using MediatR;
using Microsoft.Extensions.Logging;


namespace AcademyManager.Application.ClassGroup.Handlers
{

    public class CreateClassGroupCommandHandler : IRequestHandler<CreateClassGroupCommand, Result<bool>>
    {
        private readonly ILogger<CreateClassGroupCommandHandler> _logger;

        public CreateClassGroupCommandHandler(ILogger<CreateClassGroupCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Result<bool>> Handle(CreateClassGroupCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var user = new User(request.Name, request.Email, request.Password);
                //await _userRepository.SaveAsync(user);
                //_logger.LogInformation("Usuário criado com sucesso: {UserId}", user.Id);

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuário");
                return Result<bool>.Failure("Erro interno ao criar usuário");
            }
        }
    }

}
