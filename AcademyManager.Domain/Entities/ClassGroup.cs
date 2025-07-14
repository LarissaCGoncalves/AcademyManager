using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Entities;

namespace AcademyManager.Domain.Entities
{
    public class ClassGroup : Entity
    {
        private ClassGroup() { }
        public ClassGroup(int id, Name name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;

            AddNotifications(name.Notifications);
        }

        public Name Name { get; private set; }
        public string? Description { get; private set; }
        public IReadOnlyCollection<Enrollment> Enrollments { get; }

        public void Update(Name name,  string? description)
        {
            ClearNotifications();

            Name = name;
            Description = description;

            AddNotifications(name.Notifications);
        }
    }
}
