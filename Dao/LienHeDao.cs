using OrderApp.Common;
using OrderApp.Dto;
using System;
using System.Collections.Generic;
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
                + ") VALUES (";
            foreach (LienHeDto item in listDto)
            {
                strQuery += "(" + item.name + ", " + item.phone + ", " + item.idKhacHang + "),";
            }
            strQuery = strQuery.Substring(0, strQuery.Length - 1);
            Connection.createSqlCommand(strQuery).ExecuteNonQuery();
        }
    }
}
