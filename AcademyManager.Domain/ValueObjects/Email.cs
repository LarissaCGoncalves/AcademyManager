using AcademyManager.Shared.ValueObjects;
using System.Net.Mail;

namespace AcademyManager.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Email não pode ser vazio.");

            var trimmedAddress = address.Trim();

            if (!IsValid(trimmedAddress))
                throw new ArgumentException("Email inválido.");

            Address = trimmedAddress;
        }

        private static bool IsValid(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

}
