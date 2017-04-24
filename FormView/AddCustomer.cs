using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using OrderApp.Common;
using System.Data.SqlClient;
using OrderApp.Logic;
using MaterialSkin.Controls;
using OrderApp.Dao;
using OrderApp.Dto;

namespace OrderApp.FormView
{
    public partial class AddCustomer : MaterialForm
    {
        public static readonly int CONS_MODE_ADD = 0;
        public static readonly int CONS_MODE_EDIT = 1;
        public static readonly int CONS_MODE_VIEW = 2;

        public Boolean initData = false;

        public int currentMode = CONS_MODE_ADD;
        public String selectedId;

        private List<LienHeDto> listLienHe = new List<LienHeDto>();

        public AddCustomer()
        {
            InitializeComponent();
        }

        public AddCustomer(String idKH)
        {
            InitializeComponent();
            this.selectedId = idKH;
            this.Text = "CẬP NHẬT KHÁCH HÀNG : #" + idKH;
            this.idKhachHang.ReadOnly = true;

            if (StringUtils.isNotBlank(selectedId))
            {
                KhachHangDto dto = new KhachHangDao().getKhachHangById(selectedId);
                this.listLienHe = dto.listLienHe;
                this.idKhachHang.Text = selectedId;
                this.tenKH.Text = dto.tenKhachHang;
                this.diachi.Text = dto.diaChi;
                this.email.Text = dto.email;
                this.accFtp.Text = dto.accFtp;
                this.salesName.Text = dto.sales;
                this.salesPercent.Value = dto.salesPercent;
                this.vanChuyen.Text = dto.vanChuyen;
                this.ngayHopTac.Value = dto.startDate;
                this.notes.Text = dto.notes;
                this.txtSoTienNo.Text = dto.soTienNo.ToString();
            }
        }

        private void form_Load(object sender, EventArgs e)
        {
            this.initData = true;
            loadContact();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkValideSubmit() == false)
                {
                    return;
                }
                FormAddCustomerObj formObj = tranfersInput();
                CustomerLogic logic = new CustomerLogic();
                LogicResult result;
                if (StringUtils.isBlank(selectedId))
                {
                    result = logic.addCustommerLogic(formObj);
                }
                else
                {
                    result = logic.updateCustommerLogic(formObj);
                }

                if (result.severity == Contanst.MSG_ERROR)
                {
                    MessageBox.Show(result.msg);
                } else {
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private Boolean checkValideSubmit()
        {
            Boolean isValid = true;
            List<Control> listRequite = new List<Control>()
            {
                this.idKhachHang
                , this.diachi
                , this.tenKH
                , this.cbbContact
                , this.phoneContact
            };
            foreach (Control control in listRequite)
            {
                if (String.IsNullOrEmpty(control.Text))
                {
                    isValid = false;
                    errorProvider.SetError(control, "Chưa nhập giá trị");
                }
                else
                {
                    errorProvider.SetError(control, String.Empty);
                }
            }
            return isValid;
        }

        private FormAddCustomerObj tranfersInput()
        {
            FormAddCustomerObj destObj = new FormAddCustomerObj();
            destObj.idKhachHang = StringUtils.Trim(this.idKhachHang.Text);
            destObj.tenKhachHang = StringUtils.Trim(this.tenKH.Text);
            destObj.diaChi = StringUtils.Trim(this.diachi.Text);
            destObj.soTienNo = Decimal.Parse(this.txtSoTienNo.Text);
            destObj.email = StringUtils.Trim(this.email.Text);
            destObj.accFtp = StringUtils.Trim(this.accFtp.Text);
            destObj.sales = StringUtils.Trim(this.salesName.Text);

            destObj.salesPercent = (Decimal)this.salesPercent.Value;
            destObj.giamGia = this.giamGia.Value.ToString();

            destObj.vanChuyen = StringUtils.Trim(this.vanChuyen.Text);
            destObj.startDate = this.ngayHopTac.Value;
            destObj.notes = StringUtils.Trim(this.notes.Text);
            if (this.listLienHe.Count > 0)
            {
                destObj.listContracts = this.listLienHe;
                foreach (LienHeDto lienHe in destObj.listContracts)
                {
                    lienHe.idKhacHang = this.idKhachHang.Text;
                }
                
            }
            else
            {
                if (StringUtils.isNotBlank(this.cbbContact.Text) || StringUtils.isNotBlank(this.phoneContact.Text)) {
                    destObj.listContracts.Add(new LienHeDto(cbbContact.Text.Trim(), phoneContact.Text.Trim(), destObj.idKhachHang));
                }
            }

            destObj.user = "BINH";
            
            return destObj;
        }

        private void btnAddLienHe_Click(object sender, EventArgs e)
        {
            if(this.listLienHe.Count <= 0)
            {
                if(cbbContact.Text.Trim() != "")
                {
                    this.listLienHe.Add(new LienHeDto(cbbContact.Text.Trim(), phoneContact.Text.Trim()));
                }
            }
            FrmLienHe frmLienHe = new FrmLienHe();
            frmLienHe.listLienHe = this.listLienHe;
            frmLienHe.ShowDialog(this);

            this.listLienHe = frmLienHe.listLienHe;
            loadContact();
        }

        private void loadContact()
        {
            this.cbbContact.Items.Clear();
            if (listLienHe.Count > 0)
            {
                foreach (LienHeDto lienHe in listLienHe)
                {
                    this.cbbContact.Items.Add(lienHe.name);
                }
                this.cbbContact.SelectedIndex = 0;
                this.phoneContact.Text = listLienHe[0].phone;
            }
            
        }

        private void cbbContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intSelected = cbbContact.SelectedIndex;
            if (intSelected < listLienHe.Count)
            {
                phoneContact.Text = listLienHe[intSelected].phone;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
