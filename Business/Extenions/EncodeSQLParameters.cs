using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extenions
{
    public static class EncodeSQLParameters
    {
        public static string EncodeSQLParameter(this string paramt)
        {
           
            if (string.IsNullOrEmpty(paramt))
                return paramt;
            return paramt.Replace("+", "%2B");
        }
    }
}
