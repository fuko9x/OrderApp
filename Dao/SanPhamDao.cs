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
        public static DataTable getListSanPhamCha()
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT * FROM SAN_PHAM";
            SqlDataAdapter adapter = new SqlDataAdapter(strQuery, Connection.getConnection());
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable getListChiTiet()
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT * FROM SAN_PHAM_CHI_TIET";
            SqlDataAdapter adapter = new SqlDataAdapter(strQuery, Connection.getConnection());
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable getListChiTiet(int idSanPhamCha)
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT * FROM SAN_PHAM_CHI_TIET WHERE ID_SAN_PHAM = " + idSanPhamCha;
            SqlDataAdapter adapter = new SqlDataAdapter(strQuery, Connection.getConnection());
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable getChiTietSanPham(int idSanPhamCha, String size, String loaiBia)
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT * FROM SAN_PHAM_CHI_TIET "
                             + "WHERE ID_SAN_PHAM = " + idSanPhamCha
                             + " AND SIZE = @size"
                             + " AND LOAI_BIA = @loaiBia";
            SqlDataAdapter adapter = new SqlDataAdapter(strQuery, Connection.getConnection());
            adapter.SelectCommand.Parameters.AddWithValue("@size", size);
            adapter.SelectCommand.Parameters.AddWithValue("@loaiBia", loaiBia);
            adapter.Fill(dt);

            return dt;
        }

        public int insertSanPham(SanPhamDto dto)
        {
            String strQuery = "INSERT INTO SAN_PHAM (TEN_SAN_PHAM, NOTES) OUTPUT INSERTED.ID"
                + " VALUES ("
                + " @tenSP"
                + ", @notes )";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@tenSP", dto.nameSanPhamCha);
            cmd.Parameters.AddWithValue("@notes", dto.noteSanPhamCha);
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
                + ", NUM_PAGE_DEFAULT"
                + ", ADDITIONAL_PAGES_COST"
                + ") VALUES ("
                + " @idSanPhamCha"
                + ", @tenSP"
                + ", @loaiBia "
                + ", @loaiGiay "
                + ", @size "
                + ", @donGia "
                + ", @decription "
                + ", @numPageDefault "
                + ", @addPageCost "
                + ")";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@idSanPhamCha", dto.idSanPhamCha);
            cmd.Parameters.AddWithValue("@tenSP", dto.name);
            cmd.Parameters.AddWithValue("@loaiBia", dto.loaiBia);
            cmd.Parameters.AddWithValue("@loaiGiay", dto.loaiGiay);
            cmd.Parameters.AddWithValue("@size", dto.size);
            cmd.Parameters.AddWithValue("@donGia", dto.donGia);
            cmd.Parameters.AddWithValue("@decription", dto.notes);
            cmd.Parameters.AddWithValue("@numPageDefault", dto.numPageDefault);
            cmd.Parameters.AddWithValue("@addPageCost", dto.addPageCost);
            cmd.ExecuteNonQuery();
        }

        public void updateSanPhamChiTiet(SanPhamDto dto)
        {
            String strQuery = "UPDATE SAN_PHAM_CHI_TIET SET"
                + " TEN_SAN_PHAM = @tenSP"
                + ", LOAI_BIA = @loaiBia"
                + ", LOAI_GIAY = @loaiGiay"
                + ", SIZE = @size"
                + ", DON_GIA = @donGia"
                + ", DESCRIPTION = @decription"
                + ", NUM_PAGE_DEFAULT = @numPageDefault"
                + ", ADDITIONAL_PAGES_COST = @addPageCost"
                + " WHERE id = @id";

            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@id", dto.id);
            cmd.Parameters.AddWithValue("@tenSP", dto.name);
            cmd.Parameters.AddWithValue("@loaiBia", dto.loaiBia);
            cmd.Parameters.AddWithValue("@loaiGiay", dto.loaiGiay);
            cmd.Parameters.AddWithValue("@size", dto.size);
            cmd.Parameters.AddWithValue("@donGia", dto.donGia);
            cmd.Parameters.AddWithValue("@decription", dto.notes);
            cmd.Parameters.AddWithValue("@numPageDefault", dto.numPageDefault);
            cmd.Parameters.AddWithValue("@addPageCost", dto.addPageCost);
            cmd.ExecuteNonQuery();
        }
    
    }
}
