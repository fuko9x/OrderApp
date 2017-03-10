using MaterialSkin.Controls;
using OrderApp.Dto;
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

        private OrderDto orderDTO;

        public AddOrder()
        {
            InitializeComponent();

            orderDTO = new OrderDto();
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
            if(frmSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.orderDTO.idKhachHang = frmSearch.khachHangSelected.idKhachHang;
                this.idKhachHang.Text = this.orderDTO.idKhachHang;
            }
        }

        private void btnGetProduct_Click(object sender, EventArgs e)
        {
            SearchProduct frmSearch = new SearchProduct();
            if (frmSearch.ShowDialog(this) == DialogResult.OK)
            {
                SanPhamDto sanPhamDto = frmSearch.sanPhamSelected;
                this.txtSanPham.Text = sanPhamDto.name;
                this.txtSize.Text = sanPhamDto.size;
                this.txtDonGia.Text = sanPhamDto.donGia.ToString();
                //this.lblThanhTien.Text = 
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
