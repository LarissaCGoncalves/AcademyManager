using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Entities;

namespace AcademyManager.Domain.Entities
{
    public class Student : Entity
    {
        private Student() { }
        private List<Enrollment> _enrollments;
        public Student(Name name, DateOnly birthDate, Cpf cpf, Email email, Password password)
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Email = email;
            Password = password;

            _enrollments = [];

            AddNotifications(name.Notifications);
            AddNotifications(cpf.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(password.Notifications);
        }

        public Name Name { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }

        public IReadOnlyCollection<Enrollment> Enrollments { get { return _enrollments; } }

        public void AddEnrollment(Enrollment enrollment)
        {
            if (_enrollments.Exists(e => e.ClassId == enrollment.ClassId))
                AddNotification("Student", "O aluno já está matriculado no curso.");

            else
                _enrollments.Add(enrollment);
        }

        public void Update(Name name, DateOnly birthDate, Cpf cpf, Email email)
        {
            ClearNotifications();

            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Email = email;

            AddNotifications(name.Notifications);
            AddNotifications(cpf.Notifications);
            AddNotifications(email.Notifications);
        }
    }
}