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

namespace OrderApp.FormView
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label2.Text = System.Configuration.ConfigurationSettings.AppSettings["xxx"];

        }
    }
}
