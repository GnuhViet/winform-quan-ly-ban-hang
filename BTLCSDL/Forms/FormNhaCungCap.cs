using BTLCSDL.DAO;
using BTLCSDL.DAO.impl;
using BTLCSDL.Model;
using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLCSDL.Forms {
	public partial class FormNhaCungCap : Form {
		ReflectionDAO dao;
		ReflectionDAO chucVuDAO;
		private List<Object> listChucVu;
		Hashtable HTChucVu;
		private bool isThem;

		public FormNhaCungCap(ReflectionDAO dao, ReflectionDAO chucVuDAO) {
			InitializeComponent();
			this.dao = dao;
			this.chucVuDAO = chucVuDAO;

			txtNgaySinh.CustomFormat = "yyyy-MM-dd";
			listChucVu = this.chucVuDAO.getListAll();
			HTChucVu = this.chucVuDAO.getHashtableAll();
			foreach (ChucVu cv in listChucVu) {
				cbbChucVu.Items.Add(cv.MaCV + " - " + cv.TenCV);
				cbbLocChucVu.Items.Add(cv.MaCV + " - " + cv.TenCV);
			}
			ControlExtension.Draggable(formInput, true);
		}

		private void FormNhanVien_Load(object sender, EventArgs e) {
			String ChucVuLoc = "";
			if (cbbLocChucVu.Text != null && !cbbLocChucVu.Text.Equals("")) {
				ChucVuLoc = cbbLocChucVu.Text.Trim().Split('-')[0];
			}

			String GioiTinhLoc = "";
			var gioiTinh = panelLocGioiTinh.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			if (gioiTinh != null) {
				GioiTinhLoc = gioiTinh.Text;
			}

			String filedValue = txtTim.Text;			
			String fieldName = cbbLoaiTimKiem.Text;

			if (fieldName.Equals("Tên")) {
				fieldName = "HoTenNV";
			} else if(fieldName.Equals("Mã")) {
				fieldName = "MaNV";
			} else if (fieldName.Equals("Địa Chỉ")) {
				fieldName = "DiaChi";
			} else if (fieldName.Equals("Số Điện Thoại")) {
				fieldName = "SoDT";
			}

			DataTable dt = ((NhanVienDAO)dao).getWithFillter(ChucVuLoc, GioiTinhLoc, fieldName, filedValue);

			dt.Columns.Add("Chức Vụ", typeof(String));
			foreach (DataRow row in dt.Rows) {
				row["Chức Vụ"] = ((ChucVu)HTChucVu[Convert.ToInt32(row["MaCV"])]).TenCV;
			}

			table.DataSource = dt;
			table.Columns["MaNV"].HeaderText = "Mã";
			table.Columns["HoTenNV"].HeaderText = "Họ Tên";
			table.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
			table.Columns["SoDT"].HeaderText = "Số Điện Thoại";
			table.Columns["DiaChi"].HeaderText = "Địa Chỉ";
			table.Columns["MaCV"].Visible = false;
			table.Columns["GioiTinh"].HeaderText = "Giới Tính";
			table.Columns["TinhTrang"].HeaderText = "Tình Trạng";		
		}
		//

		private void table_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				isThem = true;
				NhanVien model = new NhanVien();
				model.MaNV = Convert.ToInt32(table.CurrentRow.Cells[2].Value);
				dao.delelte(model);
				FormNhanVien_Load(sender, e);
				MessageBox.Show("Đã Sửa Thành Thôi Việc");
				return;
			}

			if (e.ColumnIndex == 1) {
				isThem = false;
				btnThemSubmit.Text = " sửa";
				setForm();
				formInput.Visible = true;
			}
		}

		private void btnThemSanPham_Click(object sender, EventArgs e) {
			formInput.Visible = true;
			isThem = true;
		}

		private void btnDongFrom_Click(object sender, EventArgs e) {
			formInput.Visible = false;
		}

		private void btnThemSubmit_Click(object sender, EventArgs e) {
			NhanVien model = getForm();
			if (model == null) {
				return;
			}
			if (isThem) {
				dao.create(model);
			} else {
				dao.update(model);
			}
			FormNhanVien_Load(sender, e);
		}

		private NhanVien getForm() {
			NhanVien model = new NhanVien();
			if ("".Equals(txtHoTenNV.Text)) {
				MessageBox.Show("Yeu cau nhap du ten");
				return null;
			}
			if (!isThem) {
				model.MaNV = Convert.ToInt32(txtMaNV.Text);
			}
			model.HoTenNV  = txtHoTenNV.Text;
			model.NgaySinh = txtNgaySinh.Value;
			model.SoDT     = txtSDT.Text;
			model.DiaChi   = txtDiaChi.Text;
			model.MaCV     = Convert.ToInt32(txtMaCV.Text);
			var gioiTinh  = panelGioiTinh.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			var tinhTrang = panelTinhTrang.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			model.GioiTinh  = gioiTinh.Text;
			model.TinhTrang = tinhTrang.Text;
			return model;
		}

		private void setForm() {
			txtMaNV.Text = table.CurrentRow.Cells[2].Value.ToString();
			txtHoTenNV.Text    = table.CurrentRow.Cells[3].Value.ToString();
			txtNgaySinh.Value  = Convert.ToDateTime(table.CurrentRow.Cells[4].Value);
			txtSDT.Text		   = table.CurrentRow.Cells[5].Value.ToString();
			txtDiaChi.Text	   = table.CurrentRow.Cells[6].Value.ToString();
			int maCV           = Convert.ToInt32(table.CurrentRow.Cells[7].Value);
			
			for (int i = 0; i < cbbChucVu.Items.Count; i++) {
				int value = Convert.ToInt32(cbbChucVu.GetItemText(cbbChucVu.Items[i]).Trim().Split('-')[0]);
				if(value == maCV) {
					cbbChucVu.SelectedIndex = i;
				}
			}

			cbbChucVu.Text	   = table.CurrentRow.Cells[7].Value.ToString(); //FIXME
			if ("Nam".Equals(table.CurrentRow.Cells[8].Value.ToString())) {
				radioNam.Checked = true;
			} else {
				radioNu.Checked = true;
			}
			if ("Đang Làm".Equals(table.CurrentRow.Cells[9].Value.ToString())) {
				radioDangLam.Checked = true;
			} else {
				radioNghi.Checked = true;
			}
		}

		private void txtTim_TextChanged(object sender, EventArgs e) {
			FormNhanVien_Load(sender, e);		
		}

		private void btnReset_Click(object sender, EventArgs e) {
			txtTim.Text = "";
			FormNhanVien_Load(sender, e);
		}

		private void btnThemNhanVien_Click(object sender, EventArgs e) {
			formInput.Visible = true;
			btnThemSubmit.Text = " thêm";
			isThem = true;
		}

		private void cbbChucVu_SelectedIndexChanged(object sender, EventArgs e) {
			txtMaCV.Text = cbbChucVu.Text.Trim().Split('-')[0];
		}

        private void txtSDT_TextChanged(object sender, EventArgs e) {
			if (!Regex.IsMatch(txtSDT.Text.Trim(), @"^\d+$")) {
				txtSDT.Text = "";
				return;
			}
		}

		private void txtSDT_KeyPress(object sender, KeyPressEventArgs e) {
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
				e.Handled = true;
			}
		}
		

		// radio loc

		bool isLocNam = false; 
		private void radioLocNam_CheckedChanged(object sender, EventArgs e) {
			isLocNam = radioLocNam.Checked;
		}

		private void radioLocNam_Click(object sender, EventArgs e) {
			if (radioLocNam.Checked && !isLocNam)
				radioLocNam.Checked = false;
			else {
				radioLocNam.Checked = true;
				isLocNam = false;
			}
			FormNhanVien_Load(sender, e);
		}

		bool isLocNu = false;
		private void radioLocNu_CheckedChanged(object sender, EventArgs e) {
			isLocNu = radioLocNu.Checked;
		}

		private void radioLocNu_Click(object sender, EventArgs e) {
			if (radioLocNu.Checked && !isLocNu)
				radioLocNu.Checked = false;
			else {
				radioLocNu.Checked = true;
				isLocNu = false;
			}
			FormNhanVien_Load(sender, e);
		}

		private void cbbLocChucVu_SelectedIndexChanged(object sender, EventArgs e) {
			FormNhanVien_Load(sender, e);
		}
	}
}
