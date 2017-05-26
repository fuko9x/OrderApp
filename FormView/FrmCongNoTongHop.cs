
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
    public partial class FrmCongNoTongHop : Form
    {
        private String idKhachHang;
        public FrmCongNoTongHop()
        {
            InitializeComponent();
        }

        private void FrmCongNoTongHop_Load(object sender, EventArgs e)
        {
            formatControl();
        }

        private void formatControl()
        {
            this.dataGridView = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridView);
            //this.dataGridView.MouseClick += dataGridView;
        }

        private void loadData()
        {
            String idKhachHang = txtTenKhachHang.Text;
            OrderDao orderDao = new OrderDao();
            KhachHangDao khDao = new KhachHangDao();
            if(!khDao.isExits(idKhachHang))
            {
                MessageBox.Show("Mã Khách Hàng Không Tồn Tại", "MESSAGE");
                return;
            }
            DataTable dt = new DataTable();
            String dateFrom = this.dateFrom.Value.ToString("yyyy-MM-dd");
            String dateTo = this.dateTo.Value.ToString("yyyy-MM-dd");
            if (!String.IsNullOrEmpty(idKhachHang))
            {
                dt.Load(orderDao.getDebtByCustomerWithPay(dateFrom, dateTo, idKhachHang));
                this.dataGridView.DataSource = dt;

                // On all tables' rows
                if (dt.Rows.Count > 0)
                {
                    Decimal total = 0;
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        if (StringUtils.isNotBlank((String)dtRow["ID"]) && dtRow["TONG_TIEN"] != DBNull.Value)
                        {
                            total += Decimal.Parse(dtRow["TONG_TIEN"].ToString());
                        }
                    }
                    lblTongTien.Text = total.ToString("#,###");
                    Decimal soTienDaTra = LichSuTraTruocDao.getSum(idKhachHang, dateTo, dateFrom);
                    lblSoTienDaTra.Text = soTienDaTra.ToString("#,###");
                    lblSoTienNo.Text = (total - soTienDaTra).ToString("#,###");
                }
                KhachHangDto dto = khDao.getKhachHangById(idKhachHang);
                lblTongTienNo.Text = dto.soTienNo.ToString("#,###");
            }
            else
            {
                dt.Load(orderDao.getDebtByCustomer(dateFrom, dateTo));
                this.dataGridView.DataSource = dt;
                Double total = 0;
                foreach (DataRow dtRow in dt.Rows)
                {
                    if (StringUtils.isNotBlank((String)dtRow["ID"]) && dtRow["TONG_TIEN"] != DBNull.Value)
                    {
                        String tongTien = dtRow["TONG_TIEN"].ToString();
                        total += Double.Parse(tongTien);
                    }
                }
                lblTongTien.Text = total.ToString("#,###");
                lblSoTienDaTra.Text = "";
            }
        }

        private void btnSearchKhachHang_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void searchKhachHang()
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
            searchKhachHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (StringUtils.isNotBlank(txtTenKhachHang.Text))
                {
                    using (var folderDialog = new FolderBrowserDialog())
                    {
                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            String dateFrom = this.dateFrom.Value.Date.ToString("yyyy-MM-dd");
                            String dateTo = this.dateTo.Value.Date.ToString("yyyy-MM-dd");
                            AppUtils.exportDept(txtTenKhachHang.Text, folderDialog.SelectedPath, dateFrom, dateTo);
                            MessageBox.Show("Đã hoàn thành export công nợ");
                        }
                    }
                } else
                {
                    MessageBox.Show("Chưa chọn khách hàng", "MESSAGE");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR");
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (StringUtils.isNotBlank(txtTenKhachHang.Text))
            {
                try
                {
                    String dateFrom = this.dateFrom.Value.Date.ToString("yyyy-MM-dd");
                    String dateTo = this.dateTo.Value.Date.ToString("yyyy-MM-dd");
                    String path = AppUtils.createTempFolder();
                    AppUtils.exportDept(txtTenKhachHang.Text, path, dateFrom, dateTo);
                    AppUtils.printExcelFile(path + "\\CongNo.xls");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message, "ERROR");
                }
            } else
            {
                MessageBox.Show("Chưa chọn khách hàng", "MESSAGE");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
