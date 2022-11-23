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

namespace BTLCSDL.Forms {
	public partial class CommonForm : Form {
		private DynamicDAO dao;
		private bool isThem;

		private Type type;
		private PropertyInfo[] properties;

		private PropertyInfo Ma;
		private PropertyInfo Ten;
		private String formName;

		public CommonForm(DynamicDAO dao ,Type type, String formName) {
			String classShortName = string.Concat(Regex.Matches(type.Name, "[A-Z]").OfType<Match>().Select(match => match.Value));
			
			this.type = type;
			this.properties = type.GetProperties();
			this.Ma  = type.GetProperty("Ma" + classShortName);
			this.Ten = type.GetProperty("Ten" + classShortName);
			this.dao = dao;
			this.formName = formName;

			InitializeComponent();
			// keo tha panel
			ControlExtension.Draggable(formInput, true);
			txtTim.PlaceholderText += formName;
		}

		private void Form_Load(object sender, EventArgs e) {
			table.DataSource = dao.getAll();
			table.Columns[Ma.Name].HeaderText = "Mã";
			table.Columns[Ten.Name].HeaderText = formName;	
		}
		//

		private void table_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				isThem = true;
				Object model = Activator.CreateInstance(type);
				Ma.SetValue(model, Convert.ToInt32(table.CurrentRow.Cells[2].Value));
				dao.delelte(model);
				Form_Load(sender, e);
				return;
			}

			if (e.ColumnIndex == 1) {
				isThem = false;
				btnThemSubmit.Text = " sửa";
				setForm();
				formInput.Visible = true;
			}
		}

		private void btnDongFrom_Click(object sender, EventArgs e) {
			formInput.Visible = false;
			txtTen.Text = "";
			txtMa.Text = "";
			clearFormContent();
		}

		private void btnThemSubmit_Click(object sender, EventArgs e) {
			Object model = getForm();
			if (model == null) {
				return;
			}
			if (isThem) {
				dao.create(model);
			} else {
				dao.update(model);
			}
			Form_Load(sender, e);
		}

		private Object getForm() {
			Object model = Activator.CreateInstance(type);
			if ("".Equals(txtTen.Text)) {
				MessageBox.Show("Tên Không Được Để Trống !!");
				return null;
			}
			if (!isThem) {
				Ma.SetValue(model, Convert.ToInt32(txtMa.Text));
			}
			Ten.SetValue(model, txtTen.Text);
			return model;
		}

		private void setForm() {
			txtMa.Text = table.CurrentRow.Cells[2].Value.ToString();
			txtTen.Text   = table.CurrentRow.Cells[3].Value.ToString();
		}
		
		private void clearFormContent() {
			txtMa.Text = "";
			txtTen.Text = "";
		}

		private void btnReset_Click(object sender, EventArgs e) {
			txtTim.Text = "";
			Form_Load(sender, e);
		}

        private void txtTim_TextChanged(object sender, EventArgs e) {
			if(cbbLoaiTimKiem.Text == "Tên") {
				table.DataSource = dao.search(Ten.Name, txtTim.Text);
			} else {
				if (cbbLoaiTimKiem.Text == "Mã") {
					if (!Regex.IsMatch(txtTim.Text.Trim(), @"^\d+$")) {
						txtTim.Text = "";
					}
				}
				table.DataSource = dao.search(Ma.Name, txtTim.Text);
			}
		}

		private void txtTim_KeyPress(object sender, KeyPressEventArgs e) {
			if (cbbLoaiTimKiem.Text == "Mã") {
				if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
					e.Handled = true;
				}
			}
		}

		private void btnThem_Click(object sender, EventArgs e) {
			formInput.Visible = true;
			btnThemSubmit.Text = " thêm";
			txtTen.Text = ""; txtMa.Text = "";
			isThem = true;
		}

        private void cbbLoaiTimKiem_SelectedIndexChanged(object sender, EventArgs e) {
			txtTim.PlaceholderText = "Nhập " + cbbLoaiTimKiem.Text + " " + formName;
        }
	}
}
