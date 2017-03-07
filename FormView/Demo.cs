using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using OrderApp.Common;
using System.Data.SqlClient;

namespace OrderApp.FormView
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            FormAddCustommerObj formObj = tranfersInput();
        }

        private FormAddCustommerObj tranfersInput()
        {
            FormAddCustommerObj destObj = new FormAddCustommerObj();
            destObj.tenKH = StringUtils.Trim(this.tenKH.Text);
            destObj.address = StringUtils.Trim(this.diachi.Text);
            destObj.email = StringUtils.Trim(this.email.Text);
            destObj.accFtp = StringUtils.Trim(this.accFtp.Text);
            destObj.salesName = StringUtils.Trim(this.salesName.Text);
            if (this.salesPercent.Text != null)
            {
                destObj.salesPercent = float.Parse(this.salesPercent.Text);
            }
            if (this.salesPercent.Text != null)
            {
                destObj.giamGia = float.Parse(this.giamGia.Text);
            }
            destObj.vanChuyen = StringUtils.Trim(this.vanChuyen.Text);
            destObj.startDate = DateTime.ParseExact(this.ngayHopTac.Text, "dd-MM-YYYY", null);
            destObj.notes = StringUtils.Trim(this.notes.Text);
            // TODO:
            //destObj.listContracts = 
            return destObj;
        }
    }
}
