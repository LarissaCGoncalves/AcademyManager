using AcademyManager.Application.ClassGroup.Commands;
using FluentValidation;

namespace AcademyManager.Application.ClassGroup.Validations
{
    public class CreateClassGroupCommandValidator : AbstractValidator<CreateClassGroupCommand>
    {
        public CreateClassGroupCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");
        }
    }

}
