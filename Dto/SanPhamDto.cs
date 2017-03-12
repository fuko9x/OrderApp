using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    public class SanPhamDto
    {
        public int idSanPham;
        public String name;
        public String size;
        public String loaiBia;
        public String loaiGiay;
        public double donGia;
        public String notes;

        public SanPhamDto(String tenSP, String notes)
        {
            this.name = tenSP;
            this.notes = notes;
        }
        public SanPhamDto()
        {
            this.idSanPham = 0;
            this.name = "";
            this.size = "";
            this.loaiBia = "";
            this.loaiGiay = "";
            this.donGia = 0;
        }
    }
}
