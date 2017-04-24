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
            String strQuery = "SELECT LS.*, KH.TEN_KHACH_HANG FROM LICH_SU_TRA_TRUOC LS, KHACH_HANG KH "
                + " WHERE LS.ID_KHACH_HANG = @idKhachHang "
                + " ORDER BY LS.NGAY_TRA DESC , LS.ID DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(strQuery, Connection.getConnection());
            adapter.SelectCommand.Parameters.AddWithValue("@idKhachHang", idKhachHang);
            adapter.Fill(dt);
            return dt;
        }
    }
}
