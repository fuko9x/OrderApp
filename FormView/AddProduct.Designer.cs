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
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 515);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(690, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(755, 40);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Depth = 0;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(601, 3);
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
            this.saveBtn.Location = new System.Drawing.Point(439, 3);
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
            this.label1.Location = new System.Drawing.Point(55, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "ten sp";
            // 
            // tenSanPham
            // 
            this.tenSanPham.Location = new System.Drawing.Point(136, 104);
            this.tenSanPham.Name = "tenSanPham";
            this.tenSanPham.Size = new System.Drawing.Size(100, 20);
            this.tenSanPham.TabIndex = 20;
            // 
            // loaiBia
            // 
            this.loaiBia.Location = new System.Drawing.Point(136, 130);
            this.loaiBia.Name = "loaiBia";
            this.loaiBia.Size = new System.Drawing.Size(100, 20);
            this.loaiBia.TabIndex = 21;
            // 
            // size
            // 
            this.size.Location = new System.Drawing.Point(136, 156);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(100, 20);
            this.size.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "loai bia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "don gia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "description";
            // 
            // donGia
            // 
            this.donGia.Location = new System.Drawing.Point(136, 179);
            this.donGia.Name = "donGia";
            this.donGia.Size = new System.Drawing.Size(100, 20);
            this.donGia.TabIndex = 27;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(136, 206);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(100, 20);
            this.description.TabIndex = 28;
            // 
            // loaiGiay
            // 
            this.loaiGiay.Location = new System.Drawing.Point(136, 240);
            this.loaiGiay.Name = "loaiGiay";
            this.loaiGiay.Size = new System.Drawing.Size(100, 20);
            this.loaiGiay.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "loaiGiay";
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 567);
            this.Controls.Add(this.loaiGiay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.description);
            this.Controls.Add(this.donGia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.size);
            this.Controls.Add(this.loaiBia);
            this.Controls.Add(this.tenSanPham);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Sản phẩm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}