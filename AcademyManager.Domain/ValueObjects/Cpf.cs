using AcademyManager.Domain.Utils;
using AcademyManager.Shared.ValueObjects;

namespace AcademyManager.Domain.ValueObjects
{
    public class Cpf : ValueObject
    {
        public string CpfNumber { get; }

        public Cpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("CPF não pode ser vazio.");

            var onlyNumbers = Clean(cpf);

            if (!CpfValidator.IsValid(onlyNumbers))
                throw new ArgumentException("CPF inválido.");

            CpfNumber = onlyNumbers;
        }

        private static string Clean(string cpf)
        {
            return new string([.. cpf.Where(char.IsDigit)]);
        }

        public override string ToString()
        {
            return $"{CpfNumber.Substring(0, 3)}.{CpfNumber.Substring(3, 3)}.{CpfNumber.Substring(6, 3)}-{CpfNumber.Substring(9, 2)}";
        }
    }

}
