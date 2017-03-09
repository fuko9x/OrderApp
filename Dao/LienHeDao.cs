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
    class LienHeDao
    {
        public void insertList(List<LienHeDto> listDto)
        {
            String strQuery = "INSERT INTO LIEN_HE "
                + "("
                + "TEN"
                + ", SDT"
                + ", ID_KHACH_HANG"
                + ") VALUES ";
            for (int i = 0; i < listDto.Count; i++)
            {
                strQuery += "(@name" + i
                   + ", @phone" + i
                   + ", @idKhacHang" + i
                   + "),";
            }
            strQuery = strQuery.Substring(0, strQuery.Length - 1);
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            for (int i = 0; i < listDto.Count; i++)
            {
                cmd.Parameters.AddWithValue("@name" + i, listDto[i].name);
                cmd.Parameters.AddWithValue("@phone" + i, listDto[i].phone);
                cmd.Parameters.AddWithValue("@idKhacHang" + i, listDto[i].idKhacHang);
            }
            cmd.ExecuteNonQuery();
        }

        public List<LienHeDto> getListLienHe(String idKhachHang)
        {
            String strQuery = "SELECT TEN, SDT FROM LIEN_HE WHERE ID_KHACH_HANG = @idKhachHang";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@idKhachHang", idKhachHang);
            SqlDataReader reader = cmd.ExecuteReader();
            List<LienHeDto> listLienHeDto = new List<LienHeDto>();
            while (reader.Read())
            {
                LienHeDto dto = new LienHeDto();
                dto.name = reader.GetString(0);
                dto.phone = reader.GetString(1);
                listLienHeDto.Add(dto);
            }
            return listLienHeDto;
        }
    }  
}
