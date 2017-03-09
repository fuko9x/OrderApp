﻿using System;
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
        public int tongTien;
        public int vat;
        public int tongCong;
        public int phiVanChuyen;
        public String notes;
        public String phone;
        public Boolean thanhToan;
        public String user;
    }
}
