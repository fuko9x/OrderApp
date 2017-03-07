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
           
        }

        private void form_Resize(object sender, EventArgs e)
        {
            this.mainPnl.Size = new System.Drawing.Size(this.Width - 58, this.Height - 162);
            this.infoPnl.Size= new System.Drawing.Size(this.mainPnl.Width - 58, this.mainPnl.Height - 162);
            this.notePnl.Size = new System.Drawing.Size(this.mainPnl.Width - 58, this.mainPnl.Height - 162);
        }

        private FormAddCustommerObj tranfersInput()
        {
            FormAddCustommerObj destObj = new FormAddCustommerObj();
            destObj.tenKH = StringUtils.Trim(this.tenKH.Text);
            return destObj;
        }
    }
}
