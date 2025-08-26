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

        public static string Capitalizar(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return nome;
            else
                return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.Trim().ToLower());
        }

        public static string Capitalizar2(string frase)
        {
            if (string.IsNullOrWhiteSpace(frase))
                return frase;

            string[] preposicoes = {
                "de", "do", "da", "dos", "das", "em", "no", "na", "nos", "nas",
                "por", "per", "a", "as", "o", "os", "com", "sem", "sob", "sobre",
                "para", "perante", "ante", "após", "até", "contra", "desde", "entre", "trás"
            };

            char[] pontuacoesFinais = { '.', ',', ';', '!', '?', ':' };

            string[] palavras = frase.Split(' ');
            for (int i = 0; i < palavras.Length; i++)
            {
                string palavraOriginal = palavras[i];
                string palavra = palavraOriginal;
                string pontuacao = "";

                // Se termina com pontuação, separa
                if (palavra.Length > 1 && pontuacoesFinais.Contains(palavra[^1]))
                {
                    pontuacao = palavra[^1].ToString();
                    palavra = palavra.Substring(0, palavra.Length - 1);
                }

                // Regras de capitalização
                bool deveCapitalizar = palavra.Length > 1 && (i == 0 || !preposicoes.Contains(palavra.ToLower()));

                if (deveCapitalizar)
                {
                    palavra = char.ToUpper(palavra[0]) + palavra.Substring(1).ToLower();
                }
                else
                {
                    palavra = palavra.ToLower();
                }

                palavras[i] = palavra + pontuacao;
            }

            return string.Join(" ", palavras);
        }

        public static string? Truncar(string texto, int maxChars)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return texto;
            }
            if (texto.Length > maxChars)
            {
                return texto.Substring(0, maxChars);
            }
            else
            {
                return texto;
            }
        }
    }
}