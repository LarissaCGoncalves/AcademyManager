using AcademyManager.Shared.ValueObjects;

namespace AcademyManager.Domain.ValueObjects
{
    public class Cpf : ValueObject
    {
        private Cpf() { }
        public string CpfNumber { get; }

        public Cpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                AddNotification("Cpf", "CPF não pode ser vazio.");

            var onlyNumbers = Clean(cpf);

            if (!Validate(onlyNumbers))
                AddNotification("Cpf", "CPF inválido");

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

        public static bool Validate(string cpf)
        {
            int[] multiplier1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplier2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

            int remainder, addition = 0;
            string tempCpf, digit;

            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11 || new string(cpf[0], cpf.Length) == cpf)
                return false;

            tempCpf = cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                addition += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            remainder = addition % 11;

            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digit = remainder.ToString();

            tempCpf += digit;

            addition = 0;

            for (int i = 0; i < 10; i++)
                addition += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remainder = addition % 11;

            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digit += remainder.ToString();

            return cpf.EndsWith(digit);
        }
    }
}
