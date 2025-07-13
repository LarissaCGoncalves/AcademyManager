using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Entities;

namespace AcademyManager.Domain.Entities
{
    public class ClassGroup : Entity
    {
        private ClassGroup() { }
        public ClassGroup(Name name, string? description)
        {
            Name = name;
            Description = description;

            AddNotifications(name.Notifications);
        }

        public Name Name { get; }
        public string? Description { get; }
        public IReadOnlyCollection<Enrollment> Enrollments { get; }
    }
}
