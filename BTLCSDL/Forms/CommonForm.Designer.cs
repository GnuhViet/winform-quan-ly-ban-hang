namespace BTLCSDL.Forms {
	partial class CommonForm {
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
		/// 
		private void InitializeComponent() {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonForm));
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
			this.labelTimKiem = new System.Windows.Forms.Label();
			this.formInput = new System.Windows.Forms.Panel();
			this.txtMa = new System.Windows.Forms.TextBox();
			this.btnDongFrom = new System.Windows.Forms.Button();
			this.btnThemSubmit = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTen = new System.Windows.Forms.TextBox();
			this.table = new Bunifu.UI.WinForms.BunifuDataGridView();
			this.txtTim = new Bunifu.UI.WinForms.BunifuTextBox();
			this.btnThem = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
			this.tabeBtnXoa = new System.Windows.Forms.DataGridViewImageColumn();
			this.tableBtnSua = new System.Windows.Forms.DataGridViewImageColumn();
			this.formInput.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTimKiem
			// 
			this.labelTimKiem.AutoSize = true;
			this.labelTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.labelTimKiem.Location = new System.Drawing.Point(12, 9);
			this.labelTimKiem.Name = "labelTimKiem";
			this.labelTimKiem.Size = new System.Drawing.Size(95, 24);
			this.labelTimKiem.TabIndex = 2;
			this.labelTimKiem.Text = "Tìm Kiếm ";
			// 
			// formInput
			// 
			this.formInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.formInput.Controls.Add(this.txtMa);
			this.formInput.Controls.Add(this.btnDongFrom);
			this.formInput.Controls.Add(this.btnThemSubmit);
			this.formInput.Controls.Add(this.label2);
			this.formInput.Controls.Add(this.txtTen);
			this.formInput.ForeColor = System.Drawing.SystemColors.ControlText;
			this.formInput.Location = new System.Drawing.Point(428, 141);
			this.formInput.Name = "formInput";
			this.formInput.Size = new System.Drawing.Size(466, 162);
			this.formInput.TabIndex = 7;
			this.formInput.Visible = false;
			// 
			// txtMa
			// 
			this.txtMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtMa.Location = new System.Drawing.Point(121, 30);
			this.txtMa.Name = "txtMa";
			this.txtMa.ReadOnly = true;
			this.txtMa.Size = new System.Drawing.Size(81, 29);
			this.txtMa.TabIndex = 12;
			this.txtMa.Visible = false;
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
			this.btnThemSubmit.Location = new System.Drawing.Point(195, 100);
			this.btnThemSubmit.Name = "btnThemSubmit";
			this.btnThemSubmit.Size = new System.Drawing.Size(99, 37);
			this.btnThemSubmit.TabIndex = 10;
			this.btnThemSubmit.Text = " thêm";
			this.btnThemSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnThemSubmit.UseVisualStyleBackColor = true;
			this.btnThemSubmit.Click += new System.EventHandler(this.btnThemSubmit_Click);
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
			// txtTen
			// 
			this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtTen.Location = new System.Drawing.Point(121, 65);
			this.txtTen.MaxLength = 255;
			this.txtTen.Name = "txtTen";
			this.txtTen.Size = new System.Drawing.Size(305, 29);
			this.txtTen.TabIndex = 0;
			// 
			// table
			// 
			this.table.AllowCustomTheming = false;
			this.table.AllowUserToAddRows = false;
			this.table.AllowUserToDeleteRows = false;
			this.table.AllowUserToResizeColumns = false;
			this.table.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			this.table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.table.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.table.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.table.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.table.DefaultCellStyle = dataGridViewCellStyle3;
			this.table.EnableHeadersVisualStyles = false;
			this.table.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
			this.table.HeaderBackColor = System.Drawing.Color.DodgerBlue;
			this.table.HeaderBgColor = System.Drawing.Color.Empty;
			this.table.HeaderForeColor = System.Drawing.Color.White;
			this.table.Location = new System.Drawing.Point(12, 84);
			this.table.Name = "table";
			this.table.ReadOnly = true;
			this.table.RowHeadersVisible = false;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.table.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.table.RowTemplate.Height = 40;
			this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.table.Size = new System.Drawing.Size(1326, 660);
			this.table.TabIndex = 26;
			this.table.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
			this.table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellContentClick);
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
			stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
			stateProperties1.FillColor = System.Drawing.Color.Empty;
			stateProperties1.ForeColor = System.Drawing.Color.Empty;
			stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtTim.OnActiveState = stateProperties1;
			stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.txtTim.OnDisabledState = stateProperties2;
			stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
			stateProperties3.FillColor = System.Drawing.Color.Empty;
			stateProperties3.ForeColor = System.Drawing.Color.Empty;
			stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtTim.OnHoverState = stateProperties3;
			stateProperties4.BorderColor = System.Drawing.Color.Silver;
			stateProperties4.FillColor = System.Drawing.Color.White;
			stateProperties4.ForeColor = System.Drawing.Color.Empty;
			stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtTim.OnIdleState = stateProperties4;
			this.txtTim.Padding = new System.Windows.Forms.Padding(3);
			this.txtTim.PasswordChar = '\0';
			this.txtTim.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.txtTim.PlaceholderText = "Nhập Tên ";
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
			this.txtTim.TextPlaceholder = "Nhập Tên ";
			this.txtTim.UseSystemPasswordChar = false;
			this.txtTim.WordWrap = true;
			this.txtTim.TextChange += new System.EventHandler(this.txtTim_TextChanged);
			// 
			// btnThem
			// 
			this.btnThem.AllowAnimations = true;
			this.btnThem.AllowMouseEffects = true;
			this.btnThem.AllowToggling = false;
			this.btnThem.AnimationSpeed = 200;
			this.btnThem.AutoGenerateColors = false;
			this.btnThem.AutoRoundBorders = false;
			this.btnThem.AutoSizeLeftIcon = true;
			this.btnThem.AutoSizeRightIcon = true;
			this.btnThem.BackColor = System.Drawing.Color.Transparent;
			this.btnThem.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThem.BackgroundImage")));
			this.btnThem.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThem.ButtonText = "Thêm Mới";
			this.btnThem.ButtonTextMarginLeft = 0;
			this.btnThem.ColorContrastOnClick = 45;
			this.btnThem.ColorContrastOnHover = 45;
			this.btnThem.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges1.BottomLeft = true;
			borderEdges1.BottomRight = true;
			borderEdges1.TopLeft = true;
			borderEdges1.TopRight = true;
			this.btnThem.CustomizableEdges = borderEdges1;
			this.btnThem.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnThem.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
			this.btnThem.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.btnThem.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
			this.btnThem.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
			this.btnThem.Font = new System.Drawing.Font("Segoe UI", 14F);
			this.btnThem.ForeColor = System.Drawing.Color.White;
			this.btnThem.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.IconLeftCursor = System.Windows.Forms.Cursors.Default;
			this.btnThem.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
			this.btnThem.IconMarginLeft = 11;
			this.btnThem.IconPadding = 10;
			this.btnThem.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThem.IconRightCursor = System.Windows.Forms.Cursors.Default;
			this.btnThem.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
			this.btnThem.IconSize = 25;
			this.btnThem.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThem.IdleBorderRadius = 25;
			this.btnThem.IdleBorderThickness = 1;
			this.btnThem.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThem.IdleIconLeftImage = null;
			this.btnThem.IdleIconRightImage = null;
			this.btnThem.IndicateFocus = false;
			this.btnThem.Location = new System.Drawing.Point(1238, 3);
			this.btnThem.Name = "btnThem";
			this.btnThem.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
			this.btnThem.OnDisabledState.BorderRadius = 25;
			this.btnThem.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThem.OnDisabledState.BorderThickness = 1;
			this.btnThem.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.btnThem.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
			this.btnThem.OnDisabledState.IconLeftImage = null;
			this.btnThem.OnDisabledState.IconRightImage = null;
			this.btnThem.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
			this.btnThem.onHoverState.BorderRadius = 25;
			this.btnThem.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThem.onHoverState.BorderThickness = 1;
			this.btnThem.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
			this.btnThem.onHoverState.ForeColor = System.Drawing.Color.White;
			this.btnThem.onHoverState.IconLeftImage = null;
			this.btnThem.onHoverState.IconRightImage = null;
			this.btnThem.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThem.OnIdleState.BorderRadius = 25;
			this.btnThem.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThem.OnIdleState.BorderThickness = 1;
			this.btnThem.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
			this.btnThem.OnIdleState.ForeColor = System.Drawing.Color.White;
			this.btnThem.OnIdleState.IconLeftImage = null;
			this.btnThem.OnIdleState.IconRightImage = null;
			this.btnThem.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
			this.btnThem.OnPressedState.BorderRadius = 25;
			this.btnThem.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
			this.btnThem.OnPressedState.BorderThickness = 1;
			this.btnThem.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
			this.btnThem.OnPressedState.ForeColor = System.Drawing.Color.White;
			this.btnThem.OnPressedState.IconLeftImage = null;
			this.btnThem.OnPressedState.IconRightImage = null;
			this.btnThem.Size = new System.Drawing.Size(100, 37);
			this.btnThem.TabIndex = 28;
			this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnThem.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.btnThem.TextMarginLeft = 0;
			this.btnThem.TextPadding = new System.Windows.Forms.Padding(0);
			this.btnThem.UseDefaultRadiusAndThickness = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// tabeBtnXoa
			// 
			this.tabeBtnXoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.tabeBtnXoa.FillWeight = 159.3909F;
			this.tabeBtnXoa.HeaderText = "Xoá";
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
			this.tableBtnSua.HeaderText = "Sửa";
			this.tableBtnSua.Image = global::BTLCSDL.Properties.Resources.icons8_option_20;
			this.tableBtnSua.Name = "tableBtnSua";
			this.tableBtnSua.ReadOnly = true;
			this.tableBtnSua.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.tableBtnSua.Width = 40;
			// 
			// CommonForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
			this.ClientSize = new System.Drawing.Size(1350, 765);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.txtTim);
			this.Controls.Add(this.formInput);
			this.Controls.Add(this.labelTimKiem);
			this.Controls.Add(this.table);
			this.Name = "CommonForm";
			this.Text = "FormChucVu";
			this.Load += new System.EventHandler(this.Form_Load);
			this.formInput.ResumeLayout(false);
			this.formInput.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelTimKiem;
		private System.Windows.Forms.Panel formInput;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTen;
		private System.Windows.Forms.Button btnDongFrom;
		private System.Windows.Forms.Button btnThemSubmit;
        private Bunifu.UI.WinForms.BunifuDataGridView table;
        private Bunifu.UI.WinForms.BunifuTextBox txtTim;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnThem;
		private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.DataGridViewImageColumn tabeBtnXoa;
        private System.Windows.Forms.DataGridViewImageColumn tableBtnSua;
    }
}