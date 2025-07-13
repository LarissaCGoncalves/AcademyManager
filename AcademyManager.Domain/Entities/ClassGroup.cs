using AcademyManager.Domain.ValueObjects;
using AcademyManager.Shared.Entities;

namespace AcademyManager.Domain.Entities
{
    public class ClassGroup : Entity
    {
        public ClassGroup(NameObject name, string? description)
        {
            Name = name;
            Description = description;
        }

        public NameObject Name { get; }
        public string? Description { get; }
        public IReadOnlyCollection<Enrollment> Enrollments { get; }
    }
}
