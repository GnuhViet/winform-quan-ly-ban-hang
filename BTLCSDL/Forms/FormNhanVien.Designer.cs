﻿namespace BTLCSDL.Forms {
	partial class FormNhanVien {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien));
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties13 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties14 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties15 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties16 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
			this.label1 = new System.Windows.Forms.Label();
			this.formInput = new System.Windows.Forms.Panel();
			this.txtMaCV = new System.Windows.Forms.TextBox();
			this.panelTinhTrang = new System.Windows.Forms.Panel();
			this.radioDangLam = new System.Windows.Forms.RadioButton();
			this.radioNghi = new System.Windows.Forms.RadioButton();
			this.panelGioiTinh = new System.Windows.Forms.Panel();
			this.radioNam = new System.Windows.Forms.RadioButton();
			this.radioNu = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cbbChucVu = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.txtSDT = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNgaySinh = new System.Windows.Forms.DateTimePicker();
			this.txtMaNV = new System.Windows.Forms.TextBox();
			this.btnDongFrom = new System.Windows.Forms.Button();
			this.btnThemSubmit = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtHoTenNV = new System.Windows.Forms.TextBox();
			this.table = new Bunifu.UI.WinForms.BunifuDataGridView();
			this.tabeBtnXoa = new System.Windows.Forms.DataGridViewImageColumn();
			this.tableBtnSua = new System.Windows.Forms.DataGridViewImageColumn();
			this.txtTim = new Bunifu.UI.WinForms.BunifuTextBox();
			this.btnThemNhanVien = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
			this.formInput.SuspendLayout();
			this.panelTinhTrang.SuspendLayout();
			this.panelGioiTinh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(195, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tìm Kiếm Nhân Viên: ";
			// 
			// formInput
			// 
			this.formInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.formInput.Controls.Add(this.txtMaCV);
			this.formInput.Controls.Add(this.panelTinhTrang);
			this.formInput.Controls.Add(this.panelGioiTinh);
			this.formInput.Controls.Add(this.label3);
			this.formInput.Controls.Add(this.label9);
			this.formInput.Controls.Add(this.cbbChucVu);
			this.formInput.Controls.Add(this.label8);
			this.formInput.Controls.Add(this.txtDiaChi);
			this.formInput.Controls.Add(this.txtSDT);
			this.formInput.Controls.Add(this.label7);
			this.formInput.Controls.Add(this.txtNgaySinh);
			this.formInput.Controls.Add(this.txtMaNV);
			this.formInput.Controls.Add(this.btnDongFrom);
			this.formInput.Controls.Add(this.btnThemSubmit);
			this.formInput.Controls.Add(this.label5);
			this.formInput.Controls.Add(this.label4);
			this.formInput.Controls.Add(this.label2);
			this.formInput.Controls.Add(this.txtHoTenNV);
			this.formInput.ForeColor = System.Drawing.SystemColors.ControlText;
			this.formInput.Location = new System.Drawing.Point(428, 141);
			this.formInput.Name = "formInput";
			this.formInput.Size = new System.Drawing.Size(466, 379);
			this.formInput.TabIndex = 7;
			this.formInput.Visible = false;
			// 
			// txtMaCV
			// 
			this.txtMaCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtMaCV.Location = new System.Drawing.Point(373, 218);
			this.txtMaCV.Name = "txtMaCV";
			this.txtMaCV.ReadOnly = true;
			this.txtMaCV.Size = new System.Drawing.Size(81, 29);
			this.txtMaCV.TabIndex = 32;
			this.txtMaCV.Visible = false;
			// 
			// panelTinhTrang
			// 
			this.panelTinhTrang.Controls.Add(this.radioDangLam);
			this.panelTinhTrang.Controls.Add(this.radioNghi);
			this.panelTinhTrang.Location = new System.Drawing.Point(121, 280);
			this.panelTinhTrang.Name = "panelTinhTrang";
			this.panelTinhTrang.Size = new System.Drawing.Size(305, 33);
			this.panelTinhTrang.TabIndex = 31;
			// 
			// radioDangLam
			// 
			this.radioDangLam.AutoSize = true;
			this.radioDangLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.radioDangLam.Location = new System.Drawing.Point(16, 3);
			this.radioDangLam.Name = "radioDangLam";
			this.radioDangLam.Size = new System.Drawing.Size(114, 28);
			this.radioDangLam.TabIndex = 20;
			this.radioDangLam.TabStop = true;
			this.radioDangLam.Text = "Đang Làm";
			this.radioDangLam.UseVisualStyleBackColor = true;
			// 
			// radioNghi
			// 
			this.radioNghi.AutoSize = true;
			this.radioNghi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.radioNghi.Location = new System.Drawing.Point(155, 3);
			this.radioNghi.Name = "radioNghi";
			this.radioNghi.Size = new System.Drawing.Size(109, 28);
			this.radioNghi.TabIndex = 21;
			this.radioNghi.TabStop = true;
			this.radioNghi.Text = "Thôi Việc";
			this.radioNghi.UseVisualStyleBackColor = true;
			// 
			// panelGioiTinh
			// 
			this.panelGioiTinh.Controls.Add(this.radioNam);
			this.panelGioiTinh.Controls.Add(this.radioNu);
			this.panelGioiTinh.Location = new System.Drawing.Point(121, 243);
			this.panelGioiTinh.Name = "panelGioiTinh";
			this.panelGioiTinh.Size = new System.Drawing.Size(246, 33);
			this.panelGioiTinh.TabIndex = 30;
			// 
			// radioNam
			// 
			this.radioNam.AutoSize = true;
			this.radioNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.radioNam.Location = new System.Drawing.Point(16, 3);
			this.radioNam.Name = "radioNam";
			this.radioNam.Size = new System.Drawing.Size(68, 28);
			this.radioNam.TabIndex = 28;
			this.radioNam.TabStop = true;
			this.radioNam.Text = "Nam";
			this.radioNam.UseVisualStyleBackColor = true;
			// 
			// radioNu
			// 
			this.radioNu.AutoSize = true;
			this.radioNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.radioNu.Location = new System.Drawing.Point(155, 3);
			this.radioNu.Name = "radioNu";
			this.radioNu.Size = new System.Drawing.Size(53, 28);
			this.radioNu.TabIndex = 29;
			this.radioNu.TabStop = true;
			this.radioNu.Text = "Nữ";
			this.radioNu.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label3.Location = new System.Drawing.Point(23, 245);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 24);
			this.label3.TabIndex = 27;
			this.label3.Text = "Giới Tính:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label9.Location = new System.Drawing.Point(25, 208);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(89, 24);
			this.label9.TabIndex = 26;
			this.label9.Text = "Chức Vụ:";
			// 
			// cbbChucVu
			// 
			this.cbbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.cbbChucVu.FormattingEnabled = true;
			this.cbbChucVu.Location = new System.Drawing.Point(121, 205);
			this.cbbChucVu.Name = "cbbChucVu";
			this.cbbChucVu.Size = new System.Drawing.Size(305, 32);
			this.cbbChucVu.TabIndex = 25;
			this.cbbChucVu.SelectedIndexChanged += new System.EventHandler(this.cbbChucVu_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label8.Location = new System.Drawing.Point(40, 173);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 24);
			this.label8.TabIndex = 24;
			this.label8.Text = "Địa Chỉ:";
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtDiaChi.Location = new System.Drawing.Point(121, 170);
			this.txtDiaChi.MaxLength = 255;
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(305, 29);
			this.txtDiaChi.TabIndex = 23;
			// 
			// txtSDT
			// 
			this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtSDT.Location = new System.Drawing.Point(121, 135);
			this.txtSDT.MaxLength = 9;
			this.txtSDT.Name = "txtSDT";
			this.txtSDT.Size = new System.Drawing.Size(305, 29);
			this.txtSDT.TabIndex = 22;
			this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
			this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label7.Location = new System.Drawing.Point(6, 285);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(108, 24);
			this.label7.TabIndex = 19;
			this.label7.Text = "Tình Trạng:";
			// 
			// txtNgaySinh
			// 
			this.txtNgaySinh.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtNgaySinh.Location = new System.Drawing.Point(121, 100);
			this.txtNgaySinh.Name = "txtNgaySinh";
			this.txtNgaySinh.Size = new System.Drawing.Size(305, 29);
			this.txtNgaySinh.TabIndex = 13;
			// 
			// txtMaNV
			// 
			this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtMaNV.Location = new System.Drawing.Point(121, 30);
			this.txtMaNV.Name = "txtMaNV";
			this.txtMaNV.ReadOnly = true;
			this.txtMaNV.Size = new System.Drawing.Size(81, 29);
			this.txtMaNV.TabIndex = 12;
			this.txtMaNV.Visible = false;
			// 
			// btnDongFrom
			// 
			this.btnDongFrom.FlatAppearance.BorderSize = 0;
			this.btnDongFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDongFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.btnDongFrom.Image = global::BTLCSDL.Properties.Resources.icons8_macos_close_32__1_;
			this.btnDongFrom.Location = new System.Drawing.Point(401, 0);
			this.btnDongFrom.Name = "btnDongFrom";
			this.btnDongFrom.Size = new System.Drawing.Size(37, 37);
			this.btnDongFrom.TabIndex = 11;
			this.btnDongFrom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDongFrom.UseVisualStyleBackColor = true;
			this.btnDongFrom.Click += new System.EventHandler(this.btnDongFrom_Click);
			// 
			// btnThemSubmit
			// 
			this.btnThemSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.btnThemSubmit.Image = global::BTLCSDL.Properties.Resources.icons8_macos_close_321;
			this.btnThemSubmit.Location = new System.Drawing.Point(176, 327);
			this.btnThemSubmit.Name = "btnThemSubmit";
			this.btnThemSubmit.Size = new System.Drawing.Size(99, 37);
			this.btnThemSubmit.TabIndex = 10;
			this.btnThemSubmit.Text = " thêm";
			this.btnThemSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnThemSubmit.UseVisualStyleBackColor = true;
			this.btnThemSubmit.Click += new System.EventHandler(this.btnThemSubmit_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label5.Location = new System.Drawing.Point(14, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(102, 24);
			this.label5.TabIndex = 7;
			this.label5.Text = "Ngày Sinh:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label4.Location = new System.Drawing.Point(63, 140);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "SDT:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label2.Location = new System.Drawing.Point(66, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tên:";
			// 
			// txtHoTenNV
			// 
			this.txtHoTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtHoTenNV.Location = new System.Drawing.Point(121, 65);
			this.txtHoTenNV.MaxLength = 255;
			this.txtHoTenNV.Name = "txtHoTenNV";
			this.txtHoTenNV.Size = new System.Drawing.Size(305, 29);
			this.txtHoTenNV.TabIndex = 0;
			// 
			// table
			// 
			this.table.AllowCustomTheming = false;
			this.table.AllowUserToAddRows = false;
			this.table.AllowUserToDeleteRows = false;
			this.table.AllowUserToResizeColumns = false;
			this.table.AllowUserToResizeRows = false;
			dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
			this.table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
			this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.table.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.table.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.table.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle14.BackColor = System.Drawing.Color.DodgerBlue;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
			this.table.ColumnHeadersHeight = 40;
			this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tabeBtnXoa,
            this.tableBtnSua});
			this.table.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
			this.table.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.table.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
			this.table.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
			this.table.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
			this.table.CurrentTheme.BackColor = System.Drawing.Color.White;
			this.table.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
			this.table.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
			this.table.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
			this.table.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.table.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
			this.table.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
			this.table.CurrentTheme.Name = null;
			this.table.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
			this.table.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.table.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
			this.table.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
			this.table.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.table.DefaultCellStyle = dataGridViewCellStyle15;
			this.table.EnableHeadersVisualStyles = false;
			this.table.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
			this.table.HeaderBackColor = System.Drawing.Color.DodgerBlue;
			this.table.HeaderBgColor = System.Drawing.Color.Empty;
			this.table.HeaderForeColor = System.Drawing.Color.White;
			this.table.Location = new System.Drawing.Point(12, 84);
			this.table.Name = "table";
			this.table.ReadOnly = true;
			this.table.RowHeadersVisible = false;
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.table.RowsDefaultCellStyle = dataGridViewCellStyle16;
			this.table.RowTemplate.Height = 40;
			this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.table.Size = new System.Drawing.Size(1326, 660);
			this.table.TabIndex = 26;
			this.table.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
			this.table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellContentClick);
			// 
			// tabeBtnXoa
			// 
			this.tabeBtnXoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.tabeBtnXoa.FillWeight = 159.3909F;
			this.tabeBtnXoa.HeaderText = "Xoa";
			this.tabeBtnXoa.Image = global::BTLCSDL.Properties.Resources.icons8_close_20;
			this.tabeBtnXoa.Name = "tabeBtnXoa";
			this.tabeBtnXoa.ReadOnly = true;
			this.tabeBtnXoa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.tabeBtnXoa.Width = 40;
			// 
			// tableBtnSua
			// 
			this.tableBtnSua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.tableBtnSua.FillWeight = 40.60914F;
			this.tableBtnSua.HeaderText = "Sua";
			this.tableBtnSua.Image = global::BTLCSDL.Properties.Resources.icons8_option_20;
			this.tableBtnSua.Name = "tableBtnSua";
			this.tableBtnSua.ReadOnly = true;
			this.tableBtnSua.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.tableBtnSua.Width = 40;
			// 
			// txtTim
			// 
			this.txtTim.AcceptsReturn = false;
			this.txtTim.AcceptsTab = false;
			this.txtTim.AnimationSpeed = 200;
			this.txtTim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.txtTim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.txtTim.BackColor = System.Drawing.Color.Transparent;
			this.txtTim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTim.BackgroundImage")));
			this.txtTim.BorderColorActive = System.Drawing.Color.DodgerBlue;
			this.txtTim.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.txtTim.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
			this.txtTim.BorderColorIdle = System.Drawing.Color.Silver;
			this.txtTim.BorderRadius = 25;
			this.txtTim.BorderThickness = 2;
			this.txtTim.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtTim.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtTim.DefaultFont = new System.Drawing.Font("Segoe UI", 14F);
			this.txtTim.DefaultText = "";
			this.txtTim.FillColor = System.Drawing.Color.White;
			this.txtTim.HideSelection = true;
			this.txtTim.IconLeft = null;
			this.txtTim.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.txtTim.IconPadding = 10;
			this.txtTim.IconRight = null;
			this.txtTim.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.txtTim.Lines = new string[0];
			this.txtTim.Location = new System.Drawing.Point(213, 3);
			this.txtTim.MaxLength = 32767;
			this.txtTim.MinimumSize = new System.Drawing.Size(1, 1);
			this.txtTim.Modified = false;
			this.txtTim.Multiline = false;
			this.txtTim.Name = "txtTim";
			stateProperties13.BorderColor = System.Drawing.Color.DodgerBlue;
			stateProperties13.FillColor = System.Drawing.Color.Empty;
			stateProperties13.ForeColor = System.Drawing.Color.Empty;
			stateProperties13.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtTim.OnActiveState = stateProperties13;
			stateProperties14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			stateProperties14.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			stateProperties14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			stateProperties14.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.txtTim.OnDisabledState = stateProperties14;
			stateProperties15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
			stateProperties15.FillColor = System.Drawing.Color.Empty;
			stateProperties15.ForeColor = System.Drawing.Color.Empty;
			stateProperties15.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtTim.OnHoverState = stateProperties15;
			stateProperties16.BorderColor = System.Drawing.Color.Silver;
			stateProperties16.FillColor = System.Drawing.Color.White;
			stateProperties16.ForeColor = System.Drawing.Color.Empty;
			stateProperties16.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtTim.OnIdleState = stateProperties16;
			this.txtTim.Padding = new System.Windows.Forms.Padding(3);
			this.txtTim.PasswordChar = '\0';
			this.txtTim.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.txtTim.PlaceholderText = "Nhập Tên Nhân Viên";
			this.txtTim.ReadOnly = false;
			this.txtTim.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtTim.SelectedText = "";
			this.txtTim.SelectionLength = 0;
			this.txtTim.SelectionStart = 0;
			this.txtTim.ShortcutsEnabled = true;
			this.txtTim.Size = new System.Drawing.Size(1019, 37);
			this.txtTim.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
			this.txtTim.TabIndex = 27;
			this.txtTim.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtTim.TextMarginBottom = 0;
			this.txtTim.TextMarginLeft = 3;
			this.txtTim.TextMarginTop = 0;
			this.txtTim.TextPlaceholder = "Nhập Tên Nhân Viên";
			this.txtTim.UseSystemPasswordChar = false;
			this.txtTim.WordWrap = true;
			this.txtTim.TextChange += new System.EventHandler(this.txtTim_TextChanged);
			// 
			// btnThemNhanVien
			// 
			this.btnThemNhanVien.AllowAnimations = true;
			this.btnThemNhanVien.AllowMouseEffects = true;
			this.btnThemNhanVien.AllowToggling = false;
			this.btnThemNhanVien.AnimationSpeed = 200;
			this.btnThemNhanVien.AutoGenerateColors = false;
			this.btnThemNhanVien.AutoRoundBorders = false;
			this.btnThemNhanVien.AutoSizeLeftIcon = true;
			this.btnThemNhanVien.AutoSizeRightIcon = true;
			this.btnThemNhanVien.BackColor = System.Drawing.Color.Transparent;
			this.btnThemNhanVien.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThemNhanVien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThemNhanVien.BackgroundImage")));
			this.btnThemNhanVien.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThemNhanVien.ButtonText = "Thêm Mới";
			this.btnThemNhanVien.ButtonTextMarginLeft = 0;
			this.btnThemNhanVien.ColorContrastOnClick = 45;
			this.btnThemNhanVien.ColorContrastOnHover = 45;
			this.btnThemNhanVien.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges4.BottomLeft = true;
			borderEdges4.BottomRight = true;
			borderEdges4.TopLeft = true;
			borderEdges4.TopRight = true;
			this.btnThemNhanVien.CustomizableEdges = borderEdges4;
			this.btnThemNhanVien.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnThemNhanVien.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
			this.btnThemNhanVien.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.btnThemNhanVien.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
			this.btnThemNhanVien.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
			this.btnThemNhanVien.Font = new System.Drawing.Font("Segoe UI", 14F);
			this.btnThemNhanVien.ForeColor = System.Drawing.Color.White;
			this.btnThemNhanVien.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThemNhanVien.IconLeftCursor = System.Windows.Forms.Cursors.Default;
			this.btnThemNhanVien.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
			this.btnThemNhanVien.IconMarginLeft = 11;
			this.btnThemNhanVien.IconPadding = 10;
			this.btnThemNhanVien.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThemNhanVien.IconRightCursor = System.Windows.Forms.Cursors.Default;
			this.btnThemNhanVien.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
			this.btnThemNhanVien.IconSize = 25;
			this.btnThemNhanVien.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThemNhanVien.IdleBorderRadius = 25;
			this.btnThemNhanVien.IdleBorderThickness = 1;
			this.btnThemNhanVien.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThemNhanVien.IdleIconLeftImage = null;
			this.btnThemNhanVien.IdleIconRightImage = null;
			this.btnThemNhanVien.IndicateFocus = false;
			this.btnThemNhanVien.Location = new System.Drawing.Point(1238, 3);
			this.btnThemNhanVien.Name = "btnThemNhanVien";
			this.btnThemNhanVien.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
			this.btnThemNhanVien.OnDisabledState.BorderRadius = 25;
			this.btnThemNhanVien.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThemNhanVien.OnDisabledState.BorderThickness = 1;
			this.btnThemNhanVien.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.btnThemNhanVien.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
			this.btnThemNhanVien.OnDisabledState.IconLeftImage = null;
			this.btnThemNhanVien.OnDisabledState.IconRightImage = null;
			this.btnThemNhanVien.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
			this.btnThemNhanVien.onHoverState.BorderRadius = 25;
			this.btnThemNhanVien.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThemNhanVien.onHoverState.BorderThickness = 1;
			this.btnThemNhanVien.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
			this.btnThemNhanVien.onHoverState.ForeColor = System.Drawing.Color.White;
			this.btnThemNhanVien.onHoverState.IconLeftImage = null;
			this.btnThemNhanVien.onHoverState.IconRightImage = null;
			this.btnThemNhanVien.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThemNhanVien.OnIdleState.BorderRadius = 25;
			this.btnThemNhanVien.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThemNhanVien.OnIdleState.BorderThickness = 1;
			this.btnThemNhanVien.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThemNhanVien.OnIdleState.ForeColor = System.Drawing.Color.White;
			this.btnThemNhanVien.OnIdleState.IconLeftImage = null;
			this.btnThemNhanVien.OnIdleState.IconRightImage = null;
			this.btnThemNhanVien.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
			this.btnThemNhanVien.OnPressedState.BorderRadius = 25;
			this.btnThemNhanVien.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThemNhanVien.OnPressedState.BorderThickness = 1;
			this.btnThemNhanVien.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
			this.btnThemNhanVien.OnPressedState.ForeColor = System.Drawing.Color.White;
			this.btnThemNhanVien.OnPressedState.IconLeftImage = null;
			this.btnThemNhanVien.OnPressedState.IconRightImage = null;
			this.btnThemNhanVien.Size = new System.Drawing.Size(100, 37);
			this.btnThemNhanVien.TabIndex = 28;
			this.btnThemNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnThemNhanVien.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.btnThemNhanVien.TextMarginLeft = 0;
			this.btnThemNhanVien.TextPadding = new System.Windows.Forms.Padding(0);
			this.btnThemNhanVien.UseDefaultRadiusAndThickness = true;
			this.btnThemNhanVien.Click += new System.EventHandler(this.btnThemNhanVien_Click);
			// 
			// FormNhanVien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
			this.ClientSize = new System.Drawing.Size(1350, 765);
			this.Controls.Add(this.btnThemNhanVien);
			this.Controls.Add(this.txtTim);
			this.Controls.Add(this.formInput);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.table);
			this.Name = "FormNhanVien";
			this.Text = "FormNhanVien";
			this.Load += new System.EventHandler(this.FormSanPham_Load);
			this.formInput.ResumeLayout(false);
			this.formInput.PerformLayout();
			this.panelTinhTrang.ResumeLayout(false);
			this.panelTinhTrang.PerformLayout();
			this.panelGioiTinh.ResumeLayout(false);
			this.panelGioiTinh.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel formInput;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtHoTenNV;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnDongFrom;
		private System.Windows.Forms.Button btnThemSubmit;
		private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.DateTimePicker txtNgaySinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioNghi;
        private System.Windows.Forms.RadioButton radioDangLam;
		private System.Windows.Forms.TextBox txtSDT;
        private Bunifu.UI.WinForms.BunifuDataGridView table;
        private System.Windows.Forms.DataGridViewImageColumn tabeBtnXoa;
        private System.Windows.Forms.DataGridViewImageColumn tableBtnSua;
        private System.Windows.Forms.RadioButton radioNu;
        private System.Windows.Forms.RadioButton radioNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbChucVu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiaChi;
        private Bunifu.UI.WinForms.BunifuTextBox txtTim;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnThemNhanVien;
        private System.Windows.Forms.Panel panelTinhTrang;
        private System.Windows.Forms.Panel panelGioiTinh;
		private System.Windows.Forms.TextBox txtMaCV;
	}
}