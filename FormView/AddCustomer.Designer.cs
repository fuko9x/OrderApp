using System.Windows.Forms;

namespace OrderApp.FormView
{
    partial class AddCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCustomer));
            this.infoPnl = new System.Windows.Forms.TableLayoutPanel();
            this.giamGia = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.salesPercent = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.accFtp = new System.Windows.Forms.TextBox();
            this.salesName = new System.Windows.Forms.TextBox();
            this.vanChuyen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.phoneContact = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ngayHopTac = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddLienHe = new System.Windows.Forms.Button();
            this.tenKH = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.idKhachHang = new System.Windows.Forms.TextBox();
            this.cbbContact = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.notes = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.saveBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giamGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesPercent)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoPnl
            // 
            this.infoPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.infoPnl.BackColor = System.Drawing.Color.White;
            this.infoPnl.ColumnCount = 5;
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.00707F));
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.32254F));
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.154205F));
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.17637F));
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.33981F));
            this.infoPnl.Controls.Add(this.giamGia, 4, 3);
            this.infoPnl.Controls.Add(this.label10, 3, 2);
            this.infoPnl.Controls.Add(this.label6, 0, 1);
            this.infoPnl.Controls.Add(this.salesPercent, 4, 2);
            this.infoPnl.Controls.Add(this.label9, 3, 1);
            this.infoPnl.Controls.Add(this.diachi, 1, 1);
            this.infoPnl.Controls.Add(this.email, 1, 2);
            this.infoPnl.Controls.Add(this.accFtp, 1, 3);
            this.infoPnl.Controls.Add(this.salesName, 4, 1);
            this.infoPnl.Controls.Add(this.vanChuyen, 4, 4);
            this.infoPnl.Controls.Add(this.label2, 0, 0);
            this.infoPnl.Controls.Add(this.label3, 0, 2);
            this.infoPnl.Controls.Add(this.label5, 0, 4);
            this.infoPnl.Controls.Add(this.label7, 0, 5);
            this.infoPnl.Controls.Add(this.label11, 3, 3);
            this.infoPnl.Controls.Add(this.label12, 3, 4);
            this.infoPnl.Controls.Add(this.phoneContact, 1, 5);
            this.infoPnl.Controls.Add(this.label13, 3, 5);
            this.infoPnl.Controls.Add(this.ngayHopTac, 4, 5);
            this.infoPnl.Controls.Add(this.label4, 0, 3);
            this.infoPnl.Controls.Add(this.btnAddLienHe, 2, 4);
            this.infoPnl.Controls.Add(this.tenKH, 4, 0);
            this.infoPnl.Controls.Add(this.label14, 3, 0);
            this.infoPnl.Controls.Add(this.idKhachHang, 1, 0);
            this.infoPnl.Controls.Add(this.cbbContact, 1, 4);
            this.infoPnl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.infoPnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(77)))));
            this.infoPnl.Location = new System.Drawing.Point(27, 84);
            this.infoPnl.Name = "infoPnl";
            this.infoPnl.RowCount = 6;
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.infoPnl.Size = new System.Drawing.Size(740, 259);
            this.infoPnl.TabIndex = 0;
            // 
            // giamGia
            // 
            this.giamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.giamGia.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.giamGia.Location = new System.Drawing.Point(523, 137);
            this.giamGia.Name = "giamGia";
            this.giamGia.Size = new System.Drawing.Size(214, 26);
            this.giamGia.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(389, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 43);
            this.label10.TabIndex = 20;
            this.label10.Text = "NV Sales (%)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(3, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 43);
            this.label6.TabIndex = 16;
            this.label6.Text = "Địa chỉ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // salesPercent
            // 
            this.salesPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.salesPercent.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.salesPercent.Location = new System.Drawing.Point(523, 94);
            this.salesPercent.Name = "salesPercent";
            this.salesPercent.Size = new System.Drawing.Size(214, 26);
            this.salesPercent.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(389, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 43);
            this.label9.TabIndex = 19;
            this.label9.Text = "NV Sales";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.Location = new System.Drawing.Point(128, 51);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(210, 26);
            this.diachi.TabIndex = 2;
            // 
            // email
            // 
            this.email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.email.Location = new System.Drawing.Point(128, 94);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(210, 26);
            this.email.TabIndex = 3;
            // 
            // accFtp
            // 
            this.accFtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.accFtp.Location = new System.Drawing.Point(128, 137);
            this.accFtp.Name = "accFtp";
            this.accFtp.Size = new System.Drawing.Size(210, 26);
            this.accFtp.TabIndex = 4;
            // 
            // salesName
            // 
            this.salesName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.salesName.Location = new System.Drawing.Point(523, 51);
            this.salesName.Name = "salesName";
            this.salesName.Size = new System.Drawing.Size(214, 26);
            this.salesName.TabIndex = 7;
            // 
            // vanChuyen
            // 
            this.vanChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.vanChuyen.Location = new System.Drawing.Point(523, 180);
            this.vanChuyen.Name = "vanChuyen";
            this.vanChuyen.Size = new System.Drawing.Size(214, 26);
            this.vanChuyen.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 43);
            this.label2.TabIndex = 12;
            this.label2.Text = "ID khách hàng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(3, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 43);
            this.label3.TabIndex = 13;
            this.label3.Text = "Email";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(3, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 43);
            this.label5.TabIndex = 15;
            this.label5.Text = "Người liên hệ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(3, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 44);
            this.label7.TabIndex = 17;
            this.label7.Text = "SDT";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(389, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 43);
            this.label11.TabIndex = 21;
            this.label11.Text = "Giảm giá (%)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(389, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 43);
            this.label12.TabIndex = 22;
            this.label12.Text = "Vận chuyển";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phoneContact
            // 
            this.phoneContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.phoneContact.Location = new System.Drawing.Point(128, 224);
            this.phoneContact.Name = "phoneContact";
            this.phoneContact.Size = new System.Drawing.Size(210, 26);
            this.phoneContact.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(389, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 44);
            this.label13.TabIndex = 22;
            this.label13.Text = "Ngày hợp tác ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngayHopTac
            // 
            this.ngayHopTac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ngayHopTac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ngayHopTac.Location = new System.Drawing.Point(523, 224);
            this.ngayHopTac.Name = "ngayHopTac";
            this.ngayHopTac.Size = new System.Drawing.Size(214, 26);
            this.ngayHopTac.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(3, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 43);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tài khoản FTP";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddLienHe
            // 
            this.btnAddLienHe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddLienHe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddLienHe.Location = new System.Drawing.Point(344, 180);
            this.btnAddLienHe.Name = "btnAddLienHe";
            this.btnAddLienHe.Size = new System.Drawing.Size(33, 27);
            this.btnAddLienHe.TabIndex = 17;
            this.btnAddLienHe.Text = "+";
            this.btnAddLienHe.UseVisualStyleBackColor = false;
            this.btnAddLienHe.Click += new System.EventHandler(this.btnAddLienHe_Click);
            // 
            // tenKH
            // 
            this.tenKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tenKH.Location = new System.Drawing.Point(523, 8);
            this.tenKH.Name = "tenKH";
            this.tenKH.Size = new System.Drawing.Size(214, 26);
            this.tenKH.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(389, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 43);
            this.label14.TabIndex = 25;
            this.label14.Text = "Tên Khách Hàng";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // idKhachHang
            // 
            this.idKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.idKhachHang.Location = new System.Drawing.Point(128, 8);
            this.idKhachHang.Name = "idKhachHang";
            this.idKhachHang.Size = new System.Drawing.Size(210, 26);
            this.idKhachHang.TabIndex = 0;
            // 
            // cbbContact
            // 
            this.cbbContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbContact.FormattingEnabled = true;
            this.cbbContact.Location = new System.Drawing.Point(128, 183);
            this.cbbContact.Name = "cbbContact";
            this.cbbContact.Size = new System.Drawing.Size(210, 27);
            this.cbbContact.TabIndex = 26;
            this.cbbContact.SelectedIndexChanged += new System.EventHandler(this.cbbContact_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Ghi chú";
            // 
            // notes
            // 
            this.notes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notes.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.notes.Location = new System.Drawing.Point(128, 3);
            this.notes.Multiline = true;
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(609, 94);
            this.notes.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveBtn, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(37, 505);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(690, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(717, 49);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Depth = 0;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(555, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = true;
            this.btnClose.Size = new System.Drawing.Size(145, 36);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.AutoSize = true;
            this.saveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveBtn.Depth = 0;
            this.saveBtn.Icon = null;
            this.saveBtn.Location = new System.Drawing.Point(397, 6);
            this.saveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Primary = true;
            this.saveBtn.Size = new System.Drawing.Size(144, 36);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.notes);
            this.panel1.Location = new System.Drawing.Point(27, 355);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 100);
            this.panel1.TabIndex = 19;
            // 
            // AddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(789, 567);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.infoPnl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(745, 400);
            this.Name = "AddCustomer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHẬP THÔNG TIN KHÁCH HÀNG";
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giamGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesPercent)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel infoPnl;
        private Label label10;
        private Button btnAddLienHe;
        private Label label6;
        private Label label9;
        private TextBox tenKH;
        private TextBox diachi;
        private TextBox email;
        private TextBox accFtp;
        private TextBox salesName;
        private TextBox vanChuyen;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label11;
        private Label label12;
        private TextBox phoneContact;
        private Label label13;
        private DateTimePicker ngayHopTac;
        private Label label8;
        private TextBox notes;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label14;
        private TextBox idKhachHang;
        private ComboBox cbbContact;
        private MaterialSkin.Controls.MaterialRaisedButton saveBtn;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
        private NumericUpDown giamGia;
        private NumericUpDown salesPercent;
        private Panel panel1;
    }
}