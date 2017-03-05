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
      //     this.mainPnl.Size = new System.Drawing.Size(this.Width - 30, this.Height - 31);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connection.getConnection();
            if (con != null)
            {
                SqlDataReader reader = Connection.createSqlCommand("Select * From TEST").ExecuteReader();
                reader.Read();
                //this.label2.Text = reader.GetString(reader.GetOrdinal("column1"));
            }

        }

        private void form_Resize(object sender, EventArgs e)
        {
            this.mainPnl.Size = new System.Drawing.Size(this.Width - 58, this.Height - 162);
            this.infoPnl.Size= new System.Drawing.Size(this.mainPnl.Width - 58, this.mainPnl.Height - 162);
            this.notePnl.Size = new System.Drawing.Size(this.mainPnl.Width - 58, this.mainPnl.Height - 162);
         //   this.btnPnl.Size = new System.Drawing.Size(this.Width - 30, this.Height - 50);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
