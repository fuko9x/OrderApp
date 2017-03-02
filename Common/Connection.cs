using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Common
{
    static class Connection
    {
        private static SqlConnection con = null;

        public static SqlConnection getConnection()
        {
            if (con != null)
            {
                return con;
            }
            string strUrl = "UID =" + AppUtils.getAppConfig("Id") + ";";
            strUrl += "password=" + AppUtils.getAppConfig("Password") + ";";
            strUrl += "server=" + AppUtils.getAppConfig("Server") + ";";
            strUrl += "database=" + AppUtils.getAppConfig("Database") + ";";
            strUrl += "Trusted_Connection=" + AppUtils.getAppConfig("TrustedConnection") + ";";
            strUrl += "connection timeout=" + AppUtils.getAppConfig("Timeout");
            con = new SqlConnection("server=LVBINH-PC;database=ORDERDB;UID=sa;password=123"); 
        con.Open();
            return con; 
        }

        public static SqlCommand createSqlCommand(String strQuery)
        {
            return new SqlCommand(strQuery, con);
        }
    }
}
