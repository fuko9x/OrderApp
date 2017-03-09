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
    public partial class AddOrder : MaterialForm
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            FrmConfirmOrder confirm = new FrmConfirmOrder();
            confirm.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            SearchCustomer frmSearch = new SearchCustomer();
            frmSearch.ShowDialog(this);


        }

        private void btnGetProduct_Click(object sender, EventArgs e)
        {
            SearchProduct frmSearch = new SearchProduct();
            frmSearch.ShowDialog(this);
        }
    }
}
