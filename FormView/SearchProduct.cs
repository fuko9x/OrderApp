using MaterialSkin.Controls;
using OrderApp.Common;
using OrderApp.Dao;
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
    public partial class SearchProduct : MaterialForm
    {

        public SanPhamDto sanPhamSelected;

        public SearchProduct()
        {
            InitializeComponent();
            formatControl();

            sanPhamSelected = new SanPhamDto();
            loadData();
        }

        private void formatControl()
        {
            this.dataGridViewSanPham = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridViewSanPham);
        }

        private void loadData()
        {
            this.dataGridViewSanPham.DataSource = SanPhamDao.getList();

            //Load combobox
            this.cbbLoaiSanPham.DataSource = SanPhamDao.getList();
            this.cbbLoaiSanPham.ValueMember = "ID";
            this.cbbLoaiSanPham.DisplayMember = "TEN_SAN_PHAM";

        }

        private void loadDataGridview(int idSanPhamCha)
        {
            this.dataGridViewSanPham.DataSource = SanPhamDao.getListChiTiet(idSanPhamCha);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void cbbLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoaiSanPham.SelectedIndex >= 0) {
                int idSanPhamCha = (int)cbbLoaiSanPham.SelectedValue;
                loadDataGridview(idSanPhamCha);
            }
        }
    }
}
