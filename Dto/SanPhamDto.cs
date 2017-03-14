using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    public class SanPhamDto
    {
        public int idSanPhamCha;
        public String nameSanPhamCha;
        public String noteSanPhamCha;
        public int id;
        public String name;
        public String size;
        public String loaiBia;
        public String loaiGiay;
        public Double donGia;
        public String notes;
        public int numPageDefault;
        public Double addPageCost;

        public SanPhamDto()
        {
            this.idSanPhamCha = 0;
            this.nameSanPhamCha = "";
            this.noteSanPhamCha = "";
            this.id = 0;
            this.name = "";
            this.size = "";
            this.loaiBia = "";
            this.loaiGiay = "";
            this.donGia = 0;
        }
    }
}
