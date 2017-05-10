﻿
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
            DataTable dt = new DataTable();
            if (!String.IsNullOrEmpty(idKhachHang))
            {
                dt.Load(orderDao.getDebtByCustomer(idKhachHang));
                this.dataGridView.DataSource = dt;

                // On all tables' rows
                Double total = 0;
                foreach (DataRow dtRow in dt.Rows)
                {
                    if (dtRow["TONG_TIEN"] != null)
                    {
                        total += Double.Parse(dtRow["TONG_TIEN"].ToString());
                    }
                }
                lblTongTien.Text = total.ToString("#,###");
                KhachHangDto dto = khDao.getKhachHangById(idKhachHang);
                lblSoTienNo.Text = dto.soTienNo.ToString("#,###");
            }
            else
            {
                dt.Load(orderDao.getDebtByCustomer());
                this.dataGridView.DataSource = dt;
                Double total = 0;
                foreach (DataRow dtRow in dt.Rows)
                {
                    String tongTien = dtRow["TONG_TIEN"].ToString();
                    if (!String.IsNullOrWhiteSpace(tongTien))
                    {
                        total += Double.Parse(tongTien);
                    }
                }
                lblTongTien.Text = total.ToString("#,###");
                lblSoTienNo.Text = "";
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
                            AppUtils.exportDept(txtTenKhachHang.Text, folderDialog.SelectedPath);
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
                    String path = AppUtils.createTempFolder();
                    AppUtils.exportDept(txtTenKhachHang.Text, path);
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
