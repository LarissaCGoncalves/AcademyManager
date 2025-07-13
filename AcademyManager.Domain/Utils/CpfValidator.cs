namespace AcademyManager.Domain.Utils
{
    public static class CpfValidator
    {
        public static bool IsValid(string cpf)
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
