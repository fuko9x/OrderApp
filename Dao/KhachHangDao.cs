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
            Boolean rtn = true;
            String strQuery = "SELECT COUNT(ID) FROM KHACH_HANG WHERE ID_KHACH_HANG = @id";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(0) == 0)
            {
                rtn = false;
            }
            reader.Close();
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
                + " VALUES ("
                + " @idKhachHang"
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

        public void insertList(List<KhachHangDto> listKH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            String sql = "INSERT INTO KHACH_HANG "
                + "("
                + " ID_KHACH_HANG"
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
                + " )"
                + " VALUES ";
            for (int i = 0; i < listKH.Count; i++)
            {
                sql += "("
                + " @idKhachHang" + i
                + ", @tenKhachHang" + i
                + ", @diaChi" + i
                + ", @email" + i
                + ", @accFtp" + i
                + ", @giamGia" + i
                + ", @sales" + i
                + ", @salesPercent" + i
                + ", @notes" + i
                + ", @startDate" + i
                + ", @vanChuyen" + i
                + ", @trangthaixuatkho" + i
                + ", @createBy" + i
                + ", @createTime" + i
                + " )";

                KhachHangDto dto = listKH[i];

                cmd.Parameters.AddWithValue("@idKhachHang" + i, dto.idKhachHang);
                cmd.Parameters.AddWithValue("@tenKhachHang" + i, dto.tenKhachHang);
                cmd.Parameters.AddWithValue("@diaChi" + i, dto.diaChi);
                cmd.Parameters.AddWithValue("@email" + i, dto.email);
                cmd.Parameters.AddWithValue("@accFtp" + i, dto.accFtp);
                cmd.Parameters.AddWithValue("@giamGia" + i, dto.giamGia);
                cmd.Parameters.AddWithValue("@sales" + i, dto.sales);
                cmd.Parameters.AddWithValue("@salesPercent" + i, dto.salesPercent);
                cmd.Parameters.AddWithValue("@notes" + i, dto.notes);
                cmd.Parameters.AddWithValue("@startDate" + i, dto.startDate);
                cmd.Parameters.AddWithValue("@vanChuyen" + i, dto.vanChuyen);
                cmd.Parameters.AddWithValue("@trangthaixuatkho" + i, dto.trangThaiXuatKho);
                cmd.Parameters.AddWithValue("@createBy" + i, dto.createBy);
                cmd.Parameters.AddWithValue("@createTime" + i, dto.createTime);
            }
        }
            public void update(KhachHangDto dto)
        {
            SqlCommand cmd = new SqlCommand("Update  KHACH_HANG SET"
                 + "("
                 + " TEN_KHACH_HANG"
                 + ", EMAIL"
                 + ", ACC FTP"
                 + ", TEN_KHACH_HANG"
                  + ", CREATE_BY"
                + ", CREATE_TIME"
                + ")"
                 + " = ("
                 + " @tenKhachHang"
                 + ", @diaChi"
                 + ", @email"
                + ", @accFtp"
                 + ", @createBy"
                + ", @createTime"
                + ")");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@tenKhachHang", dto.tenKhachHang);
            cmd.Parameters.AddWithValue("@diaChi", dto.diaChi);
            cmd.Parameters.AddWithValue("@email", dto.email);
            cmd.Parameters.AddWithValue("@accFtp", dto.accFtp);
            cmd.Parameters.AddWithValue("@createBy", dto.createBy);
            cmd.Parameters.AddWithValue("@createTime", dto.createTime);
            cmd.ExecuteNonQuery();
        }
        public void updateList(List<KhachHangDto> listKH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            String sql = "Update KHACH_HANG SET"
                     + "("
                     + " TEN_KHACH_HANG"
                     + ", EMAIL"
                     + ", ACC FTP"
                     + ", TEN_KHACH_HANG"
                     + ", CREATE_BY"
                     + ", CREATE_TIME"
                     + ")"
                     + " = ";
            for (int i = 0; i < listKH.Count; i++)
            {
                sql += "("
                + " @tenKhachHang" + i
                + ", @diaChi" + i
                + ", @email" + i
                + ", @accFtp" + i
                + ", @createBy" + i
                + ", @createTime" + i
                + " )"
                ;
                KhachHangDto dto = listKH[i];

                cmd.Parameters.AddWithValue("@tenKhachHang" + i, dto.tenKhachHang);
                cmd.Parameters.AddWithValue("@diaChi" + i, dto.diaChi);
                cmd.Parameters.AddWithValue("@email" + i, dto.email);
                cmd.Parameters.AddWithValue("@accFtp" + i, dto.accFtp);
                cmd.Parameters.AddWithValue("@createBy" + i, dto.createBy);
                cmd.Parameters.AddWithValue("@createTime" + i, dto.createTime);
            }
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }


    }
}
