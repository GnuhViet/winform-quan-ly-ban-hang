using BTLCSDL.DAO;
using BTLCSDL.DAO.impl;
using BTLCSDL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLCSDL.Forms {
	public partial class FormSanPham : Form {

		ReflectionDAO dao;
		ReflectionDAO ChatLieuDAO;
		ReflectionDAO TheLoaiDAO;
		ReflectionDAO QuocGiaDAO;
		ReflectionDAO SizeDAO;
		ReflectionDAO MauSacDAO;
		ReflectionDAO ChiTietSPDAO;

		List<Object> chatLieu;
		List<Object> theLoai;
		List<Object> quocGia;

		private bool isThem;

		public FormSanPham(ReflectionDAO dao, ReflectionDAO ChatLieuDAO, 
			ReflectionDAO TheLoaiDAO, ReflectionDAO QuocGiaDAO, 
			ReflectionDAO SizeDAO, ReflectionDAO MauSacDAO,
			ReflectionDAO ChiTietSPDAO) {
			this.dao = dao;
			this.ChatLieuDAO = ChatLieuDAO;
			this.TheLoaiDAO = TheLoaiDAO;
			this.QuocGiaDAO = QuocGiaDAO;
			this.SizeDAO = SizeDAO;
			this.MauSacDAO = MauSacDAO;
			this.ChiTietSPDAO = ChiTietSPDAO;
			InitializeComponent();
			txtDonGiaBan.Controls.RemoveAt(0);
			txtDonGiaNhap.Controls.RemoveAt(0);
			ControlExtension.Draggable(formInputSanPham, true);
			ControlExtension.Draggable(formDanhSachCTSP, true);

			// load list
			chatLieu = ChatLieuDAO.getListAll();
			theLoai  = TheLoaiDAO.getListAll();
			quocGia  = QuocGiaDAO.getListAll();

			// add vao cbb
			foreach(ChatLieu model in chatLieu) {
				cbbLocChatLieu.Items.Add(model.MaCL + " - " + model.TenCL);
				cbbChatLieu.Items.Add(model.MaCL + " - " + model.TenCL);
			}
			foreach (TheLoai model in theLoai) {
				cbbLocTheLoai.Items.Add(model.MaTL + " - " + model.TenTL);
				cbbTheLoai.Items.Add(model.MaTL + " - " + model.TenTL);
			}
			foreach (QuocGia model in quocGia) {
				cbbLocQuocGia.Items.Add(model.MaQG + " - " + model.TenQG);
				cbbQuocGia.Items.Add(model.MaQG + " - " + model.TenQG);
			}

			tableSize.DataSource = SizeDAO.getAll();
			tableMauSac.DataSource = MauSacDAO.getAll();
		}

		private void FormSanPham_Load(object sender, EventArgs e) {
			table.DataSource = dao.getAll();
		}

		private void table_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) { //delete
				isThem = true;
				dao.delelte(Convert.ToInt32(table.CurrentRow.Cells[3].Value));
				FormSanPham_Load(sender, e);
				return;
			}

			if (e.ColumnIndex == 1) {
				isThem = false;
				btnThemSubmit.Text = " sửa";
				setForm();
				formInputSanPham.Visible = true;
			}

			if (e.ColumnIndex == 2) {
				tableDSCTSP.DataSource = ChiTietSPDAO.GetDataTableByField("MaSP", table.CurrentRow.Cells[3].Value.ToString());
				formDanhSachCTSP.Visible = true;
			}
		}

		private void btnThemSanPham_Click(object sender, EventArgs e) {
			formInputSanPham.Visible = true;
			btnThemSubmit.Text = " thêm";
			isThem = true;
		}

		private void btnDongFrom_Click(object sender, EventArgs e) {
			formInputSanPham.Visible = false;
		}

		private void BtnDongDSCTSP_Click(object sender, EventArgs e) {
			formDanhSachCTSP.Visible = false;
		}

		private void btnThemSubmit_Click(object sender, EventArgs e) {
			SanPham model = getForm();
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

		private SanPham getForm() {
			SanPham model = new SanPham();
			if ("".Equals(txtTen.Text) || txtDonGiaBan.Value == 0) {
				MessageBox.Show("Yeu cau nhap du ten va gia!");
				return null;
			}

			if (!isThem) {
				model.MaSP = Convert.ToInt32(txtSanPhamID.Text);
			}
			model.TenSP = txtTen.Text;
			model.DonGiaBan = Convert.ToInt32(txtDonGiaBan.Value);
			model.DonGiaNhap = Convert.ToInt32(txtDonGiaNhap.Value);
			var gioiTinh = panelGioiTinh.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			model.GioiTinh = gioiTinh.Text;
			// anh
			model.Anh = pictureAnh.ImageLocation;
			// ma khac
			model.MaTL = Convert.ToInt32(txtTheLoaiID.Text);
			model.MaCL = Convert.ToInt32(txtChatLieuID.Text);
			model.MaQG = Convert.ToInt32(txtQuocGiaID.Text);
			return model;
		}

		private void setForm() {

			txtSanPhamID.Text  = table.CurrentRow.Cells[3].Value.ToString();
			txtTen.Text        = table.CurrentRow.Cells[4].Value.ToString();
			txtDonGiaBan.Text  = table.CurrentRow.Cells[5].Value.ToString();
			txtDonGiaNhap.Text = table.CurrentRow.Cells[6].Value.ToString();
			if ("Nam".Equals(table.CurrentRow.Cells[7].Value.ToString())) {
				radioNam.Checked = true;
			} else {
				radioNu.Checked = true;
			}

			// anh
			String path = table.CurrentRow.Cells[8].Value.ToString();
			if (!"".Equals(path)) {
				pictureAnh.Image = Image.FromFile(path);
			}

			// cbb
			int MaTL = Convert.ToInt32(table.CurrentRow.Cells[9].Value);
			int MaCL = Convert.ToInt32(table.CurrentRow.Cells[10].Value);
			int MaQG = Convert.ToInt32(table.CurrentRow.Cells[11].Value);

			for (int i = 0; i < cbbTheLoai.Items.Count; i++) {
				int value = Convert.ToInt32(cbbTheLoai.GetItemText(cbbTheLoai.Items[i]).Trim().Split('-')[0]);
				if (value == MaTL) {
					cbbTheLoai.SelectedIndex = i;
				}
			}

			for (int i = 0; i < cbbChatLieu.Items.Count; i++) {
				int value = Convert.ToInt32(cbbChatLieu.GetItemText(cbbChatLieu.Items[i]).Trim().Split('-')[0]);
				if (value == MaCL) {
					cbbChatLieu.SelectedIndex = i;
				}
			}

			for (int i = 0; i < cbbQuocGia.Items.Count; i++) {
				int value = Convert.ToInt32(cbbQuocGia.GetItemText(cbbQuocGia.Items[i]).Trim().Split('-')[0]);
				if (value == MaQG) {
					cbbQuocGia.SelectedIndex = i;
				}
			}

			//hidden
			txtTheLoaiID.Text = MaTL.ToString();
			txtChatLieuID.Text = MaCL.ToString();
			txtQuocGiaID.Text = MaQG.ToString();
		}

		private void btnTim_Click(object sender, EventArgs e) {
			table.DataSource = dao.search("TenSP", txtTim.Text);
		}

		private void btnReset_Click(object sender, EventArgs e) {
			txtTim.Text = "";
			FormSanPham_Load(sender, e);
		}

        private void txtTim_TextChanged(object sender, EventArgs e) {
			table.DataSource = dao.search("TenSP", txtTim.Text);
		}

		private void cbbTheLoai_SelectedIndexChanged(object sender, EventArgs e) {
			txtTheLoaiID.Text = cbbTheLoai.Text.Trim().Split('-')[0];
		}

		private void cbbChatLieu_SelectedIndexChanged(object sender, EventArgs e) {
			txtChatLieuID.Text = cbbChatLieu.Text.Trim().Split('-')[0];
		}

		private void cbbQuocGia_SelectedIndexChanged(object sender, EventArgs e) {
			txtQuocGiaID.Text = cbbQuocGia.Text.Trim().Split('-')[0];
		}

		private void ptbAnh_Click(object sender, EventArgs e) {
			OpenFileDialog save = new OpenFileDialog();
			save.ShowDialog();
			save.Filter = "Jpeg (*.jpg)|*jpg)";
			save.DefaultExt = "jpg";
			if (save.FileName == "") {
				return;
			}
			pictureAnh.ImageLocation = Path.GetFullPath(save.FileName);
			pictureAnh.SizeMode = PictureBoxSizeMode.StretchImage;
		}


	}
}
