
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
    public partial class FrmTraTruoc : Form
    {
        private String idKhachHang = "";

        public FrmTraTruoc(String idKhachHang)
        {
            this.idKhachHang = idKhachHang;

            InitializeComponent();

            formatControl();
        }

        private void formatControl()
        {
            this.dataGridView = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridView);
        }

        private void FrmTraTruoc_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            this.dataGridView.DataSource = LichSuTraTruocDao.getList(this.idKhachHang);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Dto.LichSuTraTruocDto lsDto = new Dto.LichSuTraTruocDto();
                lsDto.idKhachHang = this.idKhachHang;
                lsDto.soTien = Decimal.Parse(txtSoTien.Text);
                lsDto.ngayTra = dtNgayNhap.Value;
                lsDto.ghiChu = txtGhiChu.Text;
                LichSuTraTruocDao.insert(lsDto);

                KhachHangDao.giamSoTienNo(this.idKhachHang, lsDto.soTien);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!!!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchKhachHang_Click(object sender, EventArgs e)
        {
            searchClick();
        }

        private void txtTenKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            searchClick();
        }

        private void searchClick()
        {
            SearchCustomer frmSearch = new SearchCustomer(true);
            if (frmSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.idKhachHang = frmSearch.khachHangSelected.idKhachHang;
                this.txtTenKhachHang.Text = frmSearch.khachHangSelected.tenKhachHang;

                loadData();
            }
        }

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
