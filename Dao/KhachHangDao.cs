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
    class KhachHangDao
    {
        public Boolean isExits(String id)
        {
            Boolean rtn = false;
            String strQuery = "SELECT COUNT(ID) FROM KHACH_HANG WHERE ID_KHACH_HANG = @Id";
            SqlDataAdapter adapter = Connection.createSqlDataAdaptre(strQuery);
            SqlParameter iDParm = adapter.SelectCommand.Parameters.Add(
                                          "@Id", SqlDbType.NChar, 30);
            iDParm.Value = id;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dtTable = dataSet.Tables[0];
            if (Convert.ToInt32(dtTable.Rows[0][0]) == 0) {
                rtn = true;
            }
            return rtn;
        }

    }
}
