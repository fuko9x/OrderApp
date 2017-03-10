using MaterialSkin.Controls;
using OrderApp.Properties;
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
    public partial class PrintOrder : MaterialForm
    {
        public PrintOrder()
        {
            InitializeComponent();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            //PrintDialog associate with PrintDocument;
            //printDialog1.Document = printDocument1;
            //printDialog1.ShowDialog();

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Icon = Resources.icon;
            printPreviewDialog1.Text = "PRINT ORDER";
            printPreviewDialog1.StartPosition = FormStartPosition.CenterParent;
            printPreviewDialog1.PrintPreviewControl.AutoZoom = true;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
            printPreviewDialog1.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap MemoryImage = new Bitmap(panelPrint.Width, panelPrint.Height);
            panelPrint.DrawToBitmap(MemoryImage, new Rectangle(0, 0, panelPrint.Width, panelPrint.Height));
            g.DrawImage((Image)MemoryImage, 0, 0);
        }

        private void lblTenKhachHang_Click(object sender, EventArgs e)
        {

        }
    }
}
