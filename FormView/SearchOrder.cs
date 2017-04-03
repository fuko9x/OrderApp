using MaterialSkin.Controls;
using OrderApp.Common;
using OrderApp.Dao;
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
    public partial class SearchOrder : MaterialForm
    {
        private Boolean initData = false;
        public SearchOrder()
        {
            initData = false;
            InitializeComponent();
            formatControl();
        }

        private void form_Load(object sender, EventArgs e)
        {
            this.initData = true;
            this.cbbTinhTrangDonHang.SelectedIndex = 0;
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
                    contextMenu.MenuItems.Add(new MenuItem("Xem chi tiết", btnDetail_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Xuất công nợ", btnExport_Click));
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
                MessageBox.Show("Export đi Bình!!!", "WARNING");
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
                    dt = dao.getListOrder(this.dateFrom.Value, this.dateTo.Value, 0, false);
                    break;
                case 1:
                    dt = dao.getListOrder(this.dateFrom.Value, this.dateTo.Value, 2, false);
                    break;
                case 2:
                    dt = dao.getListOrder(this.dateFrom.Value, this.dateTo.Value, 2, true);
                    break;
                case 3:
                    dt = dao.getListOrder(this.dateFrom.Value, this.dateTo.Value, 1, false);
                    break;
                case 4:
                    dt = dao.getListOrder(this.dateFrom.Value, this.dateTo.Value, 1, true);
                    break;
            }
            this.dataGridViewDonHang.DataSource = dt;
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
    }
}
