using AcademyManager.Application.StudentUseCases.Commands;
using AcademyManager.Domain.Repositories;
using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.StudentUseCases.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Result>
    {
        private readonly IStudentRepository _repository;

        public UpdateStudentCommandHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var existingStudent = await _repository.GetById(request.Id);

            if (existingStudent is null)
            {
                return Result.Failure("O aluno informado não existe.");
            }

            var name = new Name(request.Name);
            var cpf = new Cpf(request.Cpf);
            var email = new Email(request.Email);

            existingStudent.Update(name, request.BirthDate, cpf, email);

            if (!existingStudent.IsValid)
            {
                return Result.Failure(existingStudent.ReadNotifications());
            }

            var emailExists = await _repository.CheckIfExistsByEmail(email.Address);
            if (emailExists)
            {
                return Result.Failure("O email informado já está sendo utilizado.");
            }

            var cpfExists = await _repository.CheckIfExistsByCpf(cpf.CpfNumber);
            if (cpfExists)
            {
                return Result.Failure("O CPF informado já está sendo utilizado.");
            }

            _repository.Update(existingStudent);

            if (!await _repository.ContextUnitOfWork.CommitAsync())
                Result.Failure("Ocorreu um erro ao salvar o registro.");

            return Result.Success();
        }
    }
}
