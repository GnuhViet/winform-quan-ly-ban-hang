using BTLCSDL.DAO;
using BTLCSDL.DAO.impl;
using BTLCSDL.Model;
using Bunifu.UI.WinForms.BunifuButton;
using System;
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
	public partial class FormNhanVien : Form {
		ReflectionDAO dao;
		ReflectionDAO chucVuDao;
		private List<Object> listChucVu;
		private bool isThem;

		public FormNhanVien() {
			InitializeComponent();
			dao = new ReflectionDAO(typeof(NhanVien));
			chucVuDao = new ReflectionDAO(typeof(ChucVu));
			txtNgaySinh.CustomFormat = "yyyy-MM-dd";
			listChucVu = chucVuDao.getListAll();
			foreach (ChucVu cv in listChucVu) {
				cbbChucVu.Items.Add(cv.MaCV + " - " + cv.TenCV);
			}
			ControlExtension.Draggable(formInput, true);
		}

		private void FormSanPham_Load(object sender, EventArgs e) {
			table.DataSource = dao.getAll();
		}
		//

		private void table_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				isThem = true;
				NhanVien model = new NhanVien();
				model.MaNV = Convert.ToInt32(table.CurrentRow.Cells[2].Value);
				dao.delelte(model);
				FormSanPham_Load(sender, e);
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
			FormSanPham_Load(sender, e);
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

		private void btnTim_Click(object sender, EventArgs e) {
			table.DataSource = dao.search("HoTenNV", txtTim.Text);
		}

		private void txtTim_TextChanged(object sender, EventArgs e) {
			table.DataSource = dao.search("HoTenNV", txtTim.Text);
		}

		private void btnReset_Click(object sender, EventArgs e) {
			txtTim.Text = "";
			FormSanPham_Load(sender, e);
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
	}
}
