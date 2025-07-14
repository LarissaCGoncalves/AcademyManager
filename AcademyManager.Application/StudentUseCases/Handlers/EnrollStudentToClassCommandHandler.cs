using AcademyManager.Application.StudentUseCases.Commands;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories;
using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.StudentUseCases.Handlers
{
    public class EnrollStudentToClassCommandHandler : IRequestHandler<EnrollStudentToClassCommand, Result>
    {
        private readonly IStudentRepository _repository;

        public EnrollStudentToClassCommandHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(EnrollStudentToClassCommand request, CancellationToken cancellationToken)
        {
            var existingStudent = await _repository.GetById(request.StudentId, i => i.Enrollments);

            if (existingStudent is null)
            {
                return Result.Failure("O aluno informado não existe.");
            }

            var enrollment = new Enrollment(request.StudentId, request.ClassId);
            existingStudent.AddEnrollment(enrollment);

            if (!existingStudent.IsValid)
            {
                return Result.Failure(existingStudent.ReadNotifications());
            }

            _repository.Update(existingStudent);

            if (!await _repository.ContextUnitOfWork.CommitAsync())
                Result.Failure("Ocorreu um erro ao salvar o registro.");

            return Result.Success();
        }
    }
}
