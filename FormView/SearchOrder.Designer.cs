namespace OrderApp.FormView
{
    partial class SearchOrder
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
            this.label2 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbTinhTrangDonHang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnExport = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDetail = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCreate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDonHang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Từ ngày";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateFrom
            // 
            this.dateFrom.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateFrom.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.dateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(114, 17);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(112, 23);
            this.dateFrom.TabIndex = 0;
            this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // dateTo
            // 
            this.dateTo.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(295, 17);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(115, 23);
            this.dateTo.TabIndex = 1;
            this.dateTo.ValueChanged += new System.EventHandler(this.dateTo_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbbTinhTrangDonHang);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.groupBox1.Location = new System.Drawing.Point(23, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // cbbTinhTrangDonHang
            // 
            this.cbbTinhTrangDonHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTinhTrangDonHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTinhTrangDonHang.FormattingEnabled = true;
            this.cbbTinhTrangDonHang.Items.AddRange(new object[] {
            "TỔNG HỢP ĐƠN HÀNG",
            "ĐƠN HÀNG CHƯA GIAO",
            "ĐƠN HÀNG ĐÃ GIAO",
            "ĐƠN HÀNG CHƯA THANH TOÁN",
            "ĐƠN HÀNG ĐÃ THANH TOÁN"});
            this.cbbTinhTrangDonHang.Location = new System.Drawing.Point(568, 16);
            this.cbbTinhTrangDonHang.Name = "cbbTinhTrangDonHang";
            this.cbbTinhTrangDonHang.Size = new System.Drawing.Size(274, 24);
            this.cbbTinhTrangDonHang.TabIndex = 2;
            this.cbbTinhTrangDonHang.SelectedIndexChanged += new System.EventHandler(this.cbbTinhTrangDonHang_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(232, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Đến";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDetail, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCreate, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 480);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(690, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(851, 42);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Depth = 0;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(722, 3);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = true;
            this.btnClose.Size = new System.Drawing.Size(126, 36);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.AutoSize = true;
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.CausesValidation = false;
            this.btnExport.Depth = 0;
            this.btnExport.Icon = null;
            this.btnExport.Location = new System.Drawing.Point(588, 3);
            this.btnExport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExport.Name = "btnExport";
            this.btnExport.Primary = true;
            this.btnExport.Size = new System.Drawing.Size(120, 36);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.AutoSize = true;
            this.btnDetail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDetail.CausesValidation = false;
            this.btnDetail.Depth = 0;
            this.btnDetail.Icon = null;
            this.btnDetail.Location = new System.Drawing.Point(454, 3);
            this.btnDetail.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Primary = true;
            this.btnDetail.Size = new System.Drawing.Size(120, 36);
            this.btnDetail.TabIndex = 19;
            this.btnDetail.Text = "Chi Tiết";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.AutoSize = true;
            this.btnCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreate.CausesValidation = false;
            this.btnCreate.Depth = 0;
            this.btnCreate.Icon = null;
            this.btnCreate.Location = new System.Drawing.Point(3, 3);
            this.btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Primary = true;
            this.btnCreate.Size = new System.Drawing.Size(121, 36);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "Tạo Mới";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.dataGridViewDonHang);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.groupBox2.Location = new System.Drawing.Point(23, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(851, 350);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đơn Đặt Hàng";
            // 
            // dataGridViewDonHang
            // 
            this.dataGridViewDonHang.AllowUserToAddRows = false;
            this.dataGridViewDonHang.AllowUserToDeleteRows = false;
            this.dataGridViewDonHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDonHang.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewDonHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewDonHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewDonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ID,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column17,
            this.Column19,
            this.Column6});
            this.dataGridViewDonHang.Location = new System.Drawing.Point(10, 22);
            this.dataGridViewDonHang.Name = "dataGridViewDonHang";
            this.dataGridViewDonHang.ReadOnly = true;
            this.dataGridViewDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDonHang.Size = new System.Drawing.Size(832, 322);
            this.dataGridViewDonHang.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "STT";
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "SỐ ORDER";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TEN_KHACH_HANG";
            this.Column3.HeaderText = "TÊN KH";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NGAY_DAT";
            this.Column4.HeaderText = "NGÀY ĐẶT";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NGAY_GIAO";
            this.Column5.HeaderText = "NGÀY GIAO";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "TONG_TIEN";
            this.Column17.HeaderText = "TỔNG TIỀN";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 120;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "TRANG_THAI_THANH_TOAN";
            this.Column19.HeaderText = "THANH TOÁN";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Width = 120;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TRANG_THAI_XUAT_KHO";
            this.Column6.HeaderText = "XUẤT KHO";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtOrderID.Location = new System.Drawing.Point(317, 31);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(169, 26);
            this.txtOrderID.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::OrderApp.Properties.Resources.search_icon;
            this.btnSearch.Location = new System.Drawing.Point(490, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(25, 25);
            this.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSearch.TabIndex = 20;
            this.btnSearch.TabStop = false;
            // 
            // SearchOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 530);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐƠN ĐẶT HÀNG";
            this.Load += new System.EventHandler(this.form_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
        private MaterialSkin.Controls.MaterialRaisedButton btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewDonHang;
        private System.Windows.Forms.ComboBox cbbTinhTrangDonHang;
        private MaterialSkin.Controls.MaterialRaisedButton btnCreate;
        private MaterialSkin.Controls.MaterialRaisedButton btnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.PictureBox btnSearch;
    }
}