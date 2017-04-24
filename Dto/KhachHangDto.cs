using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    public class KhachHangDto
    {
        public String id;
        public String idKhachHang;
        public String tenKhachHang;
        public String diaChi;
        public String email;
        public String accFtp;
        public String giamGia;
        public String sales;
        public Decimal salesPercent;
        public Decimal soTienNo;
        public String notes;
        public DateTime startDate;
        public String vanChuyen;
        public Boolean trangThaiNo;
        public String createBy;
        public DateTime createTime;
        public String updateBy;
        public DateTime updateTime;
        public List<LienHeDto> listLienHe;

        // mode search trangThaiNo
        public Boolean isSearchTrangThai;

        public KhachHangDto()
        {
            soTienNo = 0;
            salesPercent = 0;
        }
    }
}
