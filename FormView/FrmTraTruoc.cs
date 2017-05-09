
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

            this.dtNgayNhap.Value = System.DateTime.Now;
        }

        private void formatControl()
        {
            this.dataGridView = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridView);
        }

        private void FrmTraTruoc_Load(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = this.idKhachHang;
            loadData();
        }

        private void loadData()
        {
            String idKhachHang = txtTenKhachHang.Text;
            if (!String.IsNullOrWhiteSpace(idKhachHang))
            {
                this.dataGridView.DataSource = LichSuTraTruocDao.getList(idKhachHang);
            }
            else
            {
                this.dataGridView.DataSource = LichSuTraTruocDao.getList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtTenKhachHang.Text))
                {
                    MessageBox.Show("Chưa chọn Khách Hàng", "MESSAGE");
                    return;
                }
                Dto.LichSuTraTruocDto lsDto = new Dto.LichSuTraTruocDto();
                lsDto.idKhachHang = txtTenKhachHang.Text;
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
            loadData();
        }


        private void searchClick()
        {
            SearchCustomer frmSearch = new SearchCustomer(true);
            if (frmSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.idKhachHang = frmSearch.khachHangSelected.idKhachHang;
                this.txtTenKhachHang.Text = frmSearch.khachHangSelected.idKhachHang;

                loadData();
            }
        }


 
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            searchClick();
        }
    }
}
