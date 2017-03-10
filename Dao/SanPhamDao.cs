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
    public class SanPhamDao
    {
        public static DataTable getList()
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT * FROM SAN_PHAM";
            SqlDataAdapter adapter = new SqlDataAdapter(strQuery, Connection.getConnection());
            adapter.Fill(dt);
            return dt;
        }
    }
}
