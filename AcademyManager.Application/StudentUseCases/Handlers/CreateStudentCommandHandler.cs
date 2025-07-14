using AcademyManager.Application.StudentUseCases.Commands;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories;
using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Results;
using MediatR;

namespace AcademyManager.Application.StudentUseCases.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, ResultT<int?>>
    {
        private readonly IStudentRepository _repository;

        public CreateStudentCommandHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultT<int?>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var name = new Name(request.Name);
            var cpf = new Cpf(request.Cpf);
            var email = new Email(request.Email);
            var password = new Password(request.Password);

            var student = new Student(name, request.BirthDate, cpf, email, password);

            if (!student.IsValid)
            {
                return ResultT<int?>.Failure(student.ReadNotifications());
            }

            var emailExists = await _repository.CheckIfExistsByEmail(email.Address);
            if (emailExists)
            {
                return ResultT<int?>.Failure("O email informado já está sendo utilizado.");
            }

            var cpfExists = await _repository.CheckIfExistsByCpf(cpf.CpfNumber);
            if (cpfExists)
            {
                return ResultT<int?>.Failure("O CPF informado já está sendo utilizado.");
            }

            _repository.Add(student);

            if (!await _repository.ContextUnitOfWork.CommitAsync())
                ResultT<int?>.Failure("Ocorreu um erro ao salvar o registro.");

            return ResultT<int?>.Success(student.Id);
        }
    }
}
