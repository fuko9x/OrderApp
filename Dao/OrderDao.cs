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
    class OrderDao
    {
        public int countOrderById(String id)
        {
            String strQuery = "SELECT COUNT(*) FROM DON_DAT_HANG WHERE ID like '" + id + "'";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0);
        }

        public void insert(OrderDto dto)
        {
            String strQuery = "INSERT INTO DON_DAT_HANG "
                + "( "
                + " ID"
                + ", ID_KHACH_HANG"
                + ", NGAY_GIAO"
                + ", TRANG_THAI_THANH_TOAN"
                + ", TONG_CONG"
                + ", VAT"
                + ", TONG_TIEN"
                + ", PHI_VAN_CHUYEN"
                + ", NOTES"
                + ", SDT"
                + ", CREATE_BY"
                + ", CREATE_TIME"
                + ") VALUES ("
                + "@id"
                + ", @idKhachHang"
                + ", @ngayGiao"
                + ", @trangThaiThanhToan"
                + ", @tongCong"
                + ", @vat"
                + ", @tongTien"
                + ", @phiVanChuyen"
                + ", @notes"
                + ", @sdt"
                + ", @user"
                + ", @createTime"
                + ")";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@id", dto.id);
            cmd.Parameters.AddWithValue("@idKhachHang", dto.idKhachHang);
            cmd.Parameters.AddWithValue("@ngayGiao", dto.ngayGiao);
            cmd.Parameters.AddWithValue("@trangThaiThanhToan", dto.thanhToan ? 1 : 0);
            cmd.Parameters.AddWithValue("@tongCong", dto.tongCong);
            cmd.Parameters.AddWithValue("@vat", dto.vat);
            cmd.Parameters.AddWithValue("@tongTien", dto.tongTien);
            cmd.Parameters.AddWithValue("@phiVanChuyen", dto.phiVanChuyen);
            cmd.Parameters.AddWithValue("@notes", dto.notes);
            cmd.Parameters.AddWithValue("@sdt", dto.phone);
            cmd.Parameters.AddWithValue("@user", dto.user);
            cmd.Parameters.AddWithValue("@createTime", dto.createTime);
            cmd.ExecuteNonQuery();
        }
    }
}
