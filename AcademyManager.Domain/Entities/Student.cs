using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Entities;

namespace AcademyManager.Domain.Entities
{
    public class Student : Entity
    {
        private Student() { }
        private List<Enrollment> _enrollments;
        public Student(Name name, DateOnly birthDate, Cpf cpf, Email email)
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Email = email;
            _enrollments = [];

            AddNotifications(name.Notifications);
            AddNotifications(cpf.Notifications);
            AddNotifications(email.Notifications);
        }

        public Name Name { get; }
        public DateOnly BirthDate { get; }
        public Cpf Cpf { get; }
        public Email Email { get; }
        public Password Password { get; private set; }

        public IReadOnlyCollection<Enrollment> Enrollments { get { return _enrollments; } }
        private void SetPassword(Password password) => Password = password;

        public void AddEnrollment(Enrollment enrollment)
        {
            if (_enrollments.Exists(e => e.ClassId == enrollment.ClassId))
                AddNotification("Student", "O aluno já está matriculado no curso.");

            else
                _enrollments.Add(enrollment);
        }
    }
}
