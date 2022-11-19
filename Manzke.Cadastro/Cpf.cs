﻿namespace Manzke.Cadastro
{
    public static class Cpf
    {
        public static bool IsCPF(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;

            int soma;
            int resto;

            if (Util.IsNumeric(cpf))
            {

                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");

                if (cpf.Length != 11)
                {
                    return false;
                }
                tempCpf = cpf.Substring(0, 9);

                soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1[i]);
                }
                resto = soma % 11;

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                int soma2 = 0;

                for (int i = 0; i < 10; i++)
                {
                    soma2 += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                }

                resto = soma2 % 11;

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }
            else
                return false;
        }

        public static string Format(string numero)
        {
            string result = numero;
            if (result.Length == 11)
            {
                result = result.Substring(0, 3) + "." +
                    result.Substring(3, 3) + "." +
                    result.Substring(6, 3) + "-" +
                    result.Substring(9, 2);
            }

            return result;
        }
    }
}
