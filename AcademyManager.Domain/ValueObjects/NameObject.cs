using AcademyManager.Shared.ValueObjects;

namespace AcademyManager.Domain.ValueObjects
{
    public class NameObject : ValueObject
    {
        public string Name { get; }

        public NameObject(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 3)
                throw new ArgumentException("Name must contain at least 3 characters.");

            Name = name.Trim();
        }
    }

}
