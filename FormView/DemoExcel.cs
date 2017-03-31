using OrderApp.Dao;
using OrderApp.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace OrderApp.FormView
{
    public partial class DemoExcel : Form
    {
        public DemoExcel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            KhachHangDto infoKH = new KhachHangDao().getKhachHangById("A0001");
            SqlDataReader reader = new OrderDao().getDebtByCustomer("A0001");

            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Open("E:\\template\\CongNoTemplate.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
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
                xlWorkSheet.Cells[11, 13] = reader.GetDecimal(reader.GetOrdinal("CHIET_KHAU")) ;
                xlWorkSheet.Cells[11, 14] = reader.GetDecimal(reader.GetOrdinal("THANH_TIEN"));
                i++;
            }
            DateTime now = DateTime.Now;
            xlWorkSheet.Cells[15 + i, 13] = "Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

            xlWorkBook.SaveAs("E:\\template\\CongNo.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            reader.Close();
            MessageBox.Show("Excel file created.");
        }
    }
}
