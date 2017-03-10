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
    class DichVuDao
    {
        public void insertList(List<DichVuDto> listDto)
        {
            String strQuery = "INSERT INTO DON_DAT_HANG_DICH_VU "
                + "( "
                + "ID_DON_DAT_HANG"
                + ", TEN_SAN_PHAM"
                + ", MO_TA"
                + ", DON_GIA"
                + ", THANH_TIEN"
                + ", SO_LUONG"
                + ", CREATE_BY"
                + ", CREATE_TIME"
                + ") VALUES ";
            for (int i = 0; i < listDto.Count; i++)
            {
                strQuery += "(@idOrder" + i
                    + ", @moTa" + i
                    + ", @donGia" + i
                    + ", @thanhTien" + i
                    + ", @soLuong" + i
                    + ", @createBy" + i
                    + "SYSDATETIME()"
                    + "), ";
            }
            strQuery = strQuery.Substring(0, strQuery.Length - 1);
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            for (int i = 0; i < listDto.Count; i++)
            {
                cmd.Parameters.AddWithValue("@idOrder" + i, listDto[i].idOrder);
                cmd.Parameters.AddWithValue("@moTa" + i, listDto[i].moTa);
                cmd.Parameters.AddWithValue("@donGia" + i, listDto[i].donGia);
                cmd.Parameters.AddWithValue("@thanhTien" + i, listDto[i].thanhTien);
                cmd.Parameters.AddWithValue("@soLuong" + i, listDto[i].soLuong);
                cmd.Parameters.AddWithValue("@createBy" + i, listDto[i].createBy);
            }
            cmd.ExecuteNonQuery();
        }
    }
}
