using MaterialSkin.Controls;
using OrderApp.Common;
using OrderApp.Dto;
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
    public partial class SearchCustomer : MaterialForm
    {
        private FormSearchCustomerObj outputObj;
        public KhachHangDto khachHangSelected;


        public SearchCustomer()
        {
            InitializeComponent();

            this.khachHangSelected = new KhachHangDto();
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                FormSearchCustomerObj frmObj = tranfersInput();
                CustomerLogic logic = new CustomerLogic();
                LogicResult result = logic.searchCustomerLogic(frmObj);
                outputObj = (FormSearchCustomerObj)result.obj;
                this.listKhachHang.DataSource = outputObj.listKhachHangs;

            } catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            
        }

        private FormSearchCustomerObj tranfersInput()
        {
            FormSearchCustomerObj obj = new FormSearchCustomerObj();
            obj.idKhachHang = StringUtils.Trim(this.idKhachHang.Text);
            obj.tenKhachHang = StringUtils.Trim(this.tenKhachHang.Text);
            obj.sales = StringUtils.Trim(this.sales.Text);
            //obj.trangThaiNo = this.trangthaiNo;
            return obj;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            AddCustomer frmAdd = new AddCustomer();
            frmAdd.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditCustomer frmEdit = new EditCustomer();
            frmEdit.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listKhachHang_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void listKhachHang_CellContentDoubleClick(object sender, EventArgs e)
        {
            if (listKhachHang.SelectedRows.Count > 0)
            {
                int rowSelected = listKhachHang.SelectedRows[0].Index;
                String idKhachHang = outputObj.listKhachHangs.Rows[rowSelected]["ID_KHACH_HANG"].ToString();
                String tenKhachHang = outputObj.listKhachHangs.Rows[rowSelected]["TEN_KHACH_HANG"].ToString();

                this.khachHangSelected = new KhachHangDto();
                this.khachHangSelected.idKhachHang = idKhachHang;
                this.khachHangSelected.tenKhachHang = tenKhachHang;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
