using OrderApp.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dao
{
    class CommonDao
    {
        public DateTime getServerTime()
        {
            DateTime now = new DateTime();
            String strQuery = "Select SYSDATETIME()";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            now = reader.GetDateTime(0);
            reader.Close();
            return now;
        }
    }
}
