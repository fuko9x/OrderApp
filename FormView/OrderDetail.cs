using MaterialSkin.Controls;
using OrderApp.Dao;
using OrderApp.Dto;
using OrderApp.Properties;
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
    public partial class OrderDetail : MaterialForm
    {
        private String idOrder;
        private OrderDto orderDTO;

        public OrderDetail(String strOderID)
        {
            InitializeComponent();
            initListView();
            this.idOrder = strOderID;
        }


        private void OrderDetail_Load(object sender, EventArgs e)
        {
            loadData();
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
                DataTable dataTable = OrderDao.getOderByID(this.idOrder);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    // fill Data
                    this.lblSoOrder.Text = this.idOrder;
                    this.lblTenKhachHang.Text = dataRow["TEN_KHACH_HANG"].ToString();
                    this.lblNgayGiao.Text = dataRow["NGAY_GIAO"].ToString();
                    this.lblNgayDat.Text = dataRow["NGAY_DAT"].ToString();
                    this.lblSDT.Text = dataRow["SDT"].ToString();
                    this.lblDiaChi.Text = dataRow["DIA_DIEM_GIAO_HANG"].ToString();

                    this.lblCong.Text = dataRow["TONG_CONG"].ToString();
                    this.lblThueVAT.Text = dataRow["VAT"].ToString();
                    this.lblTongTien.Text = dataRow["TONG_TIEN"].ToString();


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
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Icon = Resources.icon;
            printPreviewDialog1.Text = "PRINT ORDER";
            printPreviewDialog1.StartPosition = FormStartPosition.CenterParent;
            printPreviewDialog1.PrintPreviewControl.AutoZoom = true;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
            printPreviewDialog1.ShowDialog();
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
    }
}
