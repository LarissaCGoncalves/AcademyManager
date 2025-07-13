using AcademyManager.Shared.ValueObjects;
using System.Net.Mail;

namespace AcademyManager.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private Email() { }
        public string Address { get; }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                AddNotification("Email", "Email não pode ser vazio.");

            var trimmedAddress = address.Trim();

            if (!Validate(trimmedAddress))
                AddNotification("Email", "Email inválido.");

            Address = trimmedAddress;
        }

        private static bool Validate(string email)
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
