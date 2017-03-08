using MaterialSkin.Controls;
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
    public partial class FrmLienHe : MaterialForm
    {
        public List<LienHeObj>listLienHe = new List<LienHeObj>();

        public FrmLienHe()
        {
            InitializeComponent();

            initListView();

            loadData();
        }


        private void FrmLienHe_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void initListView()
        {
            // Set the view to show details.
            listViewLienHe.View = View.Details;

            // Display check boxes.
            //listViewLienHe.CheckBoxes = true;

            // Select the item and subitems when selection is made.
            listViewLienHe.FullRowSelect = true;

            // Display grid lines.
            listViewLienHe.GridLines = true;

            // Attach Subitems to the ListView
            listViewLienHe.Columns.Add("Người Liên Hệ", 200, HorizontalAlignment.Left);
            listViewLienHe.Columns.Add("Điện Thoại", 250, HorizontalAlignment.Left);
        }

        private void loadData()
        {
            listViewLienHe.Items.Clear();
            foreach (LienHeObj lienHe in listLienHe)
            {
                ListViewItem listitem = new ListViewItem(lienHe.name);
                listitem.SubItems.Add(lienHe.phone);
                listViewLienHe.Items.Add(listitem);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LienHeObj lienHe = new LienHeObj();
            lienHe.name = txtNguoiLienHe.Text;
            lienHe.phone = txtDienThoai.Text;
            listLienHe.Add(lienHe);

            loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
