using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Entities;

namespace AcademyManager.Domain.Entities
{
    public class User : Entity
    {
        private User() { }
        public User(Name name, Email email)
        {
            Name = name;
            Email = email;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
        }

        public Name Name { get; }
        public Email Email { get; }
        public Password Password { get; }
    }
}
