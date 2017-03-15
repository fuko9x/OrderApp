using OrderApp.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OrderApp.Common
{
    static class AppUtils
    {
        public static String getAppConfig(String key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }


        /// <summary>
        /// Get Current Time In Database
        /// </summary>
        /// <returns></returns>
        public static DateTime getServerTime()
        {
            return new CommonDao().getServerTime();
        }

        public static String formatNumber2Monney(Decimal monney)
        {
            return String.Format("{0:#,###}", monney);
        }

        public static Decimal formatMoney2Number(String monney, Decimal defaultNumber)
        {
            try
            {
                Regex rgx = new Regex("[^0-9]");
                String number = rgx.Replace(monney, "");
                return Decimal.Parse(number);
            }
            catch (Exception ex)
            {
                return defaultNumber;
            }
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
