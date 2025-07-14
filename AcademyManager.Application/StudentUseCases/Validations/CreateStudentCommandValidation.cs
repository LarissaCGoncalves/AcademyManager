using AcademyManager.Application.StudentUseCases.Commands;
using FluentValidation;

namespace AcademyManager.Application.StudentUseCases.Validations
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome do aluno é obrigatório.");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("O nome do aluno deve conter pelo menos 3 caracteres.");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("O nome do aluno deve conter no máximo 100 caracteres.");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("A data de nascimento do aluno é obrigatória.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email do aluno é obrigatório.");

            RuleFor(x => x.Email)
                .MaximumLength(50)
                .WithMessage("O email do aluno deve conter no máximo 100 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("O cpf do aluno é obrigatório.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Informe uma senha para o aluno.");
        }
    }
}
