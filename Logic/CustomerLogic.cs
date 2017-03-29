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
            khDto.createTime = System.DateTime.Now;
            KhachHangDao khDao = new KhachHangDao();
            if (khDao.isExits(khDto.idKhachHang)) {
                msg = AppUtils.getAppConfig("MSGERR001").Replace("{0}", khDto.idKhachHang);
                return new LogicResult(Contanst.MSG_ERROR, msg, null);
            }

            khDao.insert(khDto);
            if (obj.listContracts != null && obj.listContracts.Count > 0)
            {
                new LienHeDao().insertList(createListLienHeDto(obj));
            }
            
            return new LogicResult(Contanst.MSG_INFO, "", null);
        }

        public LogicResult updateCustommerLogic(FormAddCustomerObj obj)
        {
            KhachHangDto khDto = createKhachHangDto(obj);
            khDto.createTime = System.DateTime.Now;
            KhachHangDao khDao = new KhachHangDao();

            khDao.update(khDto);
            LienHeDao lienHeDao = new LienHeDao();
            List<LienHeDto> listLienHeOld = lienHeDao.getListLienHe(khDto.idKhachHang);
            if (listLienHeOld.Count > 0)
            {
                lienHeDao.delete(khDto.idKhachHang);
            }
            if (obj.listContracts != null && obj.listContracts.Count > 0)
            {
                List<LienHeDto> listInsertLienHe = createListLienHeDto(obj);
                lienHeDao.insertList(listInsertLienHe);
            }
            return new LogicResult(Contanst.MSG_INFO, AppUtils.getAppConfig("MSGINFO004"), null);
        }

        public LogicResult searchCustomerLogic(FormSearchCustomerObj obj)
        {
            KhachHangDto khDto = createKhachHangDto(obj);
            KhachHangDao khDao = new KhachHangDao();
            obj.listKhachHangs = khDao.getListKhachHang(khDto);
            String msg = "";
            return new LogicResult(Contanst.MSG_INFO, msg, obj);
        }
      
        public LogicResult deleteCustomerLogic(FormSearchCustomerObj obj)
        {
            KhachHangDao khDao = new KhachHangDao();
            LienHeDao lienHeDao = new LienHeDao();
            khDao.deleteKhachHang(obj.idKhachHang);
            List<LienHeDto> listLienHeOld = lienHeDao.getListLienHe(obj.idKhachHang);
            if (listLienHeOld.Count > 0)
            {
                lienHeDao.delete(obj.idKhachHang);
            }
            return new LogicResult(Contanst.MSG_INFO, AppUtils.getAppConfig("MSGINFO005"), null);
        }
          
        private HashSet<int> createListIdLienHe(List<LienHeDto> listLienHe)
        {
            HashSet<int> rs = new HashSet<int>();
            if (listLienHe == null || listLienHe.Count == 0)
            {
                return null;
            }
            foreach (LienHeDto item in listLienHe)
            {
                rs.Add(item.id);
            }
            return rs;
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
            dto.trangThaiNo = obj.trangThaiNo;
            dto.createBy = obj.user;
            dto.updateBy = obj.user;
            return dto;
        }

        private KhachHangDto createKhachHangDto(FormSearchCustomerObj obj)
        {
            KhachHangDto dto = new KhachHangDto();
            dto.idKhachHang = obj.idKhachHang;
            dto.tenKhachHang = obj.tenKhachHang;
            dto.sales = obj.sales;
            return dto;
        }
    }
}
