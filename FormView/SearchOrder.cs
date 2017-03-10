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
    public partial class SearchOrder : MaterialForm
    {
        public SearchOrder()
        {
            InitializeComponent();
        }

        private void actionSearch()
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditOrder frmOrderEdit = new EditOrder();
            frmOrderEdit.ShowDialog(this);

            this.actionSearch();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            actionSearch();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AddOrder frmAdd = new AddOrder();
            frmAdd.ShowDialog(this);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintOrder frmPrint = new PrintOrder();
            frmPrint.ShowDialog();
        }
    }
}
