
using OrderApp.Common;
using OrderApp.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp.FormView
{
    public partial class FrmCongNoTongHop : Form
    {
        private String idKhachHang;
        public FrmCongNoTongHop()
        {
            InitializeComponent();
        }

        private void FrmCongNoTongHop_Load(object sender, EventArgs e)
        {
            formatControl();
        }

        private void formatControl()
        {
            this.dataGridView = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridView);
            //this.dataGridView.MouseClick += dataGridView;
        }

        private void loadData()
        {
            String idKhachHang = txtTenKhachHang.Text;
            OrderDao orderDao = new OrderDao();
            DataTable dt = new DataTable();
            if (!String.IsNullOrEmpty(idKhachHang))
            {
                dt.Load(orderDao.getDebtByCustomer(idKhachHang));
                this.dataGridView.DataSource = dt;
            }else
            {
                dt.Load(orderDao.getDebtByCustomer());
                this.dataGridView.DataSource = dt;
            }
        }

        private void btnSearchKhachHang_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void searchKhachHang()
        {
            SearchCustomer frmSearch = new SearchCustomer(true);
            if (frmSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.idKhachHang = frmSearch.khachHangSelected.idKhachHang;
                this.txtTenKhachHang.Text = frmSearch.khachHangSelected.idKhachHang;

                loadData();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            searchKhachHang();
        }
    }
}
