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
	public partial class FormKhachHang : Form {
		ReflectionDAO dao;

		private bool isThem;

		public FormKhachHang(ReflectionDAO dao) {
			InitializeComponent();
			this.dao = dao;

			ControlExtension.Draggable(formInput, true);
		}

		private void FormKhachHang_Load(object sender, EventArgs e) {
			String value = txtTim.Text;		

			DataTable dt = null;

			if (txtTim.Text != null && txtTim.Text.Trim() != "") {
				String fieldName = cbbLoaiTimKiem.Text;
				
				if (fieldName.Equals("Tên")) {
					fieldName = "HoTenKH";
				} else if (fieldName.Equals("Mã")) {
					fieldName = "MaKH";
				} else if (fieldName.Equals("Số Điện Thoại")) {
					fieldName = "SoDT";
				}

				if (fieldName == "MaKH") {
					dt = dao.getDataTableByField("MaKH", value);
				} else {
					dt = dao.search(fieldName, value);
				}
			} else {
				dt = dao.getAll();
			}			

			table.DataSource = dt;
			table.Columns["MaKH"].HeaderText = "Mã";
			table.Columns["HoTenKH"].HeaderText = "Họ Tên";
			table.Columns["SoDT"].HeaderText = "Số Điện Thoại";
		}
		//

		private void table_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				isThem = true;
				KhachHang model = new KhachHang();
				model.MaKH = Convert.ToInt32(table.CurrentRow.Cells[2].Value);
				dao.delelte(model);
				FormKhachHang_Load(sender, e);
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
			KhachHang model = getForm();
			if (model == null) {
				return;
			}
			if (isThem) {
				dao.create(model);
			} else {
				dao.update(model);
			}
			FormKhachHang_Load(sender, e);
		}

		private KhachHang getForm() {
			KhachHang model = new KhachHang();
			if ("".Equals(txtHoTenKH.Text)) {
				MessageBox.Show("Yeu cau nhap du ten");
				return null;
			}
			if (!isThem) {
				model.MaKH = Convert.ToInt32(txtMaKH.Text);
			}
			model.HoTenKH  = txtHoTenKH.Text;
			model.SoDT     = txtSDT.Text;
			return model;
		}

		private void setForm() {
			txtMaKH.Text = table.CurrentRow.Cells[2].Value.ToString();
			txtHoTenKH.Text    = table.CurrentRow.Cells[3].Value.ToString();
			txtSDT.Text		   = table.CurrentRow.Cells[4].Value.ToString();
		}

		private void txtTim_TextChanged(object sender, EventArgs e) {
			if (cbbLoaiTimKiem.Text == "Mã") {
				if (!Regex.IsMatch(txtTim.Text.Trim(), @"^\d+$")) {
					txtTim.Text = "";
				}
			}
			FormKhachHang_Load(sender, e);		
		}

		private void txtTim_KeyPress(object sender, KeyPressEventArgs e) {
			// neu la tim theo ma thi chi duoc nhap so
			if (cbbLoaiTimKiem.Text == "Mã") {
				if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
					e.Handled = true;
				}
			}
		}

		private void btnThemNhanVien_Click(object sender, EventArgs e) {
			formInput.Visible = true;
			btnThemSubmit.Text = " thêm";
			isThem = true;
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

        private void cbbLoaiTimKiem_SelectedIndexChanged(object sender, EventArgs e) {
			txtTim.PlaceholderText = "Nhập " + cbbLoaiTimKiem.Text;
			txtTim.Text = "";
        }

    }
}
