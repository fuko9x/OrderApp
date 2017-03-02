using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Common
{
    static class AppUtils
    {
        public static String getAppConfig(string key)
        {
            return System.Configuration.ConfigurationSettings.AppSettings[key];
        }
    }
}
