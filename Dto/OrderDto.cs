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
        public String tenKhachHang;
        public DateTime ngayDat;
        public DateTime ngayGiao;
        public String lienHe;
        public String dienThoai;
        public String diaDiemGiaoHang;
        public double tongTien;
        public double vat;
        public double tongCong;
        public double phiVanChuyen;
        public String notes;
        public Boolean thanhToan;
        public Boolean xuatKho;
        public String user;
        public DateTime createTime;
        public List<DonDatHangSPDto> listSanPham;
        public List<DichVuDto> listDichVu;

        public OrderDto()
        {
            this.tongTien = this.vat = this.tongCong = this.phiVanChuyen = 0;
            this.ngayDat = DateTime.Now;
            this.ngayGiao = DateTime.Now.AddDays(3);
            this.tenKhachHang = "";
            this.lienHe = "";
            this.dienThoai = "";
            this.diaDiemGiaoHang = "";
            this.user = "";
            this.createTime = DateTime.Now;
            this.listSanPham = new List<DonDatHangSPDto>();
            this.listDichVu = new List<DichVuDto>();
            this.thanhToan = false;
            this.xuatKho = false;
            this.notes = "";
        }
    }
}
