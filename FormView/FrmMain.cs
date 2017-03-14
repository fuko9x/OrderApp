using MaterialSkin.Controls;
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
    public partial class FrmMain : MaterialForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void lblThemMoi_Click(object sender, EventArgs e)
        {
            AddCustomer frmCustomer = new AddCustomer();
            frmCustomer.Show();
        }

        

        private void lblListKhachHang_Click(object sender, EventArgs e)
        {
            SearchCustomer frmSearch = new SearchCustomer();
            frmSearch.Show();
        }

        private void linkCreateOrder_Click(object sender, EventArgs e)
        {
            ///AddOrder frmOrder = new AddOrder();
            //frmOrder.ShowDialog(this);
            OrderNew frmOrder = new OrderNew();
            frmOrder.ShowDialog(this);
        }

        private void linkOrderList_Click(object sender, EventArgs e)
        {
            SearchOrder frmSearch = new SearchOrder();
            frmSearch.ShowDialog(this);
        }

        private void linkAdd_Click(object sender, EventArgs e)
        {
            AddProduct frmAddProduct = new AddProduct();
            frmAddProduct.ShowDialog();
        }

        private void lblListSanPham_Click(object sender, EventArgs e)
        {
            SearchProduct frmSearch = new SearchProduct();
            frmSearch.Show();
        }
    }
}
