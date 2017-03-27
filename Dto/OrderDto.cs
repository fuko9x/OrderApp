using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    public class OrderDto
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

        public OrderDto()
        {
            this.tongTien = this.vat = this.tongCong = this.phiVanChuyen = 0;
            this.ngayDat = DateTime.Now;
            this.ngayGiao = DateTime.Now.AddDays(3);
            this.createTime = DateTime.Now;
            this.listSanPham = new List<DonDatHangSPDto>();
            this.listDichVu = new List<DichVuDto>();
            this.thanhToan = false;
            this.notes = "";
        }
    }
}
