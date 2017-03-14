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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp.FormView
{
    public partial class OrderNew : MaterialForm
    {
        public OrderNew()
        {
            InitializeComponent();
            formatControl();
            fillData();
            setOrderId();
        }

        private void setOrderId()
        {
            this.orderId.Text = new OrderLogic().insertNewId();
        }

        private void formatControl()
        {
            this.dataGridViewSanPham = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridViewSanPham);
        }

        private void fillData()
        {
            try
            {
                this.comboBoxLoaiSanPham.DataSource = SanPhamDao.getList();
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
                        listSize.Add(row["SIZE"].ToString());
                        listLoaiBia.Add(row["LOAI_BIA"].ToString());
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
