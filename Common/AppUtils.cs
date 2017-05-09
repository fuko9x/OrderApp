using Microsoft.VisualBasic.FileIO;
using OrderApp.Dao;
using OrderApp.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace OrderApp.Common
{
    static class AppUtils
    {
        public static String getAppConfig(String key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static void saveAppConfig(String key, Object value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value.ToString();
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Get Current Time In Database
        /// </summary>
        /// <returns></returns>
        public static DateTime getServerTime()
        {
            return new CommonDao().getServerTime();
        }

        public static String formatNumber2Monney(Decimal monney)
        {
            return String.Format("{0:#,###}", monney);
        }

        public static Decimal formatMoney2Number(String monney, Decimal defaultNumber)
        {
            try
            {
                Regex rgx = new Regex("[^0-9]");
                String number = rgx.Replace(monney, "");
                return Decimal.Parse(number);
            }
            catch (Exception ex)
            {
                return defaultNumber;
            }
        }


        /// <summary>
        /// Tính tiền order
        /// </summary>
        /// <param name="numDefaultPage">Số trang mặc đinh (DB)</param>
        /// <param name="costDefault">Đơn giá mặc định (DB)</param>
        /// <param name="numInputPage">Số trang nhập vào (FORM)</param>
        /// <param name="costPageAdd">Số tiền mỗi trang (DB)</param>
        /// <returns></returns>
        public static Double cashProduct(int numDefaultPage, Double costDefault, int numInputPage, Double costPageAdd)
        {
            return costDefault + (numInputPage - numDefaultPage) * costPageAdd;
        }

        public static void exportOrder(String idOrder, OrderDto order)
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
                    xlWorkBook = xlApp.Workbooks.Open(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Template\\OrderTemplate.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[4, 1] = "Tên khách hàng : " + order.tenKhachHang;
                    xlWorkSheet.Cells[4, 5] = "Số Order : " + idOrder;
                    xlWorkSheet.Cells[6, 3] = "Địa chỉ : " + order.diaDiemGiaoHang;
                    xlWorkSheet.Cells[7, 1] = "Ngày đặt : " + order.ngayDat.ToString("dd/MM/yyyy");
                    xlWorkSheet.Cells[7, 4] = "Ngày đặt : " + order.ngayGiao.ToString("dd/MM/yyyy");

                    List<DonDatHangSPDto> dtProductDetail = OrderDao.getOderDetailByOrderID(idOrder);
                    
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

                    xlWorkBook.CheckCompatibility = false;
                    xlWorkBook.SaveAs(folderDialog.SelectedPath + "\\Order_" + idOrder + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);

                    MessageBox.Show("Đã export đơn hàng");
                }
            }
        }

        public static void exportDept(String idKH)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    KhachHangDto infoKH = new KhachHangDao().getKhachHangById(idKH);
                    SqlDataReader reader = new OrderDao().getDebtByCustomer(idKH);

                    Excel.Application xlApp = new Excel.Application();

                    if (xlApp == null)
                    {
                        MessageBox.Show("Excel is not properly installed!!");
                        return;
                    }


                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlWorkBook = xlApp.Workbooks.Open(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Template\\CongNoTemplate.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[8, 1] = "Tên khách hàng : " + infoKH.tenKhachHang;

                    int i = 0;
                    decimal sumChietKhau = 0;
                    decimal sumThanhTien = 0;
                    int sumSoLuong = 0;
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
                        int soLuong = reader.GetInt32(reader.GetOrdinal("SO_LUONG"));
                        decimal donGia = reader.GetDecimal(reader.GetOrdinal("DON_GIA"));
                        decimal chietKhau = donGia * reader.GetDecimal(reader.GetOrdinal("CHIET_KHAU")) / 100;
                        decimal thanhTien = reader.GetDecimal(reader.GetOrdinal("THANH_TIEN"));
                        xlWorkSheet.Cells[11, 11] = soLuong;
                        xlWorkSheet.Cells[11, 12] = donGia;
                        xlWorkSheet.Cells[11, 13] = chietKhau;
                        xlWorkSheet.Cells[11, 14] = thanhTien;
                        sumSoLuong += soLuong;
                        sumChietKhau += chietKhau;
                        sumThanhTien += thanhTien;
                        i++;
                    }

                    xlWorkSheet.Cells[13 + i, 11] = sumSoLuong;
                    xlWorkSheet.Cells[13 + i, 13] = sumChietKhau;
                    xlWorkSheet.Cells[13 + i, 14] = sumThanhTien;

                    DateTime now = DateTime.Now;
                    xlWorkSheet.Cells[15 + i, 13] = "Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                    xlWorkBook.CheckCompatibility = false;
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

        public static void exportSummaryDept(String idKH)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {

                    SqlDataReader reader = KhachHangDao.getTienNo();

                    Excel.Application xlApp = new Excel.Application();

                    if (xlApp == null)
                    {
                        MessageBox.Show("Excel is not properly installed!!");
                        return;
                    }


                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlWorkBook = xlApp.Workbooks.Open(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Template\\SummaryDeptTemplate.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    int i = 0;
                    decimal sum = 0;
                    while (reader.Read())
                    {
                        var r = xlWorkSheet.get_Range(string.Format("{0}:{0}", 10, Type.Missing));
                        var range = xlWorkSheet.get_Range(string.Format("{0}:{0}", 9, Type.Missing));
                        range.Select();
                        range.Copy();
                        r.Insert();

                        xlWorkSheet.Cells[9, 1] = reader.GetString(reader.GetOrdinal("ID_KHACH_HANG"));
                        xlWorkSheet.Cells[9, 2] = reader.GetString(reader.GetOrdinal("TEN_KHACH_HANG"));
                        Decimal soTienNo = reader.GetDecimal(reader.GetOrdinal("SO_TIEN_NO"));
                        xlWorkSheet.Cells[9, 3] = soTienNo;

                        sum += soTienNo;
                        i++;
                    }

                    xlWorkSheet.Cells[10 + i, 3] = sum;

                    xlWorkBook.CheckCompatibility = false;
                    xlWorkBook.SaveAs(folderDialog.SelectedPath + "\\TongHopCongNo.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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


        private static void exportCSV(String path, String tableName)
        {
            CommonDao commonDao = new CommonDao();
            SqlDataReader reader = commonDao.getAllData(tableName);
            StringBuilder sb = new StringBuilder();
            StreamWriter sw = new StreamWriter(path + "\\" + tableName + ".csv", false, Encoding.UTF8);

            //Get All column 
            var columnNames = Enumerable.Range(0, reader.FieldCount)
                                    .Select(reader.GetName) //OR .Select("\""+  reader.GetName"\"") 
                                    .ToList();

            //Create headers
            sb.Append(string.Join(",", columnNames));

            //Append Line
            sb.AppendLine();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string value = reader[i].ToString();
                    if (value.Contains(","))
                        value = "\"" + value + "\"";

                    sb.Append(value.Replace(Environment.NewLine, " ") + ",");
                }
                sb.Length--; // Remove the last comma
                sb.AppendLine();
            }
            sw.Write(sb.ToString());
            sw.Close();
            reader.Close();
        }

        public static void backupDatabase(String toFile)
        {
            String backupPath = toFile + "\\BACKUP" + DateTime.Now.ToString("_yyyyMMdd");
            if (Directory.Exists(backupPath))
            {
                String[] listFile = Directory.GetFiles(backupPath);
                if (listFile.Length > 0)
                {
                    foreach (String file in listFile)
                    {
                        File.Delete(file);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(backupPath);
            }
            
            try
            {
                exportCSV(backupPath, "KHACH_HANG");
                exportCSV(backupPath, "DON_DAT_HANG");
                exportCSV(backupPath, "DON_DAT_HANG_SP");
                exportCSV(backupPath, "LICH_SU_TRA_TRUOC");
                exportCSV(backupPath, "LIEN_HE");
                exportCSV(backupPath, "SAN_PHAM");
                exportCSV(backupPath, "SAN_PHAM_CHI_TIET");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Connection.closeConnection();
            }
        }

        public static void restoreDatabase(String path)
        {
            cleanDataBase();
            CommonDao commonDao = new CommonDao();
            String[]  listFile = Directory.GetFiles(path);
            foreach (String file in listFile)
            {
                DataTable data = GetDataTabletFromCSVFile(file);
                String fileName = Path.GetFileName(file);
                commonDao.insertDatabase(data, fileName.Split('.')[0]);
            }
            
        }

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return csvData;
        }

    public static void cleanDataBase()
        {
            CommonDao commonDao = new CommonDao();
            commonDao.cleanTable("KHACH_HANG");
            commonDao.cleanTable("DON_DAT_HANG");
            commonDao.cleanTable("DON_DAT_HANG_SP");
            commonDao.cleanTable("LICH_SU_TRA_TRUOC");
            commonDao.cleanTable("LIEN_HE");
            commonDao.cleanTable("SAN_PHAM");
            commonDao.cleanTable("SAN_PHAM_CHI_TIET");
        }

        public static Boolean checkMasterServer()
        {
            String server = AppUtils.getAppConfig("Server");
            String serverName = server.Split('\\')[0].Trim().ToLower();
            if (serverName == "." || serverName == "localhost" || serverName == "127.0.0.1" || serverName == getLocalIPAddress())
            {
                return true;
            }
            return false;
        }


        public static string getLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "";
        }

    }
}
