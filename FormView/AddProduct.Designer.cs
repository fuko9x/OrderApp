namespace OrderApp.FormView
{
    partial class AddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.saveBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tenSanPham = new System.Windows.Forms.TextBox();
            this.loaiBia = new System.Windows.Forms.TextBox();
            this.size = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.donGia = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.loaiGiay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveBtn, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 490);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(690, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(717, 40);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Depth = 0;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(563, 3);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = true;
            this.btnClose.Size = new System.Drawing.Size(151, 34);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.AutoSize = true;
            this.saveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveBtn.Depth = 0;
            this.saveBtn.Icon = null;
            this.saveBtn.Location = new System.Drawing.Point(401, 3);
            this.saveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Primary = true;
            this.saveBtn.Size = new System.Drawing.Size(148, 34);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 35);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nhập Tên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenSanPham
            // 
            this.tenSanPham.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tenSanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.tenSanPham.Location = new System.Drawing.Point(183, 39);
            this.tenSanPham.Name = "tenSanPham";
            this.tenSanPham.Size = new System.Drawing.Size(364, 26);
            this.tenSanPham.TabIndex = 20;
            // 
            // loaiBia
            // 
            this.loaiBia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.loaiBia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.loaiBia.Location = new System.Drawing.Point(183, 109);
            this.loaiBia.Name = "loaiBia";
            this.loaiBia.Size = new System.Drawing.Size(364, 26);
            this.loaiBia.TabIndex = 21;
            // 
            // size
            // 
            this.size.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.size.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.size.Location = new System.Drawing.Point(183, 74);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(364, 26);
            this.size.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 35);
            this.label2.TabIndex = 23;
            this.label2.Text = "Loại bìa / Khung";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 35);
            this.label3.TabIndex = 24;
            this.label3.Text = "Kích thước (mm)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 35);
            this.label4.TabIndex = 25;
            this.label4.Text = "Đơn Giá (VND)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 91);
            this.label5.TabIndex = 26;
            this.label5.Text = "Ghi chú";
            // 
            // donGia
            // 
            this.donGia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.donGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.donGia.Location = new System.Drawing.Point(183, 179);
            this.donGia.Name = "donGia";
            this.donGia.Size = new System.Drawing.Size(364, 26);
            this.donGia.TabIndex = 27;
            // 
            // description
            // 
            this.description.Dock = System.Windows.Forms.DockStyle.Left;
            this.description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.description.Location = new System.Drawing.Point(183, 213);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(364, 85);
            this.description.TabIndex = 28;
            // 
            // loaiGiay
            // 
            this.loaiGiay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.loaiGiay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.loaiGiay.Location = new System.Drawing.Point(183, 144);
            this.loaiGiay.Name = "loaiGiay";
            this.loaiGiay.Size = new System.Drawing.Size(364, 26);
            this.loaiGiay.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 35);
            this.label6.TabIndex = 29;
            this.label6.Text = "Loại Giấy";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tenSanPham, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.size, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.loaiBia, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.description, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.donGia, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.loaiGiay, 1, 4);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(92, 125);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(601, 362);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 35);
            this.label7.TabIndex = 13;
            this.label7.Text = "Chọn Sản Phẩm";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(183, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(364, 27);
            this.comboBox1.TabIndex = 21;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 567);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Sản phẩm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
        private MaterialSkin.Controls.MaterialRaisedButton saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tenSanPham;
        private System.Windows.Forms.TextBox loaiBia;
        private System.Windows.Forms.TextBox size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox donGia;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox loaiGiay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}