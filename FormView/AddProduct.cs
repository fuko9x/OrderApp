
using OrderApp.Common;
using OrderApp.Dao;
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
    public partial class AddProduct : Form
    {
        public static readonly int CONS_MODE_ADD = 0;
        public static readonly int CONS_MODE_EDIT = 1;
        public static readonly int CONS_MODE_VIEW = 2;

        public int currentMode = CONS_MODE_ADD;


        public AddProduct()
        {
            InitializeComponent();

            loadData();
        }

        public void editProduct(SanPhamDto dto)
        {
            this.Text = "CẬP NHẬT SẢN PHẨM ID: #" + dto.id;
            this.comboBoxLoaiSanPham.SelectedValue = dto.idSanPhamCha;
            this.id.Text = dto.id.ToString();
            this.currentMode = CONS_MODE_EDIT;
            this.tenSanPham.Text = dto.name;
            this.loaiBia.Text = dto.loaiBia;
            this.loaiGiay.Text = dto.loaiGiay;
            this.size.Text = dto.size;
            this.description.Text = dto.notes;
            this.donGia.Text = dto.donGia.ToString();
            this.numPageDefault.Value = dto.numPageDefault;
            this.addPageCost.Text = dto.addPageCost.ToString();

            this.comboBoxLoaiSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            //this.comboBoxLoaiSanPham.Visible = false;
        }

        public void cloneProduct(SanPhamDto dto)
        {
            this.comboBoxLoaiSanPham.SelectedValue = dto.idSanPhamCha;
            this.currentMode = CONS_MODE_ADD;
            this.tenSanPham.Text = dto.name;
            this.loaiBia.Text = dto.loaiBia;
            this.loaiGiay.Text = dto.loaiGiay;
            this.size.Text = dto.size;
            this.description.Text = dto.notes;
            this.donGia.Text = dto.donGia.ToString();
            this.numPageDefault.Value = dto.numPageDefault;
            this.addPageCost.Text = dto.addPageCost.ToString();
        }

        private void loadData()
        {
            try
            {
                //load combobox
                this.comboBoxLoaiSanPham.DataSource = SanPhamDao.getListSanPhamCha();
                this.comboBoxLoaiSanPham.ValueMember = "ID";
                this.comboBoxLoaiSanPham.DisplayMember = "TEN_SAN_PHAM";

                this.donGia.KeyPress += FormatLayoutUtil.AcceptNumber_KeyPress;
                this.addPageCost.KeyPress += FormatLayoutUtil.AcceptNumber_KeyPress;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }

        private Boolean saveAction()
        {
            // Check input
            if (checkValideSubmit() == false) return false;
            FormAddProductObj frmObj = tranfersInput();

            if (currentMode == CONS_MODE_ADD)
            {
                LogicResult rs = new ProductLogic().addProduct(frmObj);
                if (rs.severity == Contanst.MSG_ERROR)
                {
                    MessageBox.Show(rs.msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    return true;
                }
            }
            if (currentMode == CONS_MODE_EDIT)
            {
                LogicResult rs = new ProductLogic().updateProduct(frmObj);
                if (rs.severity == Contanst.MSG_ERROR)
                {
                    MessageBox.Show(rs.msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveAction())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (saveAction())
            {
                this.currentMode = CONS_MODE_ADD;
                clearForm();
            }
        }

        private void clearForm()
        {
            this.tenSanPham.Text = "";
            this.comboBoxLoaiSanPham.Text = "";
            this.loaiBia.Text = "";
            this.loaiGiay.Text = "";
            this.size.Text = "";
            this.donGia.Text = "";
            this.addPageCost.Text = "";
            this.description.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private FormAddProductObj tranfersInput()
        {
            FormAddProductObj obj = new FormAddProductObj();
            if (this.comboBoxLoaiSanPham.SelectedIndex < 0)
            {
                obj.idSanPhamCha = 0;
                obj.tenSanPhamCha = this.comboBoxLoaiSanPham.Text;
            }
            else
            {
                obj.idSanPhamCha = (int)this.comboBoxLoaiSanPham.SelectedValue;
                obj.tenSanPhamCha = this.comboBoxLoaiSanPham.SelectedText;
            }
            obj.idSanPham = this.id.Text != "" ? int.Parse(this.id.Text) : 0;
            obj.tenSanPham = this.tenSanPham.Text;
            obj.loaiBia = this.loaiBia.Text;
            obj.loaiGiay = this.loaiGiay.Text;
            obj.size = this.size.Text;
            obj.description = this.description.Text;
            obj.donGia = float.Parse(this.donGia.Text);
            obj.numPageDefault = (int)this.numPageDefault.Value;
            obj.addPageCost = float.Parse(this.addPageCost.Text);
            return obj;
        }


        private Boolean checkValideSubmit()
        {
            Boolean isValid = true;
            List<TextBox> listRequite = new List<TextBox>()
            {
                this.tenSanPham
                , this.size
                , this.donGia
                , this.addPageCost
            };
            foreach (TextBox checkTextBox in listRequite)
            {
                if (String.IsNullOrEmpty(checkTextBox.Text))
                {
                    isValid = false;
                    errorProvider.SetError(checkTextBox, "Requite");
                }
                else
                {
                    errorProvider.SetError(checkTextBox, String.Empty);
                }
            }
            return isValid;
        }


    }
}
