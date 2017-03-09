using OrderApp.FormView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.FormView
{
    public class FormAddCustomerObj
    {
        public String idKhachHang;
        public String tenKhachHang;
        public String diaChi;
        public String email;
        public String accFtp;
        public List<LienHeObj> listContracts;
        public String sales;
        public float salesPercent;
        public float giamGia;
        public String vanChuyen;
        public DateTime startDate;
        public String notes;
        public Boolean trangThaiNo;
        public String user;
    }
}
