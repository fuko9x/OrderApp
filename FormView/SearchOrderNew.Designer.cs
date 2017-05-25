namespace OrderApp.FormView
{
    partial class SearchOrderNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbTinhTrangDonHang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewDonHang = new System.Windows.Forms.DataGridView();
            this.btnSearchKhachHang = new System.Windows.Forms.PictureBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_CHI_TIET_DON_HANG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THANH_TOAN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.XUAT_KHO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(297, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Từ ngày";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateFrom
            // 
            this.dateFrom.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateFrom.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.dateFrom.CustomFormat = "yyyy-MM-dd";
            this.dateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(368, 17);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(87, 23);
            this.dateFrom.TabIndex = 0;
            this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // dateTo
            // 
            this.dateTo.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTo.CustomFormat = "yyyy-MM-dd";
            this.dateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(482, 17);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(87, 23);
            this.dateTo.TabIndex = 1;
            this.dateTo.ValueChanged += new System.EventHandler(this.dateTo_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.cbbTinhTrangDonHang);
            this.groupBox1.Controls.Add(this.btnSearchKhachHang);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTenKhachHang);
            this.groupBox1.Controls.Add(this.dateTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.groupBox1.Location = new System.Drawing.Point(23, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 52);
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
            this.cbbTinhTrangDonHang.Location = new System.Drawing.Point(596, 16);
            this.cbbTinhTrangDonHang.Name = "cbbTinhTrangDonHang";
            this.cbbTinhTrangDonHang.Size = new System.Drawing.Size(230, 24);
            this.cbbTinhTrangDonHang.TabIndex = 2;
            this.cbbTinhTrangDonHang.SelectedIndexChanged += new System.EventHandler(this.cbbTinhTrangDonHang_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(461, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
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
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 441);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(690, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(835, 42);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Location = new System.Drawing.Point(706, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 28);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.CausesValidation = false;
            this.btnExport.Location = new System.Drawing.Point(572, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 28);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDetail.CausesValidation = false;
            this.btnDetail.Location = new System.Drawing.Point(438, 7);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(120, 28);
            this.btnDetail.TabIndex = 19;
            this.btnDetail.Text = "Chi Tiết";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnDeleteOrder);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Location = new System.Drawing.Point(19, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 36);
            this.panel1.TabIndex = 20;
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteOrder.CausesValidation = false;
            this.btnDeleteOrder.Location = new System.Drawing.Point(120, 4);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(111, 28);
            this.btnDeleteOrder.TabIndex = 19;
            this.btnDeleteOrder.Text = "Xóa Đơn Hàng";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.CausesValidation = false;
            this.btnEdit.Location = new System.Drawing.Point(3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(111, 28);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblSum);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dataGridViewDonHang);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.groupBox2.Location = new System.Drawing.Point(23, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(835, 373);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đơn Đặt Hàng";
            // 
            // lblSum
            // 
            this.lblSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(703, 340);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(46, 17);
            this.lblSum.TabIndex = 3;
            this.lblSum.Text = "label5";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(619, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng Tiền";
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
            this.ID_CHI_TIET_DON_HANG,
            this.Column2,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.THANH_TOAN,
            this.XUAT_KHO});
            this.dataGridViewDonHang.Location = new System.Drawing.Point(10, 22);
            this.dataGridViewDonHang.Name = "dataGridViewDonHang";
            this.dataGridViewDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDonHang.Size = new System.Drawing.Size(816, 315);
            this.dataGridViewDonHang.TabIndex = 1;
            this.dataGridViewDonHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonHang_CellContentClick);
            // 
            // btnSearchKhachHang
            // 
            this.btnSearchKhachHang.Image = global::OrderApp.Properties.Resources.search_icon;
            this.btnSearchKhachHang.Location = new System.Drawing.Point(266, 17);
            this.btnSearchKhachHang.Name = "btnSearchKhachHang";
            this.btnSearchKhachHang.Size = new System.Drawing.Size(25, 25);
            this.btnSearchKhachHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSearchKhachHang.TabIndex = 23;
            this.btnSearchKhachHang.TabStop = false;
            this.btnSearchKhachHang.Click += new System.EventHandler(this.btnSearchKhachHang_Click);
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(99, 18);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(141, 23);
            this.txtTenKhachHang.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Khách Hàng";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(241, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 28;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "STT";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle18;
            this.ID.HeaderText = "SỐ ORDER";
            this.ID.Name = "ID";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TEN_KHACH_HANG";
            this.Column3.HeaderText = "TÊN KH";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NGAY_DAT";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle19.Format = "yyyy-MM-dd";
            dataGridViewCellStyle19.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column4.HeaderText = "NGÀY ĐẶT";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NGAY_GIAO";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle20.Format = "yyyy-MM-dd";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle20;
            this.Column5.HeaderText = "NGÀY GIAO";
            this.Column5.Name = "Column5";
            // 
            // ID_CHI_TIET_DON_HANG
            // 
            this.ID_CHI_TIET_DON_HANG.DataPropertyName = "ID_CHI_TIET_DON_HANG";
            this.ID_CHI_TIET_DON_HANG.HeaderText = "ID CHI TIET";
            this.ID_CHI_TIET_DON_HANG.Name = "ID_CHI_TIET_DON_HANG";
            this.ID_CHI_TIET_DON_HANG.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TEN_SAN_PHAM";
            this.Column2.HeaderText = "TÊN SẢN PHẨM";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "SO_LUONG";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column6.HeaderText = "SL";
            this.Column6.Name = "Column6";
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "KICH_THUOC";
            this.Column7.HeaderText = "KÍCH THƯỚC";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "SO_TRANG";
            this.Column8.HeaderText = "SỐ TRANG";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "LOAI_BIA";
            this.Column9.HeaderText = "LOẠI BÌA";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "LOAI_GIAY";
            this.Column10.HeaderText = "LOẠI GIẤY";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "CHIET_KHAU";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column11.HeaderText = "CK (%)";
            this.Column11.Name = "Column11";
            this.Column11.Width = 80;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "DON_GIA";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle23.Format = "#,###";
            this.Column12.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column12.HeaderText = "ĐƠN GIÁ";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "THANH_TIEN";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle24.Format = "#,###";
            this.Column13.DefaultCellStyle = dataGridViewCellStyle24;
            this.Column13.HeaderText = "THÀNH TIỀN";
            this.Column13.Name = "Column13";
            // 
            // THANH_TOAN
            // 
            this.THANH_TOAN.DataPropertyName = "TRANG_THAI_THANH_TOAN";
            this.THANH_TOAN.HeaderText = "THANH TOÁN";
            this.THANH_TOAN.Name = "THANH_TOAN";
            this.THANH_TOAN.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.THANH_TOAN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.THANH_TOAN.Width = 120;
            // 
            // XUAT_KHO
            // 
            this.XUAT_KHO.DataPropertyName = "TRANG_THAI_XUAT_KHO";
            this.XUAT_KHO.HeaderText = "XUẤT KHO";
            this.XUAT_KHO.Name = "XUAT_KHO";
            this.XUAT_KHO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.XUAT_KHO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SearchOrderNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 491);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchOrderNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐƠN ĐẶT HÀNG";
            this.Load += new System.EventHandler(this.form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchKhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewDonHang;
        private System.Windows.Forms.ComboBox cbbTinhTrangDonHang;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.PictureBox btnSearchKhachHang;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_CHI_TIET_DON_HANG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewCheckBoxColumn THANH_TOAN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn XUAT_KHO;
    }
}