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
    class CustomerLogic
    {
        public LogicResult addCustommerLogic(FormAddCustomerObj obj)
        {
            String msg = "";
            KhachHangDto khDto = createKhachHangDto(obj);
            KhachHangDao khDao = new KhachHangDao();
            if (khDao.isExits(khDto.idKhachHang)) {
                msg = AppUtils.getAppConfig("MSG_ERR_001").Replace("{0}", khDto.idKhachHang);
                return new LogicResult(Contanst.MSG_ERROR, msg, null);
            }

            if (obj.listContracts != null && obj.listContracts.Count > 0)
            {
                new LienHeDao().insertList(createListLienHeDto(obj));
            }
            msg = AppUtils.getAppConfig("MSG_INFO_001").Replace("{0}", khDto.idKhachHang);
            return new LogicResult(Contanst.MSG_INFO, msg, null);
        }

        private List<LienHeDto> createListLienHeDto(FormAddCustomerObj obj)
        {
            List<LienHeDto> listDto = new List<LienHeDto>();
            foreach (LienHeObj item in obj.listContracts)
            {
                LienHeDto dto = new LienHeDto();
                dto.idKhacHang = obj.idKhachHang;
                dto.name = item.name;
                dto.phone = item.phone;
                listDto.Add(dto);
            }
            return listDto;
        }

        private KhachHangDto createKhachHangDto(FormAddCustomerObj obj)
        {
            KhachHangDto dto = new KhachHangDto();
            dto.idKhachHang = obj.idKhachHang;
            dto.tenKhachHang = obj.tenKhachHang;
            dto.diaChi = obj.diaChi;
            dto.email = obj.email;
            dto.accFtp = obj.accFtp;
            dto.giamGia = obj.giamGia;
            dto.sales = obj.sales;
            dto.salesPercent = obj.salesPercent;
            dto.notes = obj.notes;
            dto.startDate = obj.startDate;
            dto.vanChuyen = obj.vanChuyen;
            dto.trangThaiXuatKho = obj.trangThaiXuatKho;
            dto.createBy = obj.user;
            dto.updateBy = obj.user;
            return dto;
        }
    }
}
