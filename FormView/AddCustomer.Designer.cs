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
            this.label1 = new System.Windows.Forms.Label();
            this.mainPnl = new System.Windows.Forms.TableLayoutPanel();
            this.infoPnl = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.accFtp = new System.Windows.Forms.TextBox();
            this.salesName = new System.Windows.Forms.TextBox();
            this.salesPercent = new System.Windows.Forms.TextBox();
            this.giamGia = new System.Windows.Forms.TextBox();
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
            this.notePnl = new System.Windows.Forms.TableLayoutPanel();
            this.notes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.cbbContact = new System.Windows.Forms.ComboBox();
            this.mainPnl.SuspendLayout();
            this.infoPnl.SuspendLayout();
            this.notePnl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "NHẬP THÔNG TIN KHÁCH HÀNG";
            // 
            // mainPnl
            // 
            this.mainPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPnl.ColumnCount = 1;
            this.mainPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainPnl.Controls.Add(this.infoPnl, 0, 0);
            this.mainPnl.Controls.Add(this.notePnl, 0, 1);
            this.mainPnl.Location = new System.Drawing.Point(18, 56);
            this.mainPnl.MinimumSize = new System.Drawing.Size(690, 280);
            this.mainPnl.Name = "mainPnl";
            this.mainPnl.RowCount = 2;
            this.mainPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.31579F));
            this.mainPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.68421F));
            this.mainPnl.Size = new System.Drawing.Size(811, 384);
            this.mainPnl.TabIndex = 16;
            // 
            // infoPnl
            // 
            this.infoPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.infoPnl.ColumnCount = 5;
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.infoPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.infoPnl.Controls.Add(this.label10, 3, 2);
            this.infoPnl.Controls.Add(this.label6, 0, 1);
            this.infoPnl.Controls.Add(this.label9, 3, 1);
            this.infoPnl.Controls.Add(this.diachi, 1, 1);
            this.infoPnl.Controls.Add(this.email, 1, 2);
            this.infoPnl.Controls.Add(this.accFtp, 1, 3);
            this.infoPnl.Controls.Add(this.salesName, 4, 1);
            this.infoPnl.Controls.Add(this.salesPercent, 4, 2);
            this.infoPnl.Controls.Add(this.giamGia, 4, 3);
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
            this.infoPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPnl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.infoPnl.Location = new System.Drawing.Point(3, 3);
            this.infoPnl.Name = "infoPnl";
            this.infoPnl.RowCount = 6;
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.infoPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.infoPnl.Size = new System.Drawing.Size(805, 248);
            this.infoPnl.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(428, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 41);
            this.label10.TabIndex = 20;
            this.label10.Text = "% NV Sales";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 41);
            this.label6.TabIndex = 16;
            this.label6.Text = "Địa chỉ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(428, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 41);
            this.label9.TabIndex = 19;
            this.label9.Text = "Sales";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.Location = new System.Drawing.Point(139, 48);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(235, 26);
            this.diachi.TabIndex = 2;
            // 
            // email
            // 
            this.email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.email.Location = new System.Drawing.Point(139, 89);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(235, 26);
            this.email.TabIndex = 3;
            // 
            // accFtp
            // 
            this.accFtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.accFtp.Location = new System.Drawing.Point(139, 130);
            this.accFtp.Name = "accFtp";
            this.accFtp.Size = new System.Drawing.Size(235, 26);
            this.accFtp.TabIndex = 4;
            // 
            // salesName
            // 
            this.salesName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.salesName.Location = new System.Drawing.Point(564, 48);
            this.salesName.Name = "salesName";
            this.salesName.Size = new System.Drawing.Size(238, 26);
            this.salesName.TabIndex = 7;
            // 
            // salesPercent
            // 
            this.salesPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.salesPercent.Location = new System.Drawing.Point(564, 89);
            this.salesPercent.Name = "salesPercent";
            this.salesPercent.Size = new System.Drawing.Size(238, 26);
            this.salesPercent.TabIndex = 8;
            // 
            // giamGia
            // 
            this.giamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.giamGia.Location = new System.Drawing.Point(564, 130);
            this.giamGia.Name = "giamGia";
            this.giamGia.Size = new System.Drawing.Size(238, 26);
            this.giamGia.TabIndex = 9;
            // 
            // vanChuyen
            // 
            this.vanChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.vanChuyen.Location = new System.Drawing.Point(564, 171);
            this.vanChuyen.Name = "vanChuyen";
            this.vanChuyen.Size = new System.Drawing.Size(238, 26);
            this.vanChuyen.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 41);
            this.label2.TabIndex = 12;
            this.label2.Text = "ID khách hàng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(3, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 41);
            this.label3.TabIndex = 13;
            this.label3.Text = "Email";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(3, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 41);
            this.label5.TabIndex = 15;
            this.label5.Text = "Người liên hệ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(3, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 43);
            this.label7.TabIndex = 17;
            this.label7.Text = "SDT";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(428, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 41);
            this.label11.TabIndex = 21;
            this.label11.Text = "% Giảm giá";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(428, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 41);
            this.label12.TabIndex = 22;
            this.label12.Text = "Vận chuyển";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phoneContact
            // 
            this.phoneContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.phoneContact.Location = new System.Drawing.Point(139, 213);
            this.phoneContact.Name = "phoneContact";
            this.phoneContact.Size = new System.Drawing.Size(235, 26);
            this.phoneContact.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(428, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 43);
            this.label13.TabIndex = 22;
            this.label13.Text = "Ngày hợp tác ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngayHopTac
            // 
            this.ngayHopTac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ngayHopTac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ngayHopTac.Location = new System.Drawing.Point(564, 213);
            this.ngayHopTac.Name = "ngayHopTac";
            this.ngayHopTac.Size = new System.Drawing.Size(238, 26);
            this.ngayHopTac.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(3, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 41);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tài khoản FTP";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddLienHe
            // 
            this.btnAddLienHe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddLienHe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddLienHe.Location = new System.Drawing.Point(380, 171);
            this.btnAddLienHe.Name = "btnAddLienHe";
            this.btnAddLienHe.Size = new System.Drawing.Size(35, 27);
            this.btnAddLienHe.TabIndex = 17;
            this.btnAddLienHe.Text = "+";
            this.btnAddLienHe.UseVisualStyleBackColor = false;
            this.btnAddLienHe.Click += new System.EventHandler(this.btnAddLienHe_Click);
            // 
            // tenKH
            // 
            this.tenKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tenKH.Location = new System.Drawing.Point(564, 7);
            this.tenKH.Name = "tenKH";
            this.tenKH.Size = new System.Drawing.Size(238, 26);
            this.tenKH.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(428, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 41);
            this.label14.TabIndex = 25;
            this.label14.Text = "Tên Khách Hàng";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // idKhachHang
            // 
            this.idKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.idKhachHang.Location = new System.Drawing.Point(139, 7);
            this.idKhachHang.Name = "idKhachHang";
            this.idKhachHang.Size = new System.Drawing.Size(235, 26);
            this.idKhachHang.TabIndex = 0;
            // 
            // notePnl
            // 
            this.notePnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notePnl.ColumnCount = 1;
            this.notePnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.notePnl.Controls.Add(this.notes, 0, 1);
            this.notePnl.Controls.Add(this.label8, 0, 0);
            this.notePnl.Location = new System.Drawing.Point(3, 257);
            this.notePnl.Name = "notePnl";
            this.notePnl.RowCount = 3;
            this.notePnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.10092F));
            this.notePnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.89909F));
            this.notePnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.notePnl.Size = new System.Drawing.Size(805, 124);
            this.notePnl.TabIndex = 1;
            // 
            // notes
            // 
            this.notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notes.Location = new System.Drawing.Point(3, 27);
            this.notes.Multiline = true;
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(799, 84);
            this.notes.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Ghi chú";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.saveBtn, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.backBtn, 6, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 456);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(690, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 37);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.saveBtn.Location = new System.Drawing.Point(246, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 31);
            this.saveBtn.TabIndex = 13;
            this.saveBtn.Text = "Lưu";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.backBtn.Location = new System.Drawing.Point(489, 3);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 31);
            this.backBtn.TabIndex = 14;
            this.backBtn.Text = "Trở về";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // cbbContact
            // 
            this.cbbContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbContact.FormattingEnabled = true;
            this.cbbContact.Location = new System.Drawing.Point(139, 171);
            this.cbbContact.Name = "cbbContact";
            this.cbbContact.Size = new System.Drawing.Size(235, 27);
            this.cbbContact.TabIndex = 26;
            this.cbbContact.SelectedIndexChanged += new System.EventHandler(this.cbbContact_SelectedIndexChanged);
            // 
            // AddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(848, 501);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainPnl);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(745, 400);
            this.Name = "AddCustomer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KhachHang";
            this.mainPnl.ResumeLayout(false);
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            this.notePnl.ResumeLayout(false);
            this.notePnl.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private TableLayoutPanel mainPnl;
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
        private TextBox salesPercent;
        private TextBox giamGia;
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
        private TableLayoutPanel notePnl;
        private Label label8;
        private TextBox notes;
        private TableLayoutPanel tableLayoutPanel1;
        private Button saveBtn;
        private Button backBtn;
        private Label label14;
        private TextBox idKhachHang;
        private ComboBox cbbContact;
    }
}