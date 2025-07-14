using AcademyManager.Application.StudentUseCases.Commands;
using FluentValidation;

namespace AcademyManager.Application.StudentUseCases.Validations
{
    public class EnrollStudentToClassCommandValidation : AbstractValidator<EnrollStudentToClassCommand>
    {
        public EnrollStudentToClassCommandValidation()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty()
                .WithMessage("O Id do aluno é obrigatório.");

            RuleFor(x => x.ClassId)
                .NotEmpty()
                .WithMessage("O Id da classe é obrigatório.");
        }
    }
}
