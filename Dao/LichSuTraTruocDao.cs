using OrderApp.Common;
using OrderApp.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dao
{
    class LichSuTraTruocDao
    {
        public static void insert(LichSuTraTruocDto lichSuDTO)
        {
            String strQuery = "INSERT INTO LICH_SU_TRA_TRUOC (ID_KHACH_HANG, SO_TIEN, NGAY_TRA, GHI_CHU)"
            + " VALUES ( @idKhachHang, @soTien, @ngayTra, @ghiChu )";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@idKhachHang", lichSuDTO.idKhachHang);
            cmd.Parameters.AddWithValue("@soTien", lichSuDTO.soTien);
            cmd.Parameters.AddWithValue("@ngayTra", lichSuDTO.ngayTra);
            cmd.Parameters.AddWithValue("@ghiChu", lichSuDTO.ghiChu);
            cmd.ExecuteNonQuery();
        }

        public static DataTable getList(String idKhachHang)
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT LS.*, KH.TEN_KHACH_HANG FROM LICH_SU_TRA_TRUOC LS"
                + " LEFT JOIN KHACH_HANG KH ON LS.ID_KHACH_HANG = KH.ID_KHACH_HANG"
                + " WHERE LS.ID_KHACH_HANG = @idKhachHang "
                + " ORDER BY LS.NGAY_TRA DESC , LS.ID DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(strQuery, Connection.getConnection());
            adapter.SelectCommand.Parameters.AddWithValue("@idKhachHang", idKhachHang);
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable getList()
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT LS.*, KH.TEN_KHACH_HANG FROM LICH_SU_TRA_TRUOC LS"
                + " LEFT JOIN KHACH_HANG KH ON LS.ID_KHACH_HANG = KH.ID_KHACH_HANG"
                + " ORDER BY LS.NGAY_TRA DESC , LS.ID DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(strQuery, Connection.getConnection());
            adapter.Fill(dt);
            return dt;
        }

        public static Decimal getSum(String idKhachHang, String dateTo, String dateFrom)
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT SUM(SO_TIEN) FROM LICH_SU_TRA_TRUOC"
                + " WHERE ID_KHACH_HANG = '" + idKhachHang + "'"
                + " AND NGAY_TRA >= '" + dateTo + "' AND NGAY_TRA <= '" + dateFrom + "'";

            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();

            Decimal sum = 0;
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    sum = reader.GetDecimal(0);
                }
                
            }
            reader.Close();
            return sum;
        }
    }
}
