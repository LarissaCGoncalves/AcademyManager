using AcademyManager.Application.ClassGroupUseCases.Commands;
using AcademyManager.Application.StudentUseCases.Commands;
using FluentValidation;

namespace AcademyManager.Application.ClassGroupUseCases.Validations
{
    public class RemoveClassGroupCommandValidator : AbstractValidator<RemoveClassGroupCommand>
    {
        public RemoveClassGroupCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O Id da turma é obrigatório.");
        }
    }
}
