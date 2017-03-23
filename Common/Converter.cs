using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Common
{
    static class Converter
    {
        public static HashSet<Object> listToHashSet(List<dynamic> src, Type srcType, String property)
        {
            if (src == null || src.Count == 0)
            {
                return null;
            }
            HashSet<Object> dest = new HashSet<Object>();
            foreach (Object item in src)
            {
                
                PropertyInfo pi = Convert.ChangeType(item, srcType).GetType().GetProperty(property);
                if (pi == null)
                {
                    return null;
                }
                dest.Add(pi.GetValue(item, null));
            }
            return dest;
        }
    }
}
