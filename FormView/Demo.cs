﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connection.getConnection();
            if (con != null)
            {
                SqlDataReader reader = Connection.createSqlCommand("Select * From TEST").ExecuteReader();
                reader.Read();
                this.label2.Text = reader.GetString(reader.GetOrdinal("column1"));
            }

        }
    }
}
