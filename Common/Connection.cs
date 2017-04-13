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

        public static SqlConnection getConnectionMaster()
        {
            String connectionString = String.Format(
                @"server = {0}; database = {1}; UID = {2}; password = {3}",
                AppUtils.getAppConfig("Server")
                , "master"
                , AppUtils.getAppConfig("Id")
                , AppUtils.getAppConfig("Password")
            );
            SqlConnection myConn = new SqlConnection(connectionString);
            return myConn;
        }

        public static void closeConnection()
        {
            if (con != null && con.State != System.Data.ConnectionState.Closed)
            {
                con.Close();
                con = null;
            }
        }

        public static SqlConnection getConnection()
        {
            if (con != null)
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                return con;
            }

            String connectionString = String.Format(
                @"server = {0}; database = {1}; UID = {2}; password = {3}",
                AppUtils.getAppConfig("Server")
                , AppUtils.getAppConfig("Database")
                , AppUtils.getAppConfig("Id")
                , AppUtils.getAppConfig("Password")
            );
            con = new SqlConnection(connectionString);
            //con = new SqlConnection("server =192.168.1.112\\SQLEXPRESS;database=ORDERDB;UID=sa;password=123");
            //con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=ORDERDB;Integrated Security=True"); 

            con.Open();
            return con; 
        }

        public static SqlCommand createSqlCommand(String strQuery)
        {

            return new SqlCommand(strQuery, getConnection());
        }

        public static SqlDataAdapter createSqlDataAdaptre(String strQuery)
        {
            return new SqlDataAdapter(strQuery, getConnection());
        }
    }
}
