using AcademyManager.Application.ClassGroupUseCases.Commands;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories;
using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.ClassGroupUseCases.Handlers
{
    public class CreateClassGroupCommandHandler : IRequestHandler<CreateClassGroupCommand, ResultT<int?>>
    {
        private readonly IClassGroupRepository _repository;

        public CreateClassGroupCommandHandler(IClassGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultT<int?>> Handle(CreateClassGroupCommand request, CancellationToken cancellationToken)
        {
            var name = new Name(request.Name);
            var classGroup = new ClassGroup(0,name, request.Description);

            if (!classGroup.IsValid)
            {
                return ResultT<int?>.Failure(classGroup.ReadNotifications());
            }

            _repository.Add(classGroup);

            if (!await _repository.ContextUnitOfWork.CommitAsync())
                ResultT<int?>.Failure("Ocorreu um erro ao salvar o registro.");

            return ResultT<int?>.Success(classGroup.Id);
        }
    }
}
