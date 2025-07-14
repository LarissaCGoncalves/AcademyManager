using AcademyManager.Application.StudentUseCases.Commands;
using AcademyManager.Domain.Repositories;
using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.StudentUseCases.Handlers
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand, Result>
    {
        private readonly IStudentRepository _repository;

        public RemoveStudentCommandHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var existingStudent = await _repository.GetById(request.Id, i => i.Enrollments);

            if (existingStudent is null)
            {
                return Result.Failure("O aluno informado não existe.");
            }

            existingStudent.SetDeletedAt();
            foreach (var enrollment in existingStudent.Enrollments)
            {
                enrollment.SetDeletedAt();
            }
            _repository.Update(existingStudent);

            if (!await _repository.ContextUnitOfWork.CommitAsync())
                Result.Failure("Ocorreu um erro ao deletar o registro.");

            return Result.Success();
        }
    }
}
