﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dto
{
    class KhachHangDto
    {
        public String Id;
        public String tenKhachHang;
        public String email;
        public String accFtp;
        public float giamGia;
        public String sales;
        public float salesPercent;
        public String notes;
        public DateTime startDate;
        public String ppVanChuyen;
        public Boolean trangthaixuatkho;
        public String createBy;
        public DateTime createTime;
        public String updateBy;
        public DateTime updateTime;
        public List<LienHeDto> listLienHe;
    }
}