using AcademyManager.Domain.Utils;
using AcademyManager.Shared.ValueObjects;

namespace AcademyManager.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public string Hash { get; }

        private Password(string hash)
        {
            Hash = hash;
        }

        public static Password Create(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                throw new ArgumentException("Password cannot be empty.");

            var hash = Encrypt.GenerateHash(plainPassword);
            return new Password(hash);
        }

        public bool Validate(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                return false;

            var hashToCompare = Encrypt.GenerateHash(plainPassword);
            return Hash == hashToCompare;
        }
    }
}
