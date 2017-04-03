﻿using MaterialSkin.Controls;
using OrderApp.Dao;
using OrderApp.Dto;
using OrderApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace OrderApp.FormView
{
    public partial class OrderDetail : MaterialForm
    {

        private Boolean initData;
        private String idOrder;
        OrderDto order;

        public OrderDetail(String strOderID)
        {
            initData = false;
            InitializeComponent();
            initListView();
            this.idOrder = strOderID;
            order = OrderDao.getOderByID(this.idOrder);
        }


        private void OrderDetail_Load(object sender, EventArgs e)
        {
            loadData();
            initData = true;
        }

        private void initListView()
        {
            // Set the view to show details.
            lvProductDetail.View = View.Details;

            // Display check boxes.
            //listViewLienHe.CheckBoxes = true;

            // Select the item and subitems when selection is made.
            lvProductDetail.FullRowSelect = true;

            // Display grid lines.
            lvProductDetail.GridLines = true;

            // Attach Subitems to the ListView
            lvProductDetail.Columns.Add("Stt", 30, HorizontalAlignment.Left);
            lvProductDetail.Columns.Add("Tên sản phẩm", 120, HorizontalAlignment.Left);
            lvProductDetail.Columns.Add("SL", 50, HorizontalAlignment.Right);
            lvProductDetail.Columns.Add("Kích thước", 90, HorizontalAlignment.Left);
            lvProductDetail.Columns.Add("Số trang", 90, HorizontalAlignment.Right);
            lvProductDetail.Columns.Add("Loại bìa", 100, HorizontalAlignment.Left);
            lvProductDetail.Columns.Add("Loại giấy", 120, HorizontalAlignment.Left);
            lvProductDetail.Columns.Add("Đơn giá", 100, HorizontalAlignment.Right);
            lvProductDetail.Columns.Add("Thành tiền", 120, HorizontalAlignment.Right);
        }

        private void loadData()
        {
            try
            {
                if (order != null)
                {
                    // fill Data
                    this.lblSoOrder.Text = this.idOrder;
                    this.lblTenKhachHang.Text = order.tenKhachHang;
                    this.lblNgayGiao.Text = order.ngayGiao.ToString("dd/MM/yyyy");
                    this.lblNgayDat.Text = order.ngayDat.ToString("dd/MM/yyyy");
                    this.lblSDT.Text = order.dienThoai;
                    this.lblDiaChi.Text = order.diaDiemGiaoHang;

                    this.lblCong.Text = order.tongCong.ToString("#,### VND");
                    this.lblThueVAT.Text = order.vat.ToString("#,### VND");
                    this.lblTongTien.Text = order.tongTien.ToString("#,### VND");

                    this.ckbThanhToan.Checked = order.thanhToan;
                    this.ckbGiaoHang.Checked = order.xuatKho;
                    this.lblGhiChu.Text = order.notes;

                    List<DonDatHangSPDto> dtProductDetail = OrderDao.getOderDetailByOrderID(this.idOrder);
                    lvProductDetail.Items.Clear();
                    for (int i = 0; i < dtProductDetail.Count; i++)
                    {
                        DonDatHangSPDto orderDetail = dtProductDetail[i];
                        ListViewItem listitem = new ListViewItem((i+1).ToString());
                        listitem.SubItems.Add(orderDetail.tenSanPham);
                        listitem.SubItems.Add(orderDetail.soluong.ToString());
                        listitem.SubItems.Add(orderDetail.kichThuoc);
                        listitem.SubItems.Add(orderDetail.soTrang.ToString());
                        listitem.SubItems.Add(orderDetail.loaiBia);
                        listitem.SubItems.Add(orderDetail.loaiGiay);
                        listitem.SubItems.Add(orderDetail.donGia.ToString("#,###"));
                        listitem.SubItems.Add(orderDetail.thanhTien.ToString("#,###"));
                        lvProductDetail.Items.Add(listitem);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application xlApp = new Excel.Application();

                    if (xlApp == null)
                    {
                        MessageBox.Show("Excel is not properly installed!!");
                        return;
                    }
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlWorkBook = xlApp.Workbooks.Open(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Template\\OrderTemplate.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[4, 1] = "Tên khách hàng : " + order.tenKhachHang;
                    xlWorkSheet.Cells[4, 5] = "Số Order : " + this.idOrder;
                    xlWorkSheet.Cells[6, 3] = "Địa chỉ : " + order.diaDiemGiaoHang;
                    xlWorkSheet.Cells[7, 1] = "Ngày đặt : " + order.ngayDat.ToString("dd/MM/yyyy");
                    xlWorkSheet.Cells[7, 4] = "Ngày đặt : " + order.ngayGiao.ToString("dd/MM/yyyy");

                    List<DonDatHangSPDto> dtProductDetail = OrderDao.getOderDetailByOrderID(this.idOrder);
                    lvProductDetail.Items.Clear();
                    for (int i = 0; i < dtProductDetail.Count; i++)
                    {
                        var r = xlWorkSheet.get_Range(string.Format("{0}:{0}", 10, Type.Missing));
                        var range = xlWorkSheet.get_Range(string.Format("{0}:{0}", 9, Type.Missing));
                        range.Select();
                        range.Copy();
                        r.Insert();

                        DonDatHangSPDto orderDetail = dtProductDetail[i];
                        xlWorkSheet.Cells[9, 1] = i + 1;
                        xlWorkSheet.Cells[9, 2] = orderDetail.tenSanPham;
                        xlWorkSheet.Cells[9, 3] = orderDetail.soluong;
                        xlWorkSheet.Cells[9, 4] = orderDetail.kichThuoc;
                        xlWorkSheet.Cells[9, 5] = orderDetail.soTrang;
                        xlWorkSheet.Cells[9, 6] = orderDetail.loaiBia;
                        xlWorkSheet.Cells[9, 7] = orderDetail.loaiGiay;
                        xlWorkSheet.Cells[9, 8] = orderDetail.donGia;
                        xlWorkSheet.Cells[9, 9] = orderDetail.chietKhau + "%";
                        xlWorkSheet.Cells[9, 10] = orderDetail.thanhTien;
                    }
                    DateTime now = DateTime.Now;
                    xlWorkSheet.Cells[10 + dtProductDetail.Count, 10] = order.tongCong;
                    xlWorkSheet.Cells[11 + dtProductDetail.Count, 10] = order.vat;
                    xlWorkSheet.Cells[12 + dtProductDetail.Count, 10] = order.tongTien;

                    xlWorkBook.SaveAs(folderDialog.SelectedPath + "\\Order_" + this.idOrder + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);

                    MessageBox.Show("Đã export đơn hàng");
                }
            }   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap MemoryImage = new Bitmap(panelPrint.Width, panelPrint.Height);
            panelPrint.DrawToBitmap(MemoryImage, new Rectangle(0, 0, panelPrint.Width, panelPrint.Height));
            g.DrawImage((Image)MemoryImage, 0, 0);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (initData == false) return;
                OrderDao.capNhatThanhToan(this.idOrder, ckbThanhToan.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!!");
            }
        }

        private void ckbGiaoHang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (initData == false) return;
                OrderDao.capNhatXuatKho(this.idOrder, ckbGiaoHang.Checked);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "ERROR!!");
            }
        }
    }
}
