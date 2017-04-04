using MaterialSkin.Controls;
using OrderApp.Common;
using OrderApp.Dao;
using OrderApp.Dto;
using OrderApp.Logic;
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
    public partial class SearchCustomer : MaterialForm
    {
        private Boolean initData = false;
        private FormSearchCustomerObj outputObj;
        private Boolean isGetKhachHang = false;
        public KhachHangDto khachHangSelected;

        public SearchCustomer(Boolean isGetKhachHang = false)
        {
            InitializeComponent();

            formatControl();

            this.isGetKhachHang = isGetKhachHang;
            this.khachHangSelected = new KhachHangDto();
        }

        private void form_Load(object sender, EventArgs e)
        {
            initData = true;
            btnSearch.PerformClick();
        }

        private void formatControl()
        {
            this.listKhachHang = (DataGridView)FormatLayoutUtil.formatDataGridview(this.listKhachHang);
            this.listKhachHang.MouseClick += ListKhachHang_MouseClick;
        }

        private void ListKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = listKhachHang.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    this.listKhachHang.Rows[currentMouseOverRow].Selected = true;

                    ContextMenu contextMenu = new ContextMenu();
                    if(this.isGetKhachHang) contextMenu.MenuItems.Add(new MenuItem("Chọn", itemSelected_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Xem đơn đặt hàng", MenuItemXemDonHang_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Xuất công nợ", MenuItemCongno_Click));
                    contextMenu.MenuItems.Add(new MenuItem("-"));
                    contextMenu.MenuItems.Add(new MenuItem("Tạo mới", addBtn_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Chỉnh sửa", btnEdit_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Xóa", btnXoa_Click));
                    contextMenu.MenuItems.Add(new MenuItem("-"));
                    contextMenu.MenuItems.Add(new MenuItem("Đóng"));
                    contextMenu.Show(listKhachHang, new Point(e.X, e.Y));
                }
                else
                {
                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu.MenuItems.Add(new MenuItem("Tạo mới", addBtn_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Đóng"));
                    contextMenu.Show(listKhachHang, new Point(e.X, e.Y));
                }
            }
        }

        private void MenuItemXemDonHang_Click(object sender, EventArgs e)
        {
            int rowSelected = listKhachHang.SelectedRows[0].Index;
            String selectedId = listKhachHang.Rows[rowSelected].Cells["ID"].Value.ToString();

            SearchOrder frmSearchOrder = new SearchOrder();
            frmSearchOrder.setIDKhachHang(selectedId);
            frmSearchOrder.ShowDialog(this);
        }

        private void MenuItemCongno_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    int rowSelected = listKhachHang.SelectedRows[0].Index;
                    String selectedId = listKhachHang.Rows[rowSelected].Cells["ID"].Value.ToString();
                    KhachHangDto infoKH = new KhachHangDao().getKhachHangById(selectedId);
                    SqlDataReader reader = new OrderDao().getDebtByCustomer(selectedId);

                    Excel.Application xlApp = new Excel.Application();

                    if (xlApp == null)
                    {
                        MessageBox.Show("Excel is not properly installed!!");
                        return;
                    }


                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlWorkBook = xlApp.Workbooks.Open(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Template\\CongNoTemplate.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[8, 1] = "Tên khách hàng : " + infoKH.tenKhachHang;

                    int i = 0;
                    while (reader.Read())
                    {
                        var r = xlWorkSheet.get_Range(string.Format("{0}:{0}", 12, Type.Missing));
                        var range = xlWorkSheet.get_Range(string.Format("{0}:{0}", 11, Type.Missing));
                        range.Select();
                        range.Copy();
                        r.Insert();

                        xlWorkSheet.Cells[11, 1] = reader.GetDateTime(reader.GetOrdinal("NGAY_GIAO")).Day;
                        xlWorkSheet.Cells[11, 2] = reader.GetDateTime(reader.GetOrdinal("NGAY_GIAO")).Month;
                        xlWorkSheet.Cells[11, 3] = reader.GetDateTime(reader.GetOrdinal("NGAY_GIAO")).Year;
                        xlWorkSheet.Cells[11, 4] = reader.GetString(reader.GetOrdinal("ID"));
                        xlWorkSheet.Cells[11, 5] = reader.GetString(reader.GetOrdinal("TEN_SAN_PHAM"));
                        xlWorkSheet.Cells[11, 6] = reader.GetString(reader.GetOrdinal("CD_CR"));
                        xlWorkSheet.Cells[11, 7] = reader.GetString(reader.GetOrdinal("KICH_THUOC"));
                        xlWorkSheet.Cells[11, 8] = reader.GetInt32(reader.GetOrdinal("SO_TRANG"));
                        xlWorkSheet.Cells[11, 9] = reader.GetString(reader.GetOrdinal("LOAI_BIA"));
                        xlWorkSheet.Cells[11, 10] = reader.GetString(reader.GetOrdinal("LOAI_GIAY"));
                        xlWorkSheet.Cells[11, 11] = reader.GetInt32(reader.GetOrdinal("SO_LUONG"));
                        xlWorkSheet.Cells[11, 12] = reader.GetDecimal(reader.GetOrdinal("DON_GIA"));
                        xlWorkSheet.Cells[11, 13] = reader.GetDecimal(reader.GetOrdinal("CHIET_KHAU"));
                        xlWorkSheet.Cells[11, 14] = reader.GetDecimal(reader.GetOrdinal("THANH_TIEN"));
                        i++;
                    }
                    DateTime now = DateTime.Now;
                    xlWorkSheet.Cells[15 + i, 13] = "Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                    xlWorkBook.SaveAs(folderDialog.SelectedPath + "\\CongNo.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);

                    reader.Close();
                    MessageBox.Show("Đã hoàn thành export công nợ");
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                FormSearchCustomerObj frmObj = tranfersInput();
                CustomerLogic logic = new CustomerLogic();
                LogicResult result = logic.searchCustomerLogic(frmObj);
                outputObj = (FormSearchCustomerObj)result.obj;
                this.listKhachHang.DataSource = outputObj.listKhachHangs;

            } catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            
        }

        private FormSearchCustomerObj tranfersInput()
        {
            FormSearchCustomerObj obj = new FormSearchCustomerObj();
            obj.idKhachHang = StringUtils.Trim(this.idKhachHang.Text);
            obj.tenKhachHang = StringUtils.Trim(this.tenKhachHang.Text);
            //obj.trangThaiNo = this.trangthaiNo;
            return obj;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddCustomer frmAdd = new AddCustomer();
            frmAdd.ShowDialog(this);
            search_Click(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listKhachHang.SelectedRows.Count == 1)
            {
                int rowSelected = listKhachHang.SelectedRows[0].Index;
                String selectedId = listKhachHang.Rows[rowSelected].Cells["ID"].Value.ToString();
                AddCustomer frmEdit = new AddCustomer(selectedId);
                frmEdit.ShowDialog(this);
                search_Click(sender, e);
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listKhachHang.SelectedRows.Count == 1)
            {
                int rowSelected = listKhachHang.SelectedRows[0].Index;
                String selectedId = listKhachHang.Rows[rowSelected].Cells["ID"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        FormSearchCustomerObj obj = new FormSearchCustomerObj();
                        obj.idKhachHang = selectedId;
                        LogicResult logicRS = new CustomerLogic().deleteCustomerLogic(obj);

                        FormSearchCustomerObj frmObj = tranfersInput();
                        CustomerLogic logic = new CustomerLogic();
                        LogicResult searchResult = logic.searchCustomerLogic(frmObj);
                        outputObj = (FormSearchCustomerObj)searchResult.obj;
                        this.listKhachHang.DataSource = outputObj.listKhachHangs;
                        MessageBox.Show("SUCCESS: " + logicRS.msg);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                    }
                }
            }
        }



        private void itemSelected_Click(object sender, EventArgs e)
        {
            selectedKhacHang();
        }

        private void selectedKhacHang()
        {
            if (this.isGetKhachHang == false) return;
            if (listKhachHang.SelectedRows.Count > 0)
            {
                int rowSelected = listKhachHang.SelectedRows[0].Index;
                String selectedId = listKhachHang.Rows[rowSelected].Cells["ID"].Value.ToString();

                KhachHangDao khDao = new KhachHangDao();
                this.khachHangSelected = khDao.getKhachHangById(selectedId);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void listKhachHang_CellContentDoubleClick(object sender, EventArgs e)
        {
            selectedKhacHang();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
