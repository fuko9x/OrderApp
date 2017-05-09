
using OrderApp.Common;
using OrderApp.Dao;
using OrderApp.Dto;
using OrderApp.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp.FormView
{
    public partial class OrderNew : Form
    {

        public static readonly int CONS_MODE_ADD = 0;
        public static readonly int CONS_MODE_EDIT = 1;

        private Boolean initData = false;
        //private creatOrder
        private OrderDto orderDTO = new OrderDto();
        private readonly String formatMoney = "#,###";
        private readonly String formatMoneyVND = "#,### VND";

        private bool isSaved = false;

        private int currentMode = CONS_MODE_ADD;

        public OrderNew()
        {
            InitializeComponent();
        }

        public void editOrder(String idOrder)
        {
            this.orderDTO = OrderDao.getOderByID(idOrder);
            this.currentMode = CONS_MODE_EDIT;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            initDataAction();
            cbbLoaiSanPham.Text = "";
            this.initData = true;
        }

        private void TxtTenKhachHang_Click(object sender, EventArgs e)
        {
            btnSearchKhachHang_Click(sender, e);
        }

        private void setSetForm()
        {
            errorProvider.Clear();
            cbbSize.Text = "";
            cbbLoaiGiay.Text = "";
            cbbLoaiBia.Text = "";

            txtSoTo.Value = 10;
            txtTenCDCR.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Value = txtSoLuong.Minimum;
            txtChietKhau.Value = txtChietKhau.Minimum;
            txtThanhTien.Text = "";
        }

        private void initDataAction()
        {
            try
            {
                if(currentMode == CONS_MODE_ADD)
                {
                    orderDTO = new OrderDto();
                    orderDTO.id = OrderLogic.insertNewId();
                    this.Text = "TẠO ĐƠN HÀNG #: " + orderDTO.id;
                }
                if (currentMode == CONS_MODE_EDIT)
                {
                    this.Text = "CẬP NHẬT ĐƠN HÀNG #: " + orderDTO.id;
                    this.orderDTO.listSanPham = OrderDao.getOderDetailByOrderID(orderDTO.id);
                }

                //this.orderDTO.idKhachHang = frmSearch.khachHangSelected.idKhachHang;
                this.txtTenKhachHang.Text = this.orderDTO.tenKhachHang;
                this.txtDiaDiemGiaoHang.Text = this.orderDTO.diaDiemGiaoHang;
                this.txtLienHe.Text = this.orderDTO.lienHe;
                this.txtSDT.Text = this.orderDTO.dienThoai;

                this.dtNgayDat.Value = this.orderDTO.ngayDat;
                this.dtNgayGiao.Value = this.orderDTO.ngayGiao;
                this.txtGhiChu.Text = this.orderDTO.notes;

                if(orderDTO.tongCong != 0)
                {
                    this.numberVAT.Value = (decimal)(orderDTO.vat / orderDTO.tongCong) * 100;
                }
                else
                {
                    this.numberVAT.Value = 0;
                }
                

                formatControl();
                fillData();
                updateUI();

                this.cbbLoaiSanPham.SelectedIndex = 0;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void formatControl()
        {
            this.dataGridViewSanPham = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridViewSanPham);
            this.dataGridViewSanPham.MouseClick += DataGridViewSanPham_MouseClick;

            dataGridViewSanPham.ColumnCount = 10;
            dataGridViewSanPham.Columns[0].Name = "Tên Sản Phẩm";
            dataGridViewSanPham.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSanPham.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSanPham.Columns[1].Name = "Kích thước";
            dataGridViewSanPham.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSanPham.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSanPham.Columns[2].Name = "Loại Giấy";
            dataGridViewSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSanPham.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSanPham.Columns[3].Name = "Loại Bìa";
            dataGridViewSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSanPham.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSanPham.Columns[4].Name = "Tên CD & CR";
            dataGridViewSanPham.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSanPham.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSanPham.Columns[5].Name = "Số Trang";
            dataGridViewSanPham.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSanPham.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSanPham.Columns[6].Name = "Đơn Giá";
            dataGridViewSanPham.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSanPham.Columns[7].Name = "Số Lượng";
            dataGridViewSanPham.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSanPham.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSanPham.Columns[8].Name = "Chiết Khấu";
            dataGridViewSanPham.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSanPham.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSanPham.Columns[9].Name = "Thành Tiền";
            dataGridViewSanPham.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;


            this.txtDonGia.KeyPress += FormatLayoutUtil.AcceptNumber_KeyPress;
            txtTenKhachHang.Click += TxtTenKhachHang_Click;
        }

        private void DataGridViewSanPham_MouseClick(object sender, MouseEventArgs e)
        {
            this.btnUpdate.Enabled = false;
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridViewSanPham.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    this.dataGridViewSanPham.Rows[currentMouseOverRow].Selected = true;
                    
                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu.MenuItems.Add(new MenuItem("Edit", contextItemClick));
                    contextMenu.MenuItems.Add(new MenuItem("Delete", contextItemClick));
                    contextMenu.MenuItems.Add(new MenuItem("Close"));
                    contextMenu.Show(dataGridViewSanPham, new Point(e.X, e.Y));
                }
            }
        }

        protected void contextItemClick(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            if (item.Text == "Edit")
            {
                int selectedRow = this.dataGridViewSanPham.SelectedRows[0].Index;
                DonDatHangSPDto orderSP = this.orderDTO.listSanPham[selectedRow];
                cbbLoaiSanPham.Text = orderSP.tenSanPham;
                cbbSize.Text = orderSP.kichThuoc;
                cbbLoaiBia.Text = orderSP.loaiBia;
                cbbLoaiGiay.Text = orderSP.loaiGiay;
                txtSoTo.Value = orderSP.soTrang;
                txtDonGia.Text = orderSP.donGia.ToString();
                txtSoLuong.Value = orderSP.soluong;
                txtChietKhau.Value = (decimal)orderSP.chietKhau;
                txtTenCDCR.Text = orderSP.cdcr;

                this.btnUpdate.Enabled = true;
            }
            if (item.Text == "Delete")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int selectedRow = this.dataGridViewSanPham.SelectedRows[0].Index;
                    this.orderDTO.listSanPham.RemoveAt(selectedRow);

                    updateUI();
                }
            }
        }

        private void fillData()
        {
            try
            {
                //fill combobox
                this.cbbLoaiSanPham.DataSource = SanPhamDao.getListSanPhamCha();
                this.cbbLoaiSanPham.ValueMember = "ID";
                this.cbbLoaiSanPham.DisplayMember = "TEN_SAN_PHAM";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }

        private void updateUI()
        {
            this.orderId.Text = orderDTO.id;
            this.dtNgayDat.Value = orderDTO.ngayDat;
            this.dtNgayGiao.Value = orderDTO.ngayGiao;

            // update gridview
            this.dataGridViewSanPham.Rows.Clear();
            double tongTien = 0;
            foreach (DonDatHangSPDto orderSP in orderDTO.listSanPham)
            {
                string[] row = new string[] {
                    orderSP.tenSanPham
                    , orderSP.kichThuoc
                    , orderSP.loaiGiay
                    , orderSP.loaiBia
                    , orderSP.cdcr
                    , orderSP.soTrang.ToString()
                    , orderSP.donGia.ToString(formatMoney)
                    , orderSP.soluong.ToString()
                    , orderSP.chietKhau.ToString() + " %"
                    , orderSP.thanhTien.ToString(formatMoney)
                };
                this.dataGridViewSanPham.Rows.Add(row);
                tongTien += orderSP.thanhTien;
            }

            orderDTO.tongCong = tongTien;
            orderDTO.vat = (double)numberVAT.Value;
            double vat = tongTien * ((double)numberVAT.Value / 100);
            orderDTO.tongTien = orderDTO.tongCong + vat;


            lblCong.Text = orderDTO.tongCong.ToString(formatMoneyVND);
            lblThuevat.Text = vat.ToString(formatMoneyVND);
            lblTongTien.Text = orderDTO.tongTien.ToString(formatMoneyVND);

            this.btnUpdate.Enabled = false;
        }

        private void comboBoxLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.initData == false) return;

                cbbSize.DataSource = null;
                cbbLoaiBia.DataSource = null;
                cbbLoaiGiay.DataSource = null;

                setSetForm();

                if (cbbLoaiSanPham.SelectedIndex >= 0)
                {
                    int idSanPhamCha = (int)cbbLoaiSanPham.SelectedValue;
                    DataTable dt = SanPhamDao.getListChiTiet(idSanPhamCha);

                    List<String> listSize = new List<string>();
                    List<String> listLoaiBia = new List<string>();
                    List<String> listLoaiGiay = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        String size = row["SIZE"].ToString().Trim();
                        if (!listSize.Contains(size))
                        {
                            listSize.Add(size);
                        }
                        String loaiBia = row["LOAI_BIA"].ToString().Trim();
                        if (!listLoaiBia.Contains(loaiBia))
                        {
                            listLoaiBia.Add(loaiBia);
                        }
                        String loaiGiay = row["LOAI_GIAY"].ToString().Trim();
                        if (!listLoaiGiay.Contains(loaiGiay))
                        {
                            listLoaiGiay.Add(loaiGiay);
                        }
                    }
                    //FILL combobox
                    cbbSize.DataSource = listSize;
                    cbbLoaiBia.DataSource = listLoaiBia;
                    cbbLoaiGiay.DataSource = listLoaiGiay;
                }
            }
            catch (Exception){}
        }


        private void OrderNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (isSaved)
                {
                    return;
                }

                if (this.currentMode == CONS_MODE_ADD)
                {

                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc hủy đơn hàng này hay không?"
                        , "Confirmation"
                        , MessageBoxButtons.YesNo
                    );
                    if (result != DialogResult.Yes)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        //Delete Order
                        OrderDao orderDao = new OrderDao();
                        orderDao.deleteId(orderDTO.id);

                        this.DialogResult = DialogResult.Cancel;
                    }

                }
            }
            catch (Exception ex){}
            
        }

        private void txtThanhTien_MouseDown(object sender, MouseEventArgs e)
        {
            txtDonGia.Text = AppUtils.formatMoney2Number(txtDonGia.Text, 0).ToString();
        }

        private void txtThanhTien_MouseLeave(object sender, EventArgs e)
        {
            txtDonGia.Text = AppUtils.formatNumber2Monney(AppUtils.formatMoney2Number(txtDonGia.Text, 0));
        }

        private void btnSearchKhachHang_Click(object sender, EventArgs e)
        {
            
        }

        private void browseKhachHang()
        {
            SearchCustomer frmSearch = new SearchCustomer(true);
            if (frmSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.orderDTO.idKhachHang = frmSearch.khachHangSelected.idKhachHang;
                this.txtTenKhachHang.Text = frmSearch.khachHangSelected.tenKhachHang;
                this.txtDiaDiemGiaoHang.Text = frmSearch.khachHangSelected.diaChi;
                if (frmSearch.khachHangSelected.listLienHe.Count > 0)
                {
                    this.txtLienHe.Text = frmSearch.khachHangSelected.listLienHe[0].name;
                    this.txtSDT.Text = frmSearch.khachHangSelected.listLienHe[0].phone;
                }
                else
                {
                    this.txtLienHe.Text = "";
                    this.txtSDT.Text = "";
                }
            }
        }

        private Boolean checkValidDatHang()
        {
            Boolean isValid = true;
            List<Control> listRequited = new List<Control>()
            {
                cbbLoaiSanPham
                , txtDonGia
            };
            foreach (Control control in listRequited)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)control;
                    if (String.IsNullOrWhiteSpace(textBox.Text))
                    {
                        isValid = false;
                        errorProvider.SetError(textBox, "Vui lòng nhập giá trị");
                    }
                    else
                        errorProvider.SetError(textBox, String.Empty);
                }
                if (control.GetType() == typeof(ComboBox))
                {
                    ComboBox cbb = (ComboBox)control;
                    if (String.IsNullOrWhiteSpace(cbb.Text))
                    {
                        isValid = false;
                        errorProvider.SetError(cbb, "Vui lòng chọn hoặc nhập giá trị");
                    }
                    else
                        errorProvider.SetError(cbb, String.Empty);
                }
            }
            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkValidDatHang())
                {
                    DonDatHangSPDto orderSP = new DonDatHangSPDto();
                    orderSP.idOrder = orderDTO.id;
                    orderSP.tenSanPham = cbbLoaiSanPham.Text;
                    orderSP.kichThuoc = cbbSize.Text;
                    orderSP.loaiBia = cbbLoaiBia.Text;
                    orderSP.loaiGiay = cbbLoaiGiay.Text;
                    orderSP.soTrang = (int)txtSoTo.Value;
                    orderSP.donGia = double.Parse(txtDonGia.Text);
                    orderSP.soluong = (int)txtSoLuong.Value;
                    orderSP.chietKhau = (int)txtChietKhau.Value;
                    orderSP.thanhTien = orderSP.donGia * orderSP.soluong;
                    orderSP.thanhTien = orderSP.thanhTien - (orderSP.chietKhau / 100 * orderSP.thanhTien);
                    orderSP.cdcr = txtTenCDCR.Text;
                    orderDTO.listSanPham.Add(orderSP);

                    updateUI();

                    setSetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!!!");
            }
        }

        private void updateDataChanged()
        {
            try
            {
                if (this.initData == false) return;

                txtSoTo.Value = 10;
                txtDonGia.Text = "";
                txtSoLuong.Value = txtSoLuong.Minimum;
                txtChietKhau.Value = txtChietKhau.Minimum;
                txtThanhTien.Text = "";

                int idSanPhamCha = (int)cbbLoaiSanPham.SelectedValue;
                String size = cbbSize.Text;
                String loaiBia = cbbLoaiBia.Text;
                String loaiGiay = cbbLoaiGiay.Text;
                DataTable dt = SanPhamDao.getChiTietSanPham(idSanPhamCha, size, loaiBia, loaiGiay);
                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    int numPageDefault = int.Parse(row["NUM_PAGE_DEFAULT"].ToString());
                    double donGiaDefault = double.Parse(row["DON_GIA"].ToString());
                    int soTo = (int)txtSoTo.Value;
                    double costPageAdd = double.Parse(row["ADDITIONAL_PAGES_COST"].ToString());
                    double donGia = AppUtils.cashProduct(numPageDefault, donGiaDefault, soTo, costPageAdd);

                    txtDonGia.Text = donGia.ToString();
                    txtThanhTien.Text = (donGia * (double)txtSoLuong.Value).ToString("#,###");
                }
            }
            catch (Exception) { }
        }

        private void cbbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataChanged();
        }

        private void cbbLoaiBia_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataChanged();
        }

        private void cbbLoaiGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataChanged();
        }

        private void txtSoTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idSanPhamCha = (int)cbbLoaiSanPham.SelectedValue;
                String size = cbbSize.Text;
                String loaiBia = cbbLoaiBia.Text;
                String loaiGiay = cbbLoaiGiay.Text;
                DataTable dt = SanPhamDao.getChiTietSanPham(idSanPhamCha, size, loaiBia, loaiGiay);
                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    int numPageDefault = int.Parse(row["NUM_PAGE_DEFAULT"].ToString());
                    double donGiaDefault = double.Parse(row["DON_GIA"].ToString());
                    int soTo = (int) txtSoTo.Value;
                    double costPageAdd = double.Parse(row["ADDITIONAL_PAGES_COST"].ToString());
                    double donGia = AppUtils.cashProduct(numPageDefault, donGiaDefault, soTo, costPageAdd);

                    txtDonGia.Text = donGia.ToString();
                    txtThanhTien.Text = (donGia * (double)txtSoLuong.Value).ToString() ;
                }
            }
            catch (Exception ex) {
                //MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void txtSoLuong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtDonGia.Text))
                {
                    txtDonGia.Focus();
                    return;
                }
                Decimal thanhTien = decimal.Parse(txtDonGia.Text) * txtSoLuong.Value;
                Decimal chietKhau = (txtChietKhau.Value / 100) * thanhTien;
                
                txtThanhTien.Text = (thanhTien - chietKhau).ToString("#,###");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void txtChietKhau_ValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDonGia.Text))
            {
                txtDonGia.Focus();
                return;
            }
            Decimal thanhTien = decimal.Parse(txtDonGia.Text) * txtSoLuong.Value;
            Decimal chietKhau = (txtChietKhau.Value / 100) * thanhTien;

            txtThanhTien.Text = (thanhTien - chietKhau).ToString("#,###");
        }

        private void SaveAction()
        {
            orderDTO.lienHe = txtLienHe.Text.Trim();
            orderDTO.dienThoai = txtSDT.Text.Trim();
            orderDTO.diaDiemGiaoHang = txtDiaDiemGiaoHang.Text.Trim();
            orderDTO.ngayDat = dtNgayDat.Value;
            orderDTO.ngayGiao = dtNgayGiao.Value;
            //orderDTO.thanhToan = false;
            orderDTO.notes = txtGhiChu.Text.Trim();

            OrderDao orderDao = new OrderDao();
            if (this.currentMode == CONS_MODE_ADD)
            {
                orderDao.creatOrder(orderDTO);
            }
            else if (this.currentMode == CONS_MODE_EDIT)
            {
                orderDao.updateOrder(orderDTO);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkUIvalid())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "THÔNG BÁO");
                    return;
                }
                SaveAction();
                isSaved = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkUIvalid())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "THÔNG BÁO");
                    return;
                }
                SaveAction();
                this.currentMode = CONS_MODE_ADD;
                initDataAction();
                setSetForm();
                updateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private bool checkUIvalid()
        {
            if (String.IsNullOrWhiteSpace(orderDTO.idKhachHang))
            {
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkValidDatHang())
                {
                    int selectedRow = this.dataGridViewSanPham.SelectedRows[0].Index;
                    DonDatHangSPDto orderSP = this.orderDTO.listSanPham[selectedRow];
                    orderSP.idOrder = orderDTO.id;
                    orderSP.tenSanPham = cbbLoaiSanPham.Text;
                    orderSP.kichThuoc = cbbSize.Text;
                    orderSP.loaiBia = cbbLoaiBia.Text;
                    orderSP.loaiGiay = cbbLoaiGiay.Text;
                    orderSP.soTrang = (int)txtSoTo.Value;
                    orderSP.donGia = double.Parse(txtDonGia.Text);
                    orderSP.soluong = (int)txtSoLuong.Value;
                    orderSP.chietKhau = (int)txtChietKhau.Value;
                    orderSP.thanhTien = orderSP.donGia * orderSP.soluong;
                    orderSP.thanhTien = orderSP.thanhTien - (orderSP.chietKhau / 100 * orderSP.thanhTien);
                    orderSP.cdcr = txtTenCDCR.Text;
                    //orderDTO.listSanPham.Add(orderSP);

                    updateUI();

                    setSetForm();

                    this.btnUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!!!");
            }
        }

        private void numberVAT_ValueChanged(object sender, EventArgs e)
        {
            updateUI();
        }

        private void numberVAT_KeyUp(object sender, KeyEventArgs e)
        {
            updateUI();
        }

        private void txtSoTo_KeyUp(object sender, KeyEventArgs e)
        {
            txtSoTo_ValueChanged(sender, e);
        }

        private void txtSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            txtSoLuong_ValueChanged(sender, e);
        }

        private void txtChietKhau_KeyUp(object sender, KeyEventArgs e)
        {
            txtChietKhau_ValueChanged(sender, e);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            browseKhachHang();
        }

    }
}
