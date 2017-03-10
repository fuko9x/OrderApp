using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.FormView
{
    class FormAddOrderObj
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
        public DateTime systemTime;
        public List<SubFormProductObj> listProduct;
        public List<SubFormOtherServiceObj> listOtherService;
    }
}
