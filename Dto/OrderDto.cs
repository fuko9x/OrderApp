using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    class OrderDto
    {
        public String id;
        public String idKhachHang;
        public DateTime ngayDat;
        public DateTime ngayGiao;
        public double tongTien;
        public double vat;
        public double tongCong;
        public double phiVanChuyen;
        public String notes;
        public String phone;
        public Boolean thanhToan;
        public String user;
        public DateTime createTime;
        public List<DonDatHangSPDto> listSanPham;
        public List<DichVuDto> listDichVu;
    }
}
