using MaterialSkin.Controls;
using OrderApp.Common;
using OrderApp.Dao;
using OrderApp.Logic;
using System;
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
    public partial class OrderNew : MaterialForm
    {
        public OrderNew()
        {
            InitializeComponent();

            initData();

        }

        private void initData()
        {
            try
            {
                formatControl();
                fillData();
                setOrderId();
            }
            catch (Exception ex)
            {

            }
        }

        private void setOrderId()
        {
            this.orderId.Text = new OrderLogic().insertNewId();
        }

        private void formatControl()
        {
            this.dataGridViewSanPham = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridViewSanPham);

            this.txtThanhTien.KeyPress += FormatLayoutUtil.AcceptNumber_KeyPress;
        }

        private void fillData()
        {
            try
            {
                this.comboBoxLoaiSanPham.DataSource = SanPhamDao.getListSanPhamCha();
                this.comboBoxLoaiSanPham.ValueMember = "ID";
                this.comboBoxLoaiSanPham.DisplayMember = "TEN_SAN_PHAM";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }

        private void comboBoxLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxLoaiSanPham.SelectedIndex >= 0)
                {
                    int idSanPhamCha = (int)comboBoxLoaiSanPham.SelectedValue;
                    DataTable dt = SanPhamDao.getListChiTiet(idSanPhamCha);

                    List<String> listSize = new List<string>();
                    List<String> listLoaiBia = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        String size = row["SIZE"].ToString();
                        if (!listSize.Contains(size))
                        {
                            listSize.Add(size);
                        }
                        String loaiBia = row["LOAI_BIA"].ToString();
                        if (!listLoaiBia.Contains(loaiBia))
                        {
                            listLoaiBia.Add(loaiBia);
                        }
                    }
                    //FILL combobox
                    cbbSize.DataSource = listSize;
                    cbbLoaiBia.DataSource = listLoaiBia;

                }
            }
            catch (Exception ex)
            {

            }
        }


        private void OrderNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc hủy đơn hàng này hay không?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
            {
                //Delete Order
                OrderDao orderDao = new OrderDao();
                orderDao.deleteId(orderId.Text);
                e.Cancel = true;
            }
        }



        private void txtThanhTien_MouseDown(object sender, MouseEventArgs e)
        {
            txtThanhTien.Text = AppUtils.formatMoney2Number(txtThanhTien.Text, 0).ToString();
        }

        private void txtThanhTien_MouseLeave(object sender, EventArgs e)
        {
            txtThanhTien.Text = AppUtils.formatNumber2Monney(AppUtils.formatMoney2Number(txtThanhTien.Text, 0));
        }
    }
}
