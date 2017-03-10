using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    public class SanPhamDto
    {
        public string id;
        public String name;
        public String size;
        public String donvi;
        public double donGia;
        
        public SanPhamDto()
        {
            this.id = "";
            this.name = "";
            this.size = "";
            this.donvi = "";
            this.donGia = 0;
        }
    }
}
