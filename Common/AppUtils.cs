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


        /// <summary>
        /// Tính tiền order
        /// </summary>
        /// <param name="numDefaultPage">Số trang mặc đinh (DB)</param>
        /// <param name="costDefault">Đơn giá mặc định (DB)</param>
        /// <param name="numInputPage">Số trang nhập vào (FORM)</param>
        /// <param name="costPageAdd">Số tiền mỗi trang (DB)</param>
        /// <returns></returns>
        public static Double cashProduct(int numDefaultPage, Double costDefault, int numInputPage, Double costPageAdd)
        {
            return costDefault + (numInputPage - numDefaultPage) * costPageAdd;
        }
    }
}
