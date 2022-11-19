using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manzke.Cadastro
{
    public static  class Util
    {
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
