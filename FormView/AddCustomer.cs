﻿using System;
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

        public int currentMode = CONS_MODE_ADD;
        public String selectedId;

        private List<LienHeObj> listLienHe = new List<LienHeObj>();

        public AddCustomer()
        {
            InitializeComponent();
        }

        public AddCustomer(String idKH)
        {
            InitializeComponent();
            this.selectedId = idKH;
            if (StringUtils.isNotBlank(selectedId))
            {
                KhachHangDto dto = new KhachHangDao().getKhachHangById(selectedId);
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

            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                FormAddCustomerObj formObj = tranfersInput();
                CustomerLogic logic = new CustomerLogic();
                if (StringUtils.isBlank(selectedId))
                {
                    LogicResult result = logic.addCustommerLogic(formObj);
                } else
                {
                    LogicResult result = logic.updateCustommerLogic(formObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private FormAddCustomerObj tranfersInput()
        {
            FormAddCustomerObj destObj = new FormAddCustomerObj();
            destObj.idKhachHang = StringUtils.Trim(this.idKhachHang.Text);
            destObj.tenKhachHang = StringUtils.Trim(this.tenKH.Text);
            destObj.diaChi = StringUtils.Trim(this.diachi.Text);
            destObj.email = StringUtils.Trim(this.email.Text);
            destObj.accFtp = StringUtils.Trim(this.accFtp.Text);
            destObj.sales = StringUtils.Trim(this.salesName.Text);

            destObj.salesPercent = (Decimal)this.salesPercent.Value;
            destObj.giamGia = this.giamGia.Value.ToString();

            destObj.vanChuyen = StringUtils.Trim(this.vanChuyen.Text);
            destObj.startDate = this.ngayHopTac.Value;
            destObj.notes = StringUtils.Trim(this.notes.Text);
            destObj.listContracts = this.listLienHe;

            destObj.user = "BINH";
            
            return destObj;
        }

        private void btnAddLienHe_Click(object sender, EventArgs e)
        {
            if(this.listLienHe.Count <= 0)
            {
                if(cbbContact.Text.Trim() != "")
                {
                    this.listLienHe.Add(new LienHeObj(cbbContact.Text.Trim(), phoneContact.Text.Trim()));
                }
            }
            FrmLienHe frmLienHe = new FrmLienHe();
            frmLienHe.listLienHe = this.listLienHe;
            frmLienHe.ShowDialog();

            this.listLienHe = frmLienHe.listLienHe;
            loadContact();
        }

        private void loadContact()
        {
            this.cbbContact.Items.Clear();
            if (listLienHe.Count > 0)
            {
                foreach (LienHeObj lienHe in listLienHe)
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
