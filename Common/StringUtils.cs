using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Common
{
    static class StringUtils
    {
        public static String Trim(String str)
        {
            if (str == null)
            {
                return str;
            }
            return str.Trim();
        }

        public static Boolean isBlank(String str)
        {
            if (str == null || Trim(str) == "")
            {
                return true;
            }
            return false;
        }

        public static Boolean isNotBlank(String str)
        {
            if (str == null || Trim(str) == "")
            {
                return false;
            }
            return true;
        }

        public static Object replaceNull(Object o)
        {
            if (null == o)
            {
                return "";
            }
            return o;
        }
    }
}
