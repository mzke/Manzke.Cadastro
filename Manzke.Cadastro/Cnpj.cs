
namespace Manzke.Cadastro
{
    public static class Cnpj
    {
        public static string Raiz(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
            {
                return cnpj;
            }
            else
            {
                if (cnpj.Length == 14)
                {
                    return cnpj.Substring(0, 8);
                }
                else
                {
                    return cnpj;
                }
            }
        }

        public static bool IsMatriz(string cnpj)
        {
            if (cnpj == null || cnpj == string.Empty)
            {
                return true;
            }
            else
            {
                if (cnpj.Length == 14)
                {
                    string matriz = cnpj.Substring(8, 4);
                    if (int.Parse(matriz) == 1)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static string Format(string numero)
        {
            string result = numero;
            if (result.Length == 14)
            {
                result = result.Substring(0, 2) + "." +
                            result.Substring(2, 3) + "." +
                            result.Substring(5, 3) + "/" +
                            result.Substring(8, 4) + "-" +
                            result.Substring(12, 2);
            }
            return result;
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
