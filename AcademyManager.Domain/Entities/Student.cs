using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Entities;

namespace AcademyManager.Domain.Entities
{
    public class Student : Entity
    {
        private List<Enrollment> _enrollments;
        public Student(NameObject name, DateOnly birthDate, Cpf cpf, Email email, Password password)
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Email = email;
            Password = password;
            _enrollments = [];
        }

        public NameObject Name { get; }
        public DateOnly BirthDate { get; }
        public Cpf Cpf { get; }
        public Email Email { get; }
        public Password Password { get; }

        public IReadOnlyCollection<Enrollment> Enrollments { get { return _enrollments; } }

        public void AddEnrollment(Enrollment enrollment)
        {
            if (_enrollments.Exists(e => e.ClassGroupId == enrollment.ClassGroupId))
            {
                throw new ArgumentException("O aluno já está matriculado nessa turma.");
            }

            _enrollments.Add(enrollment);
        }

    }
}
