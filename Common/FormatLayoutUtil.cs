using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp.Common
{
    public class FormatLayoutUtil
    {
        public static Control formatDataGridview(Control control)
        {
            //format Datagridview
            if (control.GetType() == typeof(DataGridView))
            {
                DataGridView gridview = (DataGridView)control;
                gridview.BackgroundColor = System.Drawing.Color.White;
                gridview.GridColor = System.Drawing.SystemColors.ActiveBorder;
                gridview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                gridview.RowHeadersVisible = false;

                gridview.ReadOnly = true;
                gridview.MultiSelect = false;
                gridview.AllowUserToAddRows = false;
                gridview.AllowUserToDeleteRows = false;
                gridview.AllowUserToResizeRows = false;

                gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

                gridview.ColumnHeadersHeight = 30;
                gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                gridview.EnableHeadersVisualStyles = false;
                gridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;

                //DefaultCellStyle
                DataGridViewCellStyle defaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
                defaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                defaultCellStyle.BackColor = System.Drawing.Color.White;
                defaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                defaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                defaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                defaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                defaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                gridview.DefaultCellStyle = defaultCellStyle;

                //Header cell style
                DataGridViewCellStyle HeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
                HeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                HeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
                HeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                HeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                HeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateBlue;
                HeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                HeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                gridview.RowHeadersDefaultCellStyle = HeadersDefaultCellStyle;

                return gridview;
            }
            return control;
        }

        public static void AcceptNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
