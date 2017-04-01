using MaterialSkin.Controls;
using OrderApp.Common;
using OrderApp.Dao;
using OrderApp.Dto;
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
    public partial class SearchProduct : MaterialForm
    {
        private Boolean initData = false;
        public SanPhamDto sanPhamSelected;

        public SearchProduct()
        {
            InitializeComponent();
            formatControl();

            sanPhamSelected = new SanPhamDto();
            loadData();
        }

        // call when form.show
        private void SearchProduct_Load(object sender, EventArgs e)
        {
            initData = true;
            reloadData();
        }

        private void formatControl()
        {
            this.dataGridViewSanPham = (DataGridView)FormatLayoutUtil.formatDataGridview(this.dataGridViewSanPham);
            this.dataGridViewSanPham.MouseClick += DataGridViewSanPham_MouseClick;
        }

        private void DataGridViewSanPham_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridViewSanPham.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    this.dataGridViewSanPham.Rows[currentMouseOverRow].Selected = true;

                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu.MenuItems.Add(new MenuItem("Clone", btnClone_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Edit", btnEdit_Click));
                    contextMenu.MenuItems.Add(new MenuItem("Close"));
                    contextMenu.Show(dataGridViewSanPham, new Point(e.X, e.Y));
                }
            }
        }

        private void loadData()
        {
            //Load combobox
            this.cbbLoaiSanPham.DataSource = SanPhamDao.getListSanPhamCha();
            this.cbbLoaiSanPham.ValueMember = "ID";
            this.cbbLoaiSanPham.DisplayMember = "TEN_SAN_PHAM";
            //reloadData();
        }

        private void reloadData()
        {
            int idSanPhamCha = 0;
            if (cbbLoaiSanPham.SelectedIndex >= 0)
            {
                int.TryParse(cbbLoaiSanPham.SelectedValue.ToString(), out idSanPhamCha);
            }
            if (idSanPhamCha != 0)
            {
                this.dataGridViewSanPham.DataSource = SanPhamDao.getListChiTiet(idSanPhamCha);
            }
        }

        private void loadDataGridview(int idSanPhamCha)
        {
            this.dataGridViewSanPham.DataSource = SanPhamDao.getListChiTiet(idSanPhamCha);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void cbbLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initData == false) return;
            reloadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewSanPham.SelectedRows.Count > 0)
            {
                int rowSelected = dataGridViewSanPham.SelectedRows[0].Index;

                SanPhamDto dto = new SanPhamDto();
                dto.idSanPhamCha = int.Parse( cbbLoaiSanPham.SelectedValue.ToString());
                dto.id = int.Parse( dataGridViewSanPham.Rows[rowSelected].Cells["ID"].Value.ToString());
                dto.name = dataGridViewSanPham.Rows[rowSelected].Cells["TEN_SAN_PHAM"].Value.ToString();
                dto.loaiBia = dataGridViewSanPham.Rows[rowSelected].Cells["LOAI_BIA"].Value.ToString();
                dto.loaiGiay = dataGridViewSanPham.Rows[rowSelected].Cells["LOAI_GIAY"].Value.ToString();
                dto.size = dataGridViewSanPham.Rows[rowSelected].Cells["SIZE"].Value.ToString();
                dto.notes = dataGridViewSanPham.Rows[rowSelected].Cells["DESCRIPTION"].Value.ToString();
                double.TryParse( dataGridViewSanPham.Rows[rowSelected].Cells["DON_GIA"].Value.ToString(),out dto.donGia);
                int.TryParse( dataGridViewSanPham.Rows[rowSelected].Cells["NUM_PAGE_DEFAULT"].Value.ToString(), out dto.numPageDefault);
                double.TryParse( dataGridViewSanPham.Rows[rowSelected].Cells["ADDITIONAL_PAGES_COST"].Value.ToString(), out dto.addPageCost);

                AddProduct frmProduct = new AddProduct();
                frmProduct.editProduct(dto);
                if(frmProduct.ShowDialog(this) == DialogResult.OK)
                {
                    reloadData();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct frmAdd = new AddProduct();
            if (frmAdd.ShowDialog(this) == DialogResult.OK)
            {
                loadData();
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (dataGridViewSanPham.SelectedRows.Count > 0)
            {
                int rowSelected = dataGridViewSanPham.SelectedRows[0].Index;

                SanPhamDto dto = new SanPhamDto();
                //Ten Loai san pham
                dto.idSanPhamCha = int.Parse(cbbLoaiSanPham.SelectedValue.ToString());
                dto.name = dataGridViewSanPham.Rows[rowSelected].Cells["TEN_SAN_PHAM"].Value.ToString();
                dto.loaiBia = dataGridViewSanPham.Rows[rowSelected].Cells["LOAI_BIA"].Value.ToString();
                dto.loaiGiay = dataGridViewSanPham.Rows[rowSelected].Cells["LOAI_GIAY"].Value.ToString();
                dto.size = dataGridViewSanPham.Rows[rowSelected].Cells["SIZE"].Value.ToString();
                dto.notes = dataGridViewSanPham.Rows[rowSelected].Cells["DESCRIPTION"].Value.ToString();
                double.TryParse(dataGridViewSanPham.Rows[rowSelected].Cells["DON_GIA"].Value.ToString(), out dto.donGia);
                int.TryParse(dataGridViewSanPham.Rows[rowSelected].Cells["NUM_PAGE_DEFAULT"].Value.ToString(), out dto.numPageDefault);
                double.TryParse(dataGridViewSanPham.Rows[rowSelected].Cells["ADDITIONAL_PAGES_COST"].Value.ToString(), out dto.addPageCost);

                AddProduct frmProduct = new AddProduct();
                frmProduct.cloneProduct(dto);
                frmProduct.ShowDialog(this);

                reloadData();
            }
        }


    }
}
