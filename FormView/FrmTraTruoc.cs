
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
    }
}
