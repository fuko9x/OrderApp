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

        public LogicResult addOrder(FormAddOrderObj frmObj)
        {
            OrderDto orderDto = createOrderDto(frmObj);

            DateTime serverDate = AppUtils.getServerTime();
            OrderDao orderDao = new OrderDao();
            String orderPreffix = "SX" + serverDate.Month + serverDate.Year.ToString().Substring(2, 2);
           
            int numberOrder = orderDao.countOrderById(orderPreffix + "%");
            String newOrderId = orderPreffix + (numberOrder + 1).ToString().PadLeft(4, '0');
            orderDto.id = newOrderId;
            orderDao.insert(orderDto);
            String msg = String.Format(AppUtils.getAppConfig("MSGINFO002"), newOrderId);
            return new LogicResult(Contanst.MSG_INFO, msg, null);
        }


        private OrderDto createOrderDto(FormAddOrderObj obj)
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
            return dto;
        }
    }
}
