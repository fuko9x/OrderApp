
using OrderApp.Common;
using OrderApp.Dao;
using OrderApp.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp.FormView
{
    public partial class SearchOrder : Form
    {
        public static readonly int CONS_DON_HANG_TRONG_NGAY = 0;
        public static readonly int CONS_DON_HANG_CHUA_GIAO = 1;
        public static readonly int CONS_DON_HANG_DA_GIAO = 2;
        public static readonly int CONS_DON_HANG_CHUA_THANH_TOAN = 3;
        public static readonly int CONS_DON_HANG_DA_THANH_TOAN = 4;

        private Boolean initData = false;
        private int initSelected = 0;
        private String idKhachHang = "";

        public SearchOrder(int initSelectedType = 0)
        {
            initData = false;
            InitializeComponent();
            formatControl();
            this.initSelected = initSelectedType;
        }

        public void setIDKhachHang(String idKhachHang)
        {
            this.idKhachHang = idKhachHang;
        }

        private void form_Load(object sender, EventArgs e)
        {
            this.initData = true;
            this.cbbTinhTrangDonHang.SelectedIndex = initSelected;
            if (this.idKhachHang != "")
            {
                txtTenKhachHang.Text = this.idKhachHang;
                //loadData();
                reloadData();
            }
            else
            {
                this.cbbTinhTrangDonHang.SelectedIndex = initSelected;
                reloadData();
            }
        }

        private void formatControl()
        {
            this.dataGridViewDonHang = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridViewDonHang);
            this.dataGridViewDonHang.MouseClick += DataGridViewDonHang_MouseClick;
        }

        private void DataGridViewDonHang_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridViewDonHang.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    this.dataGridViewDonHang.Rows[currentMouseOverRow].Selected = true;

                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu.MenuItems.Add(new MenuItem("Tạo mới", btnCreate_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Chỉnh sửa", btnEdit_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Xóa đơn hàng", btnDeleteOrder_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Xem chi tiết", btnDetail_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Xuất Excel", btnExport_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Đóng"));
                    contextMenu.Show(dataGridViewDonHang, new Point(e.X, e.Y));
                }
                else
                {
                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu.MenuItems.Add(new MenuItem("Tạo mới", btnCreate_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Đóng"));
                    contextMenu.Show(dataGridViewDonHang, new Point(e.X, e.Y));
                }
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewDonHang.SelectedRows.Count > 0)
            {
                int rowSelected = this.dataGridViewDonHang.SelectedRows[0].Index;
                String selectedId = this.dataGridViewDonHang.Rows[rowSelected].Cells["ID"].Value.ToString();
                OrderDto order = OrderDao.getOderByID(selectedId);
                using (var folderDialog = new FolderBrowserDialog())
                {
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        AppUtils.exportOrder(selectedId, order, folderDialog.SelectedPath);
                        MessageBox.Show("Đã export đơn hàng");
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            OrderNew frmAdd = new OrderNew();
            frmAdd.ShowDialog(this);

            reloadData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintOrder frmPrint = new PrintOrder();
            frmPrint.ShowDialog();
        }

        private void reloadData()
        {
            if (this.initData == false) return;
            String title = cbbTinhTrangDonHang.SelectedItem.ToString();
            this.Text = title;
            this.Invalidate();

            // Search
            DataTable dt = new DataTable();
            OrderDao dao = new OrderDao();
            switch (cbbTinhTrangDonHang.SelectedIndex)
            {
                case 0:
                    dt = dao.getListOrder(this.idKhachHang, this.dateFrom.Value, this.dateTo.Value, 0, false);
                    break;
                case 1:
                    dt = dao.getListOrder(this.idKhachHang, this.dateFrom.Value, this.dateTo.Value, 2, false);
                    break;
                case 2:
                    dt = dao.getListOrder(this.idKhachHang, this.dateFrom.Value, this.dateTo.Value, 2, true);
                    break;
                case 3:
                    dt = dao.getListOrder(this.idKhachHang, this.dateFrom.Value, this.dateTo.Value, 1, false);
                    break;
                case 4:
                    dt = dao.getListOrder(this.idKhachHang, this.dateFrom.Value, this.dateTo.Value, 1, true);
                    break;
            }
            this.dataGridViewDonHang.DataSource = dt;

            // SUM MONEY IN ALL ORDER
            Decimal totalMoney = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalMoney += Decimal.Parse(row["TONG_TIEN"].ToString());
            }
            CultureInfo cul = CultureInfo.GetCultureInfo("en-US");
            this.lblSum.Text = totalMoney.ToString("#,###", cul.NumberFormat); ;
        }

        private void cbbTinhTrangDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadData();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dataGridViewDonHang.SelectedRows.Count > 0)
            {
                int rowSelected = this.dataGridViewDonHang.SelectedRows[0].Index;
                String selectedId = this.dataGridViewDonHang.Rows[rowSelected].Cells["ID"].Value.ToString();
                OrderDetail frm = new OrderDetail(selectedId);
                frm.ShowDialog(this);

                reloadData();
            }
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            reloadData();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            reloadData();
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            OrderNew frmNew = new OrderNew();
            frmNew.ShowDialog(this);
            //
            reloadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDonHang.SelectedRows.Count > 0)
                {
                    int rowSelected = this.dataGridViewDonHang.SelectedRows[0].Index;
                    String orderID = this.dataGridViewDonHang.Rows[rowSelected].Cells["ID"].Value.ToString();
                    OrderNew frmNew = new OrderNew();
                    frmNew.editOrder(orderID);
                    frmNew.ShowDialog(this);
                        
                    reloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!!!");
            }
        }


        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDonHang.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {
                        int rowSelected = this.dataGridViewDonHang.SelectedRows[0].Index;
                        String selectedId = this.dataGridViewDonHang.Rows[rowSelected].Cells["ID"].Value.ToString();

                        OrderDao dao = new OrderDao();
                        dao.deleteId(selectedId);
                        reloadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!!!");
            }
        }

        private void btnSearchKhachHang_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            String idKhachHang = txtTenKhachHang.Text;
            OrderDao dao = new OrderDao();
            if (!String.IsNullOrWhiteSpace(idKhachHang))
            {
                this.dataGridViewDonHang.DataSource = dao.searchListOrder(idKhachHang);
            }
            else
            {
                this.dataGridViewDonHang.DataSource = dao.searchListOrder();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SearchCustomer frmSearch = new SearchCustomer(true);
            if (frmSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.idKhachHang = frmSearch.khachHangSelected.idKhachHang;
                this.txtTenKhachHang.Text = frmSearch.khachHangSelected.idKhachHang;

                loadData();
            }
        }
    }
}
