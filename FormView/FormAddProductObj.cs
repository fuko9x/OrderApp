using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.FormView
{
    class FormAddProductObj
    {
        public int idSanPhamCha;
        public String tenSanPhamCha;
        public int idSanPham;
        public String tenSanPham;
        public String loaiBia;
        public String size;
        public String loaiGiay;
        public Double donGia;
        public String description;

        public FormAddProductObj()
        {
            idSanPhamCha = 0;
        }
    }
}
