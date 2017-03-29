using MaterialSkin.Controls;
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
    public partial class SearchOrder : MaterialForm
    {
        public SearchOrder()
        {
            InitializeComponent();
            formatControl();
            fillData();
        }

        private void formatControl()
        {
            this.dataGridViewDonHang = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridViewDonHang);
        }

        private void fillData()
        {
            //this.dataGridViewDonHang.DataSource = OrderDao.getListOrder();
        }

        private void actionSearch()
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //EditOrder frmOrderEdit = new EditOrder();
            //frmOrderEdit.ShowDialog(this);

            this.actionSearch();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            OrderNew frmAdd = new OrderNew();
            frmAdd.ShowDialog(this);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintOrder frmPrint = new PrintOrder();
            frmPrint.ShowDialog();
        }

        private void cbbTinhTrangDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            String title = cbbTinhTrangDonHang.SelectedItem.ToString();
            this.Text = title;
            this.Invalidate();
        }
    }
}
