using System.Security.Cryptography;
using System.Text;

namespace AcademyManager.Domain.Utils
{
    public static class Encrypt
    {
        private const string aggregateValue = "@Security@Key";
        public static string GenerateHash(string entry, string aggregateValue = aggregateValue)
        {
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
