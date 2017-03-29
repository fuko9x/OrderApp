using OrderApp.Dao;
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

            int i = 1;
            while (reader.Read())
            {
                var r = xlWorkSheet.get_Range(string.Format("{0}:{0}", 11 + i, Type.Missing));
                var range = xlWorkSheet.get_Range(string.Format("{0}:{0}", 11, Type.Missing));
                range.Select();
                range.Copy();
                r.Insert();

                xlWorkSheet.Cells[11 + i - 1, 1] = reader.GetDateTime(reader.GetOrdinal("NGAY_GIAO")).Day;
                xlWorkSheet.Cells[11 + i - 1, 2] = reader.GetDateTime(reader.GetOrdinal("NGAY_GIAO")).Month;
                xlWorkSheet.Cells[11 + i - 1, 3] = reader.GetDateTime(reader.GetOrdinal("NGAY_GIAO")).Year;
                xlWorkSheet.Cells[11 + i - 1, 4] = reader.GetString(reader.GetOrdinal("ID"));
                xlWorkSheet.Cells[11 + i - 1, 5] = reader.GetString(reader.GetOrdinal("TEN_SAN_PHAM"));
                xlWorkSheet.Cells[11 + i - 1, 6] = reader.GetString(reader.GetOrdinal("CD_CR"));
                xlWorkSheet.Cells[11 + i - 1, 7] = reader.GetString(reader.GetOrdinal("KICH_THUOC"));
                xlWorkSheet.Cells[11 + i - 1, 8] = reader.GetInt32(reader.GetOrdinal("SO_TRANG"));
                xlWorkSheet.Cells[11 + i - 1, 9] = reader.GetString(reader.GetOrdinal("LOAI_BIA"));
                xlWorkSheet.Cells[11 + i - 1, 10] = reader.GetString(reader.GetOrdinal("LOAI_GIAY"));
                xlWorkSheet.Cells[11 + i - 1, 11] = reader.GetInt32(reader.GetOrdinal("SO_LUONG"));
                xlWorkSheet.Cells[11 + i - 1, 12] = reader.GetDecimal(reader.GetOrdinal("DON_GIA"));
                xlWorkSheet.Cells[11 + i - 1, 13] = reader.GetDecimal(reader.GetOrdinal("CHIET_KHAU"));
                xlWorkSheet.Cells[11 + i - 1, 14] = reader.GetDecimal(reader.GetOrdinal("THANH_TIEN"));
            }
           


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
