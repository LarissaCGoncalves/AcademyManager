using AcademyManager.Application.StudentUseCases.Commands;
using FluentValidation;

namespace AcademyManager.Application.StudentUseCases.Validations
{
    public class RemoveStudentCommandValidator : AbstractValidator<RemoveStudentCommand>
    {
        public RemoveStudentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O Id do aluno é obrigatório.");
        }
    }
}
