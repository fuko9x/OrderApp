using OrderApp.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Common
{
    static class AppUtils
    {
        public static String getAppConfig(String key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static DateTime getServerTime()
        {
            return new CommonDao().getServerTime();
        }
    }
}
