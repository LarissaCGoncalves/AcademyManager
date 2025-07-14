using AcademyManager.Shared.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace AcademyManager.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public string Hash { get; private set; } = "";
        private Password() { }

        public Password(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
            {
                AddNotification("Password", "Senha não pode ser vazia.");
                return;
            }

            if (plainPassword.Length < 8 ||
                !plainPassword.Any(char.IsUpper) ||
                !plainPassword.Any(char.IsLower) ||
                !plainPassword.Any(char.IsDigit) ||
                !plainPassword.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                AddNotification("Password", "Senha fraca. A senha deve conter pelo menos 8 caracteres, " +
                    "incluindo letras maiúsculas e minúsculas, números e símbolos especiais.");
                return;
            }

            Hash = GenerateHash(plainPassword);
        }

        public bool Validate(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                return false;

            var hashToCompare = GenerateHash(plainPassword);
            return Hash == hashToCompare;
        }

        private static string GenerateHash(string entry)
        {
            const string aggregateValue = "@Security@Key";

            if (string.IsNullOrEmpty(entry))
                return string.Empty;

            entry += aggregateValue;
            byte[] data = SHA256.HashData(Encoding.Default.GetBytes(entry));

            StringBuilder sbString = new();

            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));

            entry = sbString.ToString();

            return entry;
        }
    }
}
