using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Common
{
    static class StringUtils
    {
        static String trim(String str)
        {
            if (str == null)
            {
                return str;
            }
            return str.Trim();
        }
    }
}
