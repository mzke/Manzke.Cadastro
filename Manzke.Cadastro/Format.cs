using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manzke.Cadastro
{
    public static class Format
    {
        public static string CpfOuCnpj(string numero)
        {
            if (numero?.Length == 14)
                return Cnpj.Format(numero);
            if (numero?.Length == 11)
                return Cpf.Format(numero);
            return numero;
        }

        public static string Telefone(string numero)
        {
            return Cadastro.Telefone.Format(numero);
        }

    }
}
