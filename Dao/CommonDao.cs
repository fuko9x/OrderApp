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
            String strQuery = "Select GETDATE()";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            now = reader.GetDateTime(0);
            reader.Close();
            return now;
        }

        public SqlDataReader getAllData(String tableName)
        {
            String strQuery = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void cleanTable(String tableName)
        {
            String strQuery = "DELETE FROM " + tableName;
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.ExecuteNonQuery();
        }

        public void insertDatabase(DataTable csvFileData, String tableName)
        {
            using (SqlBulkCopy s = new SqlBulkCopy(Connection.getConnection()))
            {
                s.DestinationTableName = tableName;
                foreach (var column in csvFileData.Columns)
                    s.ColumnMappings.Add(column.ToString(), column.ToString());
                s.WriteToServer(csvFileData);
            }
        }
    }
}
