using AcademyManager.Application.ClassGroupUseCases.Commands;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories;
using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.ClassGroupUseCases.Handlers
{
    public class UpdateClassGroupCommandHandler : IRequestHandler<UpdateClassGroupCommand, Result>
    {
        private readonly IClassGroupRepository _repository;

        public UpdateClassGroupCommandHandler(IClassGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateClassGroupCommand request, CancellationToken cancellationToken)
        {
            var existingClass = await _repository.GetById(request.Id);

            if (existingClass is null)
            {
                return Result.Failure("A turma informada não existe.");
            }

            var name = new Name(request.Name);
            existingClass.Update(name, request.Description);

            if (!existingClass.IsValid)
            {
                return Result.Failure(existingClass.ReadNotifications());
            }

            _repository.Update(existingClass);

            if (!await _repository.ContextUnitOfWork.CommitAsync())
                Result.Failure("Ocorreu um erro ao salvar o registro.");

            return Result.Success();
        }
    }
}
