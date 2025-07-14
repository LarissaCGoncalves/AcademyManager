using AcademyManager.Shared.ValueObjects;

namespace AcademyManager.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string Value { get; }

        protected Name() { }
        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                AddNotification("Name", "Nome não pode ser vazio.");
                return;
            }

            var trimmed = name.Trim();

            if (trimmed.Length < 3)
            {
                AddNotification("Name", "Nome deve conter pelo menos 3 caracteres.");
                return;
            }

            Value = trimmed;
        }
    }
}
