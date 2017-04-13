using MaterialSkin.Controls;
using OrderApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp.FormView
{
    public partial class FrmMain : MaterialForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void lblThemMoi_Click(object sender, EventArgs e)
        {
            AddCustomer frmCustomer = new AddCustomer();
            frmCustomer.ShowDialog();
        }

        

        private void lblListKhachHang_Click(object sender, EventArgs e)
        {
            SearchCustomer frmSearch = new SearchCustomer();
            frmSearch.ShowDialog();
        }

        private void linkCreateOrder_Click(object sender, EventArgs e)
        {
            ///AddOrder frmOrder = new AddOrder();
            //frmOrder.ShowDialog(this);
            OrderNew frmOrder = new OrderNew();
            if (frmOrder.ShowDialog(this) == DialogResult.OK)
            {
                SearchOrder frmListOrder = new SearchOrder();
                frmListOrder.ShowDialog(this);
            }
        }

        private void linkOrderList_Click(object sender, EventArgs e)
        {
            SearchOrder frmSearch = new SearchOrder();
            frmSearch.ShowDialog(this);
        }

        private void linkAdd_Click(object sender, EventArgs e)
        {
            AddProduct frmAddProduct = new AddProduct();
            frmAddProduct.ShowDialog();
        }

        private void lblListSanPham_Click(object sender, EventArgs e)
        {
            SearchProduct frmSearch = new SearchProduct();
            frmSearch.Show();
        }

        private void lblDonHangTrongNgay_Click(object sender, EventArgs e)
        {
            SearchOrder frmOrder = new SearchOrder(SearchOrder.CONS_DON_HANG_TRONG_NGAY);
            frmOrder.ShowDialog(this);
        }

        private void lblDonHangChuaGiao_Click(object sender, EventArgs e)
        {
            SearchOrder frmOrder = new SearchOrder(SearchOrder.CONS_DON_HANG_CHUA_GIAO);
            frmOrder.ShowDialog(this);
        }

        private void lblDonHangChuaThanhToan_Click(object sender, EventArgs e)
        {
            SearchOrder frmOrder = new SearchOrder(SearchOrder.CONS_DON_HANG_CHUA_THANH_TOAN);
            frmOrder.ShowDialog(this);
        }

        private async void lblBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.SelectedPath = @"c:\";
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        DateTime dateBackup = DateTime.Now;
                        String fileBackup = folderDialog.SelectedPath + AppUtils.getAppConfig("Database") + dateBackup.ToString("_yyyyMMdd") + ".bak";
                        await BackupAsync(fileBackup);

                        MessageBox.Show("Backup success", "MESSAGE");
                    }
                }
            }
            catch (Exception ex)
            {
                showLoading(false);
                MessageBox.Show("ERROR: " + ex.Message, "ERROR");
            }
        }

        private async void lblRestoreDB_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = "backup files (*.bak)|*.bak|All files (*.*)|*.*";
                openFileDialog.Title = "Chọn file backup";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String fileRestore = openFileDialog.FileName;
                    await RestoreAsync(fileRestore);

                    MessageBox.Show("Dữ liệu đã được phục hồi", "MESSAGE");
                }
            }
            catch (Exception ex)
            {
                showLoading(false);
                MessageBox.Show("ERROR: " + ex.Message, "ERROR");
            }
        }

        private async Task BackupAsync(String toFile)
        {
            // UI-thread
            showLoading();

            // wait until task will be finished
            await Task.Run(() => {
                AppUtils.backupDatabase(toFile);
            });

            // going back to UI-thread
            showLoading(false);
        }

        private void showLoading(Boolean isLoading = true)
        {
            this.progressBarDataBase.Style = ProgressBarStyle.Marquee;
            this.progressBarDataBase.Visible = isLoading;
        }

        private async Task RestoreAsync(String fileRestore)
        {
            // UI-thread
            this.progressBarDataBase.Visible = true;
            this.progressBarDataBase.Style = ProgressBarStyle.Marquee;


            // wait until task will be finished
            await Task.Run(() => {
                AppUtils.restoreDatabase(fileRestore);
            });

            // going back to UI-thread
            this.progressBarDataBase.Visible = false;
        }

        private void linkLabelExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }


    }
}
