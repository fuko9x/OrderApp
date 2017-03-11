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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridViewSanPham_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSanPham.SelectedRows.Count > 0)
                {
                    int rowSelected = dataGridViewSanPham.SelectedRows[0].Index;
                    String id = dataGridViewSanPham.Rows[rowSelected].Cells["ID"].Value.ToString();
                    String name = dataGridViewSanPham.Rows[rowSelected].Cells["TEN_SAN_PHAM"].Value.ToString();
                    String size = dataGridViewSanPham.Rows[rowSelected].Cells["SIZE"].Value.ToString();
                    String dongia = dataGridViewSanPham.Rows[rowSelected].Cells["DON_GIA"].Value.ToString();

                    this.sanPhamSelected = new SanPhamDto();
                    this.sanPhamSelected.id = id;
                    this.sanPhamSelected.name = name;
                    this.sanPhamSelected.size = size;
                    this.sanPhamSelected.donGia = double.Parse(dongia);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
