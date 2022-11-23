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
		DynamicDAO dao;

		private bool isThem;

		public FormNhaCungCap(DynamicDAO dao) {
			InitializeComponent();
			this.dao = dao;

			ControlExtension.Draggable(formInput, true);
		}

		private void FormNhaCungCap_Load(object sender, EventArgs e) {
			String value = txtTim.Text;		

			DataTable dt = null;

			if (txtTim.Text != null && txtTim.Text.Trim() != "") {
				String fieldName = cbbLoaiTimKiem.Text;
				
				if (fieldName.Equals("Tên")) {
					fieldName = "TenNCC";
				} else if (fieldName.Equals("Mã")) {
					fieldName = "MaNCC";
				} else if (fieldName.Equals("Số Điện Thoại")) {
					fieldName = "SoDT";
				} else if (fieldName.Equals("Địa Chỉ")) {
					fieldName = "DiaChi";
				} else if (fieldName.Equals("Email")) {
					fieldName = "Email";
				}

				if (fieldName == "MaNCC") {
					dt = dao.getDataTableByField("MaNCC", value);
				} else {
					dt = dao.search(fieldName, value);
				}
			} else {
				dt = dao.getAll();
			}			

			table.DataSource = dt;
			table.Columns["MaNCC"].HeaderText = "Mã";
			table.Columns["TenNCC"].HeaderText = "Tên";
			table.Columns["DiaChi"].HeaderText = "Địa Chỉ";
			table.Columns["SoDT"].HeaderText = "Số Điện Thoại";
		}
		//

		private void table_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				isThem = true;
				NhaCungCap model = new NhaCungCap();
				model.MaNCC = Convert.ToInt32(table.CurrentRow.Cells[2].Value);
				dao.delelte(model);
				FormNhaCungCap_Load(sender, e);
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
			txtTenNCC.Text = "";
			txtDiaChi.Text = "";
			txtSDT.Text = "";
			txtEmail.Text = "";
			txtMaNCC.Text = "";
		}

		private void btnThemSubmit_Click(object sender, EventArgs e) {
			NhaCungCap model = getForm();
			if (model == null) {
				return;
			}
			if (isThem) {
				dao.create(model);
			} else {
				dao.update(model);
			}
			FormNhaCungCap_Load(sender, e);
		}

		private NhaCungCap getForm() {
			if(txtTenNCC.Text == "") {
				MessageBox.Show("Yêu Cầu Nhập Tên");
				return null;
			}
			if (txtDiaChi.Text == "") {
				MessageBox.Show("Yêu Cầu Nhập Địa Chỉ");
				return null;
			}
			if (txtSDT.Text == "") {
				MessageBox.Show("Yêu Cầu Nhập Số Điện Thoại");
				return null;
			}
			if (txtEmail.Text == "") {
				MessageBox.Show("Yêu Cầu Nhập Email");
				return null;
			}
			
			NhaCungCap model = new NhaCungCap();
			if ("".Equals(txtTenNCC.Text)) {
				MessageBox.Show("Yeu cau nhap du ten");
				return null;
			}
			if (!isThem) {
				model.MaNCC = Convert.ToInt32(txtMaNCC.Text);
			}
			model.TenNCC = txtTenNCC.Text;
			model.SoDT   = txtSDT.Text;
			model.DiaChi = txtDiaChi.Text;
			model.Email = txtEmail.Text;
			return model;
		}

		private void setForm() {
			txtMaNCC.Text  = table.CurrentRow.Cells[2].Value.ToString();
			txtTenNCC.Text = table.CurrentRow.Cells[3].Value.ToString();
			txtDiaChi.Text = table.CurrentRow.Cells[4].Value.ToString();
			txtSDT.Text	   = table.CurrentRow.Cells[5].Value.ToString();
			txtEmail.Text  = table.CurrentRow.Cells[6].Value.ToString();
		}

		private void txtTim_TextChanged(object sender, EventArgs e) {
			if (cbbLoaiTimKiem.Text == "Mã") {
				if (!Regex.IsMatch(txtTim.Text.Trim(), @"^\d+$")) {
					txtTim.Text = "";
				}
			}
			FormNhaCungCap_Load(sender, e);		
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
			txtTenNCC.Text = "";
			txtDiaChi.Text = "";
			txtSDT.Text = "";
			txtEmail.Text = "";
			txtMaNCC.Text = "";
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
