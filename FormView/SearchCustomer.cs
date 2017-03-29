﻿using MaterialSkin.Controls;
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

            formatControl();

            this.khachHangSelected = new KhachHangDto();
        }

        private void formatControl()
        {
            this.listKhachHang = (DataGridView)FormatLayoutUtil.formatDataGridview(this.listKhachHang);
            this.listKhachHang.MouseClick += ListKhachHang_MouseClick;
        }

        private void ListKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = listKhachHang.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    this.listKhachHang.Rows[currentMouseOverRow].Selected = true;

                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu.MenuItems.Add(new MenuItem("Add", addBtn_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Edit", btnEdit_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Delete", btnXoa_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Close"));
                    contextMenu.Show(listKhachHang, new Point(e.X, e.Y));
                }
            }
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
            //obj.trangThaiNo = this.trangthaiNo;
            return obj;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddCustomer frmAdd = new AddCustomer();
            frmAdd.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listKhachHang.SelectedRows.Count == 1)
            {
                int rowSelected = listKhachHang.SelectedRows[0].Index;
                String selectedId = listKhachHang.Rows[rowSelected].Cells["ID"].Value.ToString();
                AddCustomer frmEdit = new AddCustomer(selectedId);
                if (frmEdit.ShowDialog(this) == DialogResult.OK)
                {
                    // no thing
                }
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listKhachHang.SelectedRows.Count == 1)
            {
                int rowSelected = listKhachHang.SelectedRows[0].Index;
                String selectedId = listKhachHang.Rows[rowSelected].Cells["ID"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        FormSearchCustomerObj obj = new FormSearchCustomerObj();
                        obj.idKhachHang = selectedId;
                        LogicResult logicRS = new CustomerLogic().deleteCustomerLogic(obj);

                        FormSearchCustomerObj frmObj = tranfersInput();
                        CustomerLogic logic = new CustomerLogic();
                        LogicResult searchResult = logic.searchCustomerLogic(frmObj);
                        outputObj = (FormSearchCustomerObj)searchResult.obj;
                        this.listKhachHang.DataSource = outputObj.listKhachHangs;
                        MessageBox.Show("SUCCESS: " + logicRS.msg);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                    }
                }
            }
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
                String diaChi = outputObj.listKhachHangs.Rows[rowSelected]["DIA_CHI"].ToString();

                this.khachHangSelected = new KhachHangDto();
                this.khachHangSelected.idKhachHang = idKhachHang;
                this.khachHangSelected.tenKhachHang = tenKhachHang;
                this.khachHangSelected.diaChi = diaChi;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
