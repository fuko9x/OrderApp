using MaterialSkin.Controls;
using OrderApp.Common;
using OrderApp.Dao;
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

            loadData();
        }

        private void loadData()
        {
            try
            {
                //load combobox
                this.comboBoxLoaiSanPham.DataSource = SanPhamDao.getList();
                this.comboBoxLoaiSanPham.ValueMember = "ID";
                this.comboBoxLoaiSanPham.DisplayMember = "TEN_SAN_PHAM";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
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
            if (this.comboBoxLoaiSanPham.SelectedIndex < 0)
            {
                obj.idSanPhamCha = 0;
                obj.tenSanPhamCha = this.comboBoxLoaiSanPham.Text;
            }
            else
            {
                obj.idSanPhamCha = (int)this.comboBoxLoaiSanPham.SelectedValue;
                obj.tenSanPhamCha = this.comboBoxLoaiSanPham.SelectedText;
            }
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
