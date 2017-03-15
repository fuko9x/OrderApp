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
    class ProductLogic
    {
        public LogicResult addProduct(FormAddProductObj frmObj)
        {
            SanPhamDao dao = new SanPhamDao();
            if (frmObj.idSanPhamCha == 0)
            {
                SanPhamDto sanPhamdto = new SanPhamDto();
                sanPhamdto.nameSanPhamCha = frmObj.tenSanPhamCha;

                frmObj.idSanPhamCha = dao.insertSanPham(sanPhamdto);
            }
            dao.insertSanPhamChiTiet(createSanPhamChiTietDto(frmObj));
            return new LogicResult(Contanst.MSG_INFO, AppUtils.getAppConfig("MSGINFO003"), null);
        }

        public LogicResult updateProduct(FormAddProductObj frmObj)
        {
            SanPhamDao dao = new SanPhamDao();
            dao.updateSanPhamChiTiet(createSanPhamChiTietDto(frmObj));
            return new LogicResult(Contanst.MSG_INFO, AppUtils.getAppConfig("MSGINFO003"), null);
        }

        private SanPhamDto createSanPhamChiTietDto(FormAddProductObj frmObj)
        {
            SanPhamDto dto = new SanPhamDto();
            dto.idSanPhamCha = frmObj.idSanPhamCha;
            dto.id = frmObj.idSanPham;
            dto.name = frmObj.tenSanPham;
            dto.loaiBia = frmObj.loaiBia;
            dto.loaiGiay = frmObj.loaiGiay;
            dto.size = frmObj.size;
            dto.donGia = frmObj.donGia;
            dto.notes = frmObj.description;
            dto.numPageDefault = frmObj.numPageDefault;
            dto.addPageCost = frmObj.addPageCost;
            return dto;

        }
    }
}
