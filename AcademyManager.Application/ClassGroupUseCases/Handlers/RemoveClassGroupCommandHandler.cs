using AcademyManager.Application.ClassGroupUseCases.Commands;
using AcademyManager.Domain.Repositories;
using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.ClassGroupUseCases.Handlers
{
    public class RemoveClassGroupCommandHandler : IRequestHandler<RemoveClassGroupCommand, Result>
    {
        private readonly IClassGroupRepository _repository;

        public RemoveClassGroupCommandHandler(IClassGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveClassGroupCommand request, CancellationToken cancellationToken)
        {
            var existingClass = await _repository.GetById(request.Id);

            if (existingClass is null)
            {
                return Result.Failure("A turma informada não existe.");
            }

            existingClass.SetDeletedAt();
            foreach (var enrollment in existingClass.Enrollments)
            {
                enrollment.SetDeletedAt();
            }
            _repository.Update(existingClass);

            if (!await _repository.ContextUnitOfWork.CommitAsync())
                Result.Failure("Ocorreu um erro ao deletar o registro.");

            return Result.Success();
        }
    }
}
