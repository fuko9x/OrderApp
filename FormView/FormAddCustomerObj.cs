using OrderApp.Dto;
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
        public List<LienHeDto> listContracts;
        public String sales;
        public Decimal salesPercent;
        public Decimal soTienNo;
        public String giamGia;
        public String vanChuyen;
        public DateTime startDate;
        public String notes;
        public Boolean trangThaiNo;
        public String user;

        public FormAddCustomerObj()
        {
            listContracts = new List<LienHeDto>();
        }
    }
}
