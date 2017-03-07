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

        public void insert(KhachHangDto dto)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO KHACH_HANG "
                + "("
                + "ID_KHACH_HANG"
                + ", TEN_KHACH_HANG"
                + ", DIA_CHI"
                + ", EMAIL"
                + ", ACC_FTP"
                + ", GIAM_GIA"
                + ", TEN_SALES"
                + ", HOA_HONG_SALES"
                + ", GHI_CHU"
                + ", NGAY_BAT_DAU"
                + ", VAN_CHUYEN"
                + ", TRANG_THAI"
                + ", CREATE_BY"
                + ", CREATE_TIME"
                + ")" 
                + "VALUES ("
                + "@idKhachHang"
                + ", @tenKhachHang"
                + ", @diaChi"
                + ", @email"
                + ", @accFtp"
                + ", @giamGia"
                + ", @sales"
                + ", @salesPercent"
                + ", @notes"
                + ", @startDate"
                + ", @vanChuyen"
                + ", @trangthaixuatkho"
                + ", @createBy"
                + ", @createTime"
                + ")");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@idKhachHang", dto.idKhachHang);
            cmd.Parameters.AddWithValue("@tenKhachHang", dto.tenKhachHang);
            cmd.Parameters.AddWithValue("@diaChi", dto.diaChi);
            cmd.Parameters.AddWithValue("@email", dto.email);
            cmd.Parameters.AddWithValue("@accFtp", dto.accFtp);
            cmd.Parameters.AddWithValue("@giamGia", dto.giamGia);
            cmd.Parameters.AddWithValue("@sales", dto.sales);
            cmd.Parameters.AddWithValue("@salesPercent", dto.salesPercent);
            cmd.Parameters.AddWithValue("@notes", dto.notes);
            cmd.Parameters.AddWithValue("@startDate", dto.startDate);
            cmd.Parameters.AddWithValue("@vanChuyen", dto.vanChuyen);
            cmd.Parameters.AddWithValue("@trangthaixuatkho", dto.trangThaiXuatKho);
            cmd.Parameters.AddWithValue("@createBy", dto.createBy);
            cmd.Parameters.AddWithValue("@createTime", dto.createTime);
            cmd.ExecuteNonQuery();
        }

    }
}
