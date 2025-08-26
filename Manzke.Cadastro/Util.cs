using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Manzke.Cadastro
{
    public static class Util
    {
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public static bool IsEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // RFC 5322 compliant email regex pattern
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            
            try
            {
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
