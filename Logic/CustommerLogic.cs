using OrderApp.Common;
using OrderApp.Dao;
using OrderApp.FormView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Logic
{
    class CustommerLogic
    {
        private LogicResult result;

        public LogicResult addCustommerLogic(FormAddCustommerObj obj)
        {
            KhachHangDao khDao = new KhachHangDao();
            if (khDao.isExits(obj.idKH)) {
                return new LogicResult(Contanst.MSG_ERROR, "Da ton tai id", null);
            }
            return result;
        }
    }
}
