using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    public class DonDatHangSPDto
    {
        public int id;
        public String idOrder;
        public String tenSanPham;
        public int soluong;
        public String kichThuoc;
        public String donVi;
        public int soTrang;
        public String loaiBia;
        public String loaiGiay;
        public double donGia;
        public double thanhTien;
        public String cdcr;
        public String createBy;
        public DateTime createTime;
        public String updateBy;
        public DateTime updateTime;

        public DonDatHangSPDto()
        {
            id = 0;
            donVi = "";
            cdcr = "";
            loaiBia = "";
            loaiGiay = "";
            createBy = "";
            updateBy = "";
            createTime = DateTime.Now;
            updateTime = DateTime.Now;
        }
    }
}
