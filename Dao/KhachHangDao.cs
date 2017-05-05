using OrderApp.Common;
using OrderApp.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                + ", SO_TIEN_NO"
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
                + ", @soTienNo"
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
            cmd.Parameters.AddWithValue("@soTienNo", dto.soTienNo);
            cmd.Parameters.AddWithValue("@email", dto.email);
            cmd.Parameters.AddWithValue("@accFtp", dto.accFtp);
            cmd.Parameters.AddWithValue("@giamGia", dto.giamGia);
            cmd.Parameters.AddWithValue("@sales", dto.sales);
            cmd.Parameters.AddWithValue("@salesPercent", dto.salesPercent);
            cmd.Parameters.AddWithValue("@notes", dto.notes);
            cmd.Parameters.AddWithValue("@startDate", dto.startDate);
            cmd.Parameters.AddWithValue("@vanChuyen", dto.vanChuyen);
            cmd.Parameters.AddWithValue("@trangthaixuatkho", dto.trangThaiNo);
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
                + ", SO_TIEN_NO"
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
                + ", @soTienNo" + i
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
                cmd.Parameters.AddWithValue("@soTienNo" + i, dto.soTienNo);
                cmd.Parameters.AddWithValue("@email" + i, dto.email);
                cmd.Parameters.AddWithValue("@accFtp" + i, dto.accFtp);
                cmd.Parameters.AddWithValue("@giamGia" + i, dto.giamGia);
                cmd.Parameters.AddWithValue("@sales" + i, dto.sales);
                cmd.Parameters.AddWithValue("@salesPercent" + i, dto.salesPercent);
                cmd.Parameters.AddWithValue("@notes" + i, dto.notes);
                cmd.Parameters.AddWithValue("@startDate" + i, dto.startDate);
                cmd.Parameters.AddWithValue("@vanChuyen" + i, dto.vanChuyen);
                cmd.Parameters.AddWithValue("@trangthaixuatkho" + i, dto.trangThaiNo);
                cmd.Parameters.AddWithValue("@createBy" + i, dto.createBy);
                cmd.Parameters.AddWithValue("@createTime" + i, dto.createTime);
            }
        }

        public static void giamSoTienNo(String idKhachHang, Decimal soTienNo)
        {
            SqlCommand cmd = new SqlCommand(
                    "UPDATE KHACH_HANG "
                     + " SET SO_TIEN_NO = SO_TIEN_NO - @soTienNo"
                     + " WHERE ID_KHACH_HANG = @idKhachHang"
                );
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@soTienNo", soTienNo);
            cmd.Parameters.AddWithValue("@idKhachHang", idKhachHang);
            cmd.ExecuteNonQuery();
        }

        public void update(KhachHangDto dto)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE KHACH_HANG "
                 + " SET TEN_KHACH_HANG = @tenKhachHang"
                 + ", EMAIL = @email"
                 + ", DIA_CHI = @diaChi"
                 + ", ACC_FTP = @accFtp"
                 + ", CREATE_BY = @createBy"
                 + ", CREATE_TIME = @createTime"
                 + ", SO_TIEN_NO = @soTienNo"
                 + " WHERE ID_KHACH_HANG = @idKhachHang"
            );
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@tenKhachHang", dto.tenKhachHang);
            cmd.Parameters.AddWithValue("@diaChi", dto.diaChi);
            cmd.Parameters.AddWithValue("@email", dto.email);
            cmd.Parameters.AddWithValue("@accFtp", dto.accFtp);
            cmd.Parameters.AddWithValue("@createBy", dto.createBy);
            cmd.Parameters.AddWithValue("@createTime", dto.createTime);
            cmd.Parameters.AddWithValue("@soTienNo", dto.soTienNo);
            cmd.Parameters.AddWithValue("@idKhachHang", dto.idKhachHang);
            cmd.ExecuteNonQuery();
        }

        public DataTable getListKhachHang(KhachHangDto dto)
        {
            String strQuery = "SELECT "
                 + " ID_KHACH_HANG"
                + ", TEN_KHACH_HANG"
                + ", DIA_CHI"
                + ", SO_TIEN_NO"
                + ", GIAM_GIA"
                + ", TEN_SALES"
                + ", GHI_CHU"
                + ", TRANG_THAI"
                + " FROM KHACH_HANG WHERE 1=1 ";
            if (StringUtils.isNotBlank(dto.idKhachHang))
            {
                strQuery += " AND ID_KHACH_HANG LIKE @idKhachHang ";
            }
            if (StringUtils.isNotBlank(dto.tenKhachHang))
            {
                strQuery += " AND TEN_KHACH_HANG LIKE @tenKhachHang ";
            }
            if (StringUtils.isNotBlank(dto.sales))
            {
                strQuery += " AND TEN_SALES LIKE @sales ";
            }
            if (dto.isSearchTrangThai)
            {
                strQuery += " AND TRANG_THAI = @trangThaiNo";
            }

            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            if (StringUtils.isNotBlank(dto.idKhachHang))
            {
                cmd.Parameters.AddWithValue("@idKhachHang", "%" + dto.idKhachHang  + "%");
            }
            if (StringUtils.isNotBlank(dto.tenKhachHang))
            {
                cmd.Parameters.AddWithValue("@tenKhachHang", "%" + dto.tenKhachHang + "%");
            }
            if (StringUtils.isNotBlank(dto.sales))
            {
                cmd.Parameters.AddWithValue("@sales", "%" + dto.sales + "%");
            }
            if (dto.isSearchTrangThai)
            {
                cmd.Parameters.AddWithValue("@trangThaiNo", dto.trangThaiNo);
            }
            
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dtTable = new DataTable();
            dtTable.Load(reader);
            reader.Close();
            return dtTable;
        }

        public KhachHangDto getKhachHangById(String id)
        {
            KhachHangDto dto = new KhachHangDto();
            String strQuery = "SELECT "
                + " TEN_KHACH_HANG"
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
                + ", SO_TIEN_NO"
                 + " FROM KHACH_HANG WHERE ID_KHACH_HANG = @id ";

            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            dto.idKhachHang = id;
            if (!reader.IsDBNull(0))    dto.tenKhachHang = reader.GetString(0);
            if (!reader.IsDBNull(1))    dto.diaChi = reader.GetString(1);
            if (!reader.IsDBNull(2))    dto.email = reader.GetString(2);
            if (!reader.IsDBNull(3))    dto.accFtp = reader.GetString(3);
            if (!reader.IsDBNull(4))    dto.giamGia = reader.GetString(4);
            if (!reader.IsDBNull(5))    dto.sales = reader.GetString(5);
            if (!reader.IsDBNull(6))    dto.salesPercent = reader.GetDecimal(6);
            if (!reader.IsDBNull(7))    dto.notes = reader.GetString(7);
            if (!reader.IsDBNull(8))    dto.startDate = reader.GetDateTime(8);
            if (!reader.IsDBNull(9))    dto.vanChuyen = reader.GetString(9);
            if (!reader.IsDBNull(10))   dto.trangThaiNo = reader.GetBoolean(10);
            if (!reader.IsDBNull(11))   dto.soTienNo = reader.GetDecimal(11);

            reader.Close();

            dto.listLienHe = getListLienHeByKhachHang(id);
            return dto;
        }

        public List<LienHeDto> getListLienHeByKhachHang(String idKhachHang)
        {
            List<LienHeDto> listLienHe = new List<LienHeDto>();
            String strQuery = ""
                + "SELECT "
                + " ID "
                + ", TEN "
                + ", SDT "
                + " FROM LIEN_HE "
                + " WHERE ID_KHACH_HANG = @idKhachHang";

            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@idKhachHang", idKhachHang);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LienHeDto lienHe = new LienHeDto();
                if (!reader.IsDBNull(0)) lienHe.id = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) lienHe.name = reader.GetString(1);
                if (!reader.IsDBNull(2)) lienHe.phone = reader.GetString(2);

                listLienHe.Add(lienHe);
            }
            reader.Close();
            return listLienHe;
        }

        public void deleteKhachHang(String id)
        {
            String strQuery = "DELETE FROM KHACH_HANG WHERE ID_KHACH_HANG = @idKhachHang";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@idKhachHang", id);
            cmd.ExecuteNonQuery();

        }
    }
}
