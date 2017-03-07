using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Common
{
    class LogicResult
    {
        public String severity;
        public String msg;
        public Object obj;

        public LogicResult(String sev, String msg, Object logicObj)
        {
            this.severity = sev;
            this.msg = msg;
            this.obj = logicObj;
        }
    }
}
