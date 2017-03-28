﻿using MaterialSkin.Controls;
using OrderApp.Common;
using OrderApp.Dao;
using OrderApp.Dto;
using OrderApp.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp.FormView
{
    public partial class OrderNew : MaterialForm
    {
        //private creatOrder
        private OrderDto orderDTO = new OrderDto();
        private readonly String formatMoney = "#,### VND";

        private bool isSaved = false;

        public OrderNew()
        {
            InitializeComponent();

            initData();
        }

        private void initData()
        {
            try
            {
                orderDTO = new OrderDto();
                orderDTO.id = OrderLogic.insertNewId();

                formatControl();
                fillData();
                updateUI();

                this.cbbLoaiSanPham.SelectedIndex = 0;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void formatControl()
        {
            this.dataGridViewSanPham = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridViewSanPham);

            this.txtThanhTien.KeyPress += FormatLayoutUtil.AcceptNumber_KeyPress;
        }

        private void fillData()
        {
            try
            {
                //fill combobox
                this.cbbLoaiSanPham.DataSource = SanPhamDao.getListSanPhamCha();
                this.cbbLoaiSanPham.ValueMember = "ID";
                this.cbbLoaiSanPham.DisplayMember = "TEN_SAN_PHAM";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }

        private void updateUI()
        {
            this.orderId.Text = orderDTO.id;
            this.dtNgayDat.Value = orderDTO.ngayDat;
            this.dtNgayGiao.Value = orderDTO.ngayGiao;

            dataGridViewSanPham.ColumnCount = 6;
            dataGridViewSanPham.Columns[0].Name = "Tên Sản Phẩm";
            dataGridViewSanPham.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewSanPham.Columns[1].Name = "Kích thước";
            dataGridViewSanPham.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewSanPham.Columns[2].Name = "Loại Giấy";
            dataGridViewSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewSanPham.Columns[3].Name = "Loại Bìa";
            dataGridViewSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewSanPham.Columns[4].Name = "Số Trang";
            dataGridViewSanPham.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewSanPham.Columns[5].Name = "Thành Tiền";
            dataGridViewSanPham.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // update gridview
            this.dataGridViewSanPham.Rows.Clear();
            double tongTien = 0;
            foreach (DonDatHangSPDto orderSP in orderDTO.listSanPham)
            {
                string[] row = new string[] {
                    orderSP.tenSanPham
                    , orderSP.kichThuoc
                    , orderSP.loaiGiay
                    , orderSP.loaiBia
                    , orderSP.soTrang.ToString()
                    , orderSP.thanhTien.ToString(formatMoney)
                };
                this.dataGridViewSanPham.Rows.Add(row);
                tongTien += orderSP.thanhTien;
            }

            orderDTO.tongCong = tongTien;
            orderDTO.vat = (tongTien * 0.1);
            orderDTO.tongTien = orderDTO.tongCong + orderDTO.vat;


            lblCong.Text = orderDTO.tongCong.ToString(formatMoney);
            lblThuevat.Text = orderDTO.vat.ToString(formatMoney); //10%
            lblTongTien.Text = tongTien.ToString(formatMoney);
        }

        private void comboBoxLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbLoaiSanPham.SelectedIndex >= 0)
                {
                    int idSanPhamCha = (int)cbbLoaiSanPham.SelectedValue;
                    DataTable dt = SanPhamDao.getListChiTiet(idSanPhamCha);

                    List<String> listSize = new List<string>();
                    List<String> listLoaiBia = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        String size = row["SIZE"].ToString();
                        if (!listSize.Contains(size))
                        {
                            listSize.Add(size);
                        }
                        String loaiBia = row["LOAI_BIA"].ToString();
                        if (!listLoaiBia.Contains(loaiBia))
                        {
                            listLoaiBia.Add(loaiBia);
                        }
                    }
                    //FILL combobox
                    cbbSize.DataSource = listSize;
                    cbbLoaiBia.DataSource = listLoaiBia;

                }
            }
            catch (Exception ex)
            {

            }
        }


        private void OrderNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (isSaved)
                {
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc hủy đơn hàng này hay không?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    //Delete Order
                    OrderDao orderDao = new OrderDao();
                    orderDao.deleteId(orderDTO.id);
                }
            }
            catch (Exception ex){}
            
        }

        private void txtThanhTien_MouseDown(object sender, MouseEventArgs e)
        {
            txtThanhTien.Text = AppUtils.formatMoney2Number(txtThanhTien.Text, 0).ToString();
        }

        private void txtThanhTien_MouseLeave(object sender, EventArgs e)
        {
            txtThanhTien.Text = AppUtils.formatNumber2Monney(AppUtils.formatMoney2Number(txtThanhTien.Text, 0));
        }

        private void btnSearchKhachHang_Click(object sender, EventArgs e)
        {
            SearchCustomer frmSearch = new SearchCustomer();
            if (frmSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.orderDTO.idKhachHang = frmSearch.khachHangSelected.idKhachHang;
                this.txtTenKhachHang.Text = frmSearch.khachHangSelected.tenKhachHang;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DonDatHangSPDto orderSP = new DonDatHangSPDto();
                orderSP.idOrder = orderDTO.id;
                orderSP.tenSanPham = cbbLoaiSanPham.Text;
                orderSP.kichThuoc = cbbSize.Text;
                orderSP.loaiBia = cbbLoaiBia.Text;
                orderSP.soTrang = (int)txtSoTo.Value;
                orderSP.thanhTien = double.Parse( txtThanhTien.Text);
                orderDTO.listSanPham.Add(orderSP);

                updateUI();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void updateDataChanged()
        {
            try
            {
                int idSanPhamCha = (int)cbbLoaiSanPham.SelectedValue;
                String size = cbbSize.Text;
                String loaibia = cbbLoaiBia.Text;
                DataTable dt = SanPhamDao.getChiTietSanPham(idSanPhamCha, size, loaibia);
                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    txtSoTo.Value = (decimal)float.Parse(row["NUM_PAGE_DEFAULT"].ToString());
                }
            }
            catch (Exception) { }
        }

        private void cbbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataChanged();
        }

        private void cbbLoaiBia_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataChanged();
        }

        private void txtSoTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idSanPhamCha = (int)cbbLoaiSanPham.SelectedValue;
                String size = cbbSize.Text;
                String loaibia = cbbLoaiBia.Text;
                DataTable dt = SanPhamDao.getChiTietSanPham(idSanPhamCha, size, loaibia);
                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    int numPageDefault = int.Parse(row["NUM_PAGE_DEFAULT"].ToString());
                    double donGia = double.Parse(row["DON_GIA"].ToString());
                    int soTo = (int) txtSoTo.Value;
                    double costPageAdd = double.Parse(row["ADDITIONAL_PAGES_COST"].ToString());
                    txtThanhTien.Text = AppUtils.cashProduct(numPageDefault, donGia, soTo, costPageAdd).ToString();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkUIvalid())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!" , "THÔNG BÁO");
                    return;
                }

                OrderDao orderDao = new OrderDao();
                orderDao.creatOrder(orderDTO);

                isSaved = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private bool checkUIvalid()
        {
            if (String.IsNullOrWhiteSpace(orderDTO.idKhachHang))
            {
                return false;
            }
            return true;
        }
    }
}
