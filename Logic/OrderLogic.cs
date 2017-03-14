using OrderApp.Common;
using OrderApp.Dao;
using OrderApp.Dto;
using OrderApp.FormView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Logic
{
    class OrderLogic
    {
        public String insertNewId()
        {
            DateTime systemTime = AppUtils.getServerTime();

            OrderDao orderDao = new OrderDao();
            String orderPreffix = "SX" + (systemTime.Month < 10 ? "0" + systemTime.Month.ToString() : systemTime.Month.ToString()) + systemTime.Year.ToString().Substring(2, 2);

            int numberOrder = orderDao.countOrderById(orderPreffix + "%");
            String newOrderId = orderPreffix + (numberOrder + 1).ToString().PadLeft(4, '0');
            orderDao.insertId(newOrderId);
            return newOrderId;
        }

        public LogicResult addOrder(FormAddOrderObj frmObj)
        {
            DateTime systemTime = AppUtils.getServerTime();
            OrderDto orderDto = createOrderDto(frmObj, systemTime);

            OrderDao orderDao = new OrderDao();
            String orderPreffix = "SX" + systemTime.Month + systemTime.Year.ToString().Substring(2, 2);
           
            int numberOrder = orderDao.countOrderById(orderPreffix + "%");
            String newOrderId = orderPreffix + (numberOrder + 1).ToString().PadLeft(4, '0');
            orderDto.id = newOrderId;
            orderDao.insert(orderDto);

            
            if (frmObj.listProduct.Count > 0)
            {
                List<DonDatHangSPDto> listSanPham = new List<DonDatHangSPDto>();
                foreach (SubFormProductObj item in frmObj.listProduct)
                {
                    listSanPham.Add(createDonDathangSPDto(item, systemTime));
                }
                new DonDatHangSpDao().insertList(listSanPham);
            }
            
            if (frmObj.listOtherService.Count > 0)
            {
                List<DichVuDto> listDichVu = new List<DichVuDto>();
                foreach (SubFormOtherServiceObj item in frmObj.listOtherService)
                {
                    listDichVu.Add(createDichVuDto(item, systemTime));
                }
                new DichVuDao().insertList(listDichVu);
            }

            String msg = String.Format(AppUtils.getAppConfig("MSGINFO002"), newOrderId);
            return new LogicResult(Contanst.MSG_INFO, msg, null);
        }

        private OrderDto createOrderDto(DateTime systemTime)
        {
            OrderDto dto = new OrderDto();
            dto.createTime = systemTime;
            return dto;
        }

        private OrderDto createOrderDto(FormAddOrderObj obj, DateTime systemTime)
        {
            OrderDto dto = new OrderDto();
            dto.idKhachHang = obj.idKhachHang;
            dto.ngayDat = obj.ngayDat;
            dto.ngayGiao = obj.ngayGiao;
            dto.tongCong = obj.tongCong;
            dto.tongTien = obj.tongTien;
            dto.vat = obj.vat;
            dto.phiVanChuyen = obj.phiVanChuyen;
            dto.phone = obj.phone;
            dto.notes = obj.notes;
            dto.createTime = systemTime;
            return dto;
        }

        private DonDatHangSPDto createDonDathangSPDto(SubFormProductObj obj, DateTime systemTime)
        {
            DonDatHangSPDto dto = new DonDatHangSPDto();
            dto.idOrder = obj.idOrder;
            dto.tenSanPham = obj.tenSanPham;
            dto.kichThuoc = obj.kichThuoc;
            dto.loaiBia = obj.loaiBia;
            dto.soTrang = obj.soTrang;
            dto.loaiGiay = obj.loaiGiay;
            dto.soluong = obj.soluong;
            dto.thanhTien = obj.thanhTien;
            dto.donVi = obj.donVi;
            dto.donGia = obj.donGia;
            dto.cdcr = obj.cdcr;
            dto.updateBy = obj.user;
            dto.createBy = obj.user;
            dto.createTime = systemTime;
            return dto;
        }

        private DichVuDto createDichVuDto(SubFormOtherServiceObj obj, DateTime systemTime)
        {
            DichVuDto dto = new DichVuDto();
            dto.idOrder = obj.idOrder;
            dto.tenSanPham = obj.tenSanPham;
            dto.moTa = obj.moTa;
            dto.soLuong = obj.soLuong;
            dto.donGia = obj.donGia;
            dto.thanhTien = obj.thanhTien;
            dto.createTime = systemTime;
            return dto;
        }
    }
}
