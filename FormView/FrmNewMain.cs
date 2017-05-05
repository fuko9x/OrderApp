using OrderApp.Common;
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
    public partial class FrmNewMain : Form
    {
        public FrmNewMain()
        {
            InitializeComponent();
        }

        private void FrmNewMain_Load(object sender, EventArgs e)
        {

        }

        #region "DANH MỤC"

        private void DM_KhachHang_NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer frmCustomer = new AddCustomer();
            frmCustomer.ShowDialog(this);
        }

        private void DM_KhachHang_ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchCustomer frmSearch = new SearchCustomer();
            frmSearch.ShowDialog(this);
        }

        private void DM_SanPham_ThemMoiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddProduct frmAddProduct = new AddProduct();
            frmAddProduct.ShowDialog(this);
        }

        private void DM_SanPham_ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchProduct frmSearch = new SearchProduct();
            frmSearch.Show();
        }

        #endregion "DANH MỤC"

        #region "NGHIỆP VỤ"

        private void NV_DatHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderNew frmOrder = new OrderNew();
            frmOrder.ShowDialog(this);
        }

        private void NV_ThuTienToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region "THONG KE"

        private void TK_DonHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchOrder frmOrder = new SearchOrder(SearchOrder.CONS_DON_HANG_TRONG_NGAY);
            frmOrder.ShowDialog(this);
        }

        private void TK_CongNoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private async void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String ip = AppUtils.getLocalIPAddress();
                if (AppUtils.checkMasterServer())
                {
                    using (var folderDialog = new FolderBrowserDialog())
                    {
                        folderDialog.SelectedPath = @"c:\";
                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            DateTime dateBackup = DateTime.Now;
                            String fileBackup = folderDialog.SelectedPath;
                            await BackupAsync(fileBackup);

                            MessageBox.Show("Backup success", "MESSAGE");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                showLoading(false);
                MessageBox.Show("ERROR: " + ex.Message, "ERROR");
            }
        }

        private async void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppUtils.checkMasterServer())
                {
                    return;
                }
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.SelectedPath = @"c:\";
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        String folderCSV = folderDialog.SelectedPath;
                        await RestoreAsync(folderCSV);
                        MessageBox.Show("Dữ liệu đã được phục hồi", "MESSAGE");
                    }
                }
            }
            catch (Exception ex)
            {
                showLoading(false);
                MessageBox.Show("ERROR: " + ex.Message, "ERROR");
            }
        }


        private void showLoading(Boolean isLoading = true)
        {
            this.progressBarMain.Style = ProgressBarStyle.Marquee;
            this.progressBarMain.Visible = isLoading;
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



        private async Task RestoreAsync(String fileRestore)
        {
            // UI-thread
            showLoading(true);


            // wait until task will be finished
            await Task.Run(() => {
                AppUtils.restoreDatabase(fileRestore);
            });

            // going back to UI-thread
            showLoading(false);
        }



        private void panelTaoDonHang_MouseClick(object sender, MouseEventArgs e)
        {
            OrderNew frmOrder = new OrderNew();
            frmOrder.ShowDialog(this);
        }

        private void panelThuTien_MouseClick(object sender, MouseEventArgs e)
        {
            String idKhachHang = "";
            FrmTraTruoc frmTraTruoc = new FrmTraTruoc(idKhachHang);
            frmTraTruoc.ShowDialog(this);
        }

        private void linkCreateOrder_Click(object sender, EventArgs e)
        {
            OrderNew frmOrder = new OrderNew();
            frmOrder.ShowDialog(this);
        }

        private void linkThuTien_Click(object sender, EventArgs e)
        {
            String idKhachHang = "";
            FrmTraTruoc frmTraTruoc = new FrmTraTruoc(idKhachHang);
            frmTraTruoc.ShowDialog(this);
        }
    }
}
