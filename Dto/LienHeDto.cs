using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    public class LienHeDto
    {
        public int id;
        public String name;
        public String phone;
        public String idKhacHang;

        public LienHeDto()
        {
            this.name = "";
            this.phone = "";
        }

        public LienHeDto(String name, String phone, String idKhachHang = "")
        {
            this.name = name;
            this.phone = phone;
            this.idKhacHang = idKhachHang;
        }
    }
}
