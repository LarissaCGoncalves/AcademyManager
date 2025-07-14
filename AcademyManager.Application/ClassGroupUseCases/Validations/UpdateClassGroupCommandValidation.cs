using AcademyManager.Application.ClassGroupUseCases.Commands;
using FluentValidation;

namespace AcademyManager.Application.ClassGroupUseCases.Validations
{
    public class UpdateClassGroupCommandValidator : AbstractValidator<UpdateClassGroupCommand>
    {
        public UpdateClassGroupCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O Id da turma é obrigatório.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome da turma é obrigatório.");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("O nome da turma deve conter pelo menos 3 caracteres.");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("O nome da turma deve conter no máximo 100 caracteres.");
        }
    }
}
