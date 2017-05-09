using OrderApp.Common;
using OrderApp.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp.FormView
{
    public partial class FrmKhachHangNoTien : Form
    {
        public FrmKhachHangNoTien()
        {
            InitializeComponent();
            formatControl();
        }

        private void formatControl()
        {
            this.dataGridViewMain = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridViewMain);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void FrmKhachHangNoTien_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = KhachHangDao.getTienNo();
            DataTable dtTable = new DataTable();
            dtTable.Load(reader);
            this.dataGridViewMain.DataSource = dtTable;
        }
    }
}
