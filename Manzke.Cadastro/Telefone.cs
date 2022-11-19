using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manzke.Cadastro
{
    public static class Telefone
    {
        public static string Format(string? numero)
        {
            string? result = numero;
            string ddd = string.Empty;
         
            if (result?.Length > 9)
            {
                ddd = result.Substring(0, 2);

                return  $"({ddd}){Format(result.Substring(2))}" ;
            }

            if (result?.Length > 5)
                result = result.Insert(result.Length - 4, "-");

            return result;
        }
    }
}
