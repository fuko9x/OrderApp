using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    public class LichSuTraTruocDto
    {
        public int ID;
        public string idKhachHang;
        public DateTime ngayTra;
        public Decimal soTien;
        public String ghiChu;

        public LichSuTraTruocDto()
        {
            ID = 0;
            soTien = 0;
            idKhachHang = "";
            ngayTra = DateTime.Now;
            ghiChu = "";
        }
    }
}
