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

        public int insertSanPham(SanPhamDto dto)
        {
            String strQuery = "INSERT INTO SAN_PHAM (TEN_SAN_PHAM, NOTES) VALUES ("
                + "@tenSP"
                + ", @notes )";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@tenSP", dto.name);
            cmd.Parameters.AddWithValue("@notes", dto.notes);
            int idInserted = (int)cmd.ExecuteScalar();
            return idInserted;
        }

        public void insertSanPhamChiTiet(SanPhamDto dto)
        {
            String strQuery = "INSERT INTO SAN_PHAM_CHI_TIET ("
                + "ID_SAN_PHAM"
                + ", TEN_SAN_PHAM"
                + ", LOAI_BIA" 
                + ", LOAI_GIAY"
                + ", SIZE"
                + ", DON_GIA"
                + ", DESCRIPTION"
                + ") VALUES ("
                + "@idSanPham"
                + ", @tenSP"
                + ", @loaiBia "
                + ", @loaiGiay "
                + ", @size "
                + ", @donGia "
                + ", @decription "
                + ")";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@idSanPham", dto.idSanPham);
            cmd.Parameters.AddWithValue("@tenSP", dto.name);
            cmd.Parameters.AddWithValue("@loaiBia", dto.loaiBia);
            cmd.Parameters.AddWithValue("@loaiGiay", dto.loaiGiay);
            cmd.Parameters.AddWithValue("@size", dto.size);
            cmd.Parameters.AddWithValue("@donGia", dto.donGia);
            cmd.Parameters.AddWithValue("@decription", dto.notes);
            cmd.ExecuteNonQuery();
        }
    
    }
}
