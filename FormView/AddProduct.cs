using MaterialSkin.Controls;
using OrderApp.Common;
using OrderApp.Logic;
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
    public partial class AddProduct : MaterialForm
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            FormAddProductObj frmObj = tranfersInput();
            LogicResult rs = new ProductLogic().addProduct(frmObj);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private FormAddProductObj tranfersInput()
        {
            FormAddProductObj obj = new FormAddProductObj();
            obj.tenSanPham = this.tenSanPham.Text;
            obj.loaiBia = this.loaiBia.Text;
            obj.loaiGiay = this.loaiGiay.Text;
            obj.size = this.size.Text;
            obj.description = this.description.Text;
            obj.donGia = float.Parse(this.donGia.Text);
            return obj;
        }
    }
}
