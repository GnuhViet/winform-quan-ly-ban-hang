namespace BTLCSDL.Forms {
	partial class FormThongKe {
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.top10SanPhamBanChay = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.top10sp = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.bangLuong = new System.Windows.Forms.DataGridView();
			this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label2 = new System.Windows.Forms.Label();
			this.txtThangBD = new System.Windows.Forms.NumericUpDown();
			this.txtThangKT = new System.Windows.Forms.NumericUpDown();
			this.txtNam = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.top10SanPhamBanChay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bangLuong)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtThangBD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtThangKT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
			this.SuspendLayout();
			// 
			// top10SanPhamBanChay
			// 
			chartArea1.Name = "ChartArea1";
			this.top10SanPhamBanChay.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.top10SanPhamBanChay.Legends.Add(legend1);
			this.top10SanPhamBanChay.Location = new System.Drawing.Point(12, 42);
			this.top10SanPhamBanChay.Name = "top10SanPhamBanChay";
			this.top10SanPhamBanChay.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.top10SanPhamBanChay.Size = new System.Drawing.Size(396, 168);
			this.top10SanPhamBanChay.TabIndex = 0;
			this.top10SanPhamBanChay.Text = "chart1";
			// 
			// top10sp
			// 
			this.top10sp.AutoSize = true;
			this.top10sp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
			this.top10sp.Location = new System.Drawing.Point(52, 17);
			this.top10sp.Name = "top10sp";
			this.top10sp.Size = new System.Drawing.Size(282, 22);
			this.top10sp.TabIndex = 1;
			this.top10sp.Text = "Top 10 Sản Phẩm Bán Chạy Nhất";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
			this.label1.Location = new System.Drawing.Point(553, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(196, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "Bảng Lương Nhân Viên";
			// 
			// bangLuong
			// 
			this.bangLuong.AllowUserToAddRows = false;
			this.bangLuong.AllowUserToDeleteRows = false;
			this.bangLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.bangLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.bangLuong.Location = new System.Drawing.Point(430, 42);
			this.bangLuong.Name = "bangLuong";
			this.bangLuong.ReadOnly = true;
			this.bangLuong.RowHeadersVisible = false;
			this.bangLuong.Size = new System.Drawing.Size(448, 168);
			this.bangLuong.TabIndex = 5;
			// 
			// chartDoanhThu
			// 
			chartArea2.Name = "ChartArea1";
			this.chartDoanhThu.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend1";
			this.chartDoanhThu.Legends.Add(legend2);
			this.chartDoanhThu.Location = new System.Drawing.Point(12, 264);
			this.chartDoanhThu.Name = "chartDoanhThu";
			this.chartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Tháng";
			this.chartDoanhThu.Series.Add(series1);
			this.chartDoanhThu.Size = new System.Drawing.Size(866, 267);
			this.chartDoanhThu.TabIndex = 6;
			this.chartDoanhThu.Text = "chart1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
			this.label2.Location = new System.Drawing.Point(52, 239);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(313, 22);
			this.label2.TabIndex = 7;
			this.label2.Text = "Doanh Thu Khoảng Thời Gian(tháng):";
			// 
			// txtThangBD
			// 
			this.txtThangBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtThangBD.Location = new System.Drawing.Point(543, 233);
			this.txtThangBD.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.txtThangBD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.txtThangBD.Name = "txtThangBD";
			this.txtThangBD.Size = new System.Drawing.Size(48, 29);
			this.txtThangBD.TabIndex = 8;
			this.txtThangBD.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.txtThangBD.ValueChanged += new System.EventHandler(this.txtThangBD_ValueChanged);
			// 
			// txtThangKT
			// 
			this.txtThangKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtThangKT.Location = new System.Drawing.Point(684, 233);
			this.txtThangKT.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.txtThangKT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.txtThangKT.Name = "txtThangKT";
			this.txtThangKT.Size = new System.Drawing.Size(47, 29);
			this.txtThangKT.TabIndex = 9;
			this.txtThangKT.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.txtThangKT.ValueChanged += new System.EventHandler(this.txtThangBD_ValueChanged);
			// 
			// txtNam
			// 
			this.txtNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtNam.Location = new System.Drawing.Point(795, 233);
			this.txtNam.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
			this.txtNam.Minimum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
			this.txtNam.Name = "txtNam";
			this.txtNam.Size = new System.Drawing.Size(83, 29);
			this.txtNam.TabIndex = 10;
			this.txtNam.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
			this.txtNam.ValueChanged += new System.EventHandler(this.txtThangBD_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
			this.label3.Location = new System.Drawing.Point(460, 239);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 22);
			this.label3.TabIndex = 11;
			this.label3.Text = "Bắt dầu:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
			this.label4.Location = new System.Drawing.Point(597, 237);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(81, 22);
			this.label4.TabIndex = 12;
			this.label4.Text = "Kết thúc:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
			this.label5.Location = new System.Drawing.Point(737, 238);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 22);
			this.label5.TabIndex = 13;
			this.label5.Text = "Năm:";
			// 
			// FormThongKe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
			this.ClientSize = new System.Drawing.Size(1350, 765);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtNam);
			this.Controls.Add(this.txtThangKT);
			this.Controls.Add(this.txtThangBD);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.chartDoanhThu);
			this.Controls.Add(this.bangLuong);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.top10sp);
			this.Controls.Add(this.top10SanPhamBanChay);
			this.Name = "FormThongKe";
			this.Text = "FormThongKe";
			this.Load += new System.EventHandler(this.FormThongKe_Load);
			((System.ComponentModel.ISupportInitialize)(this.top10SanPhamBanChay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bangLuong)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtThangBD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtThangKT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart top10SanPhamBanChay;
        private System.Windows.Forms.Label top10sp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView bangLuong;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown txtThangBD;
		private System.Windows.Forms.NumericUpDown txtThangKT;
		private System.Windows.Forms.NumericUpDown txtNam;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}