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
	public partial class txtSanPhamHienTai : Form {

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
		List<Object> size;
		List<Object> mau;

		private bool isThem;

		public txtSanPhamHienTai(ReflectionDAO dao, ReflectionDAO ChatLieuDAO, 
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
			ControlExtension.Draggable(formInputCTSP, true);

			// load list
			chatLieu = ChatLieuDAO.getListAll();
			theLoai  = TheLoaiDAO.getListAll();
			quocGia  = QuocGiaDAO.getListAll();
			size = SizeDAO.getListAll();
			mau = MauSacDAO.getListAll();

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
			foreach (Model.Size model in size) {
				cbbSize.Items.Add(model.MaS + " - " + model.TenS);
			}
			foreach (MauSac model in mau) {
				cbbMauSac.Items.Add(model.MaMS + " - " + model.TenMS);
			}

			tableSize.DataSource = SizeDAO.getAll();
			tableMauSac.DataSource = MauSacDAO.getAll();
		}

		////////
		/// SAN PHAM
		/////// 

		#region main-form
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
				// luu lai san pham hien tai
				MaSanPhamHienTai = Convert.ToInt32(table.CurrentRow.Cells[3].Value);
				tenSanPhamHienTai = table.CurrentRow.Cells[4].Value.ToString();
				tableDSCTSP.DataSource = ChiTietSPDAO.GetDataTableByField("MaSP", table.CurrentRow.Cells[3].Value.ToString());
				formDanhSachCTSP.Visible = true;

				// set gia tri hien thi
				labelTenSanPhamHienTai.Text = tenSanPhamHienTai;
				txtTenSanPhamHienTai.Text = tenSanPhamHienTai;
				txtSanPhamHienTaiID.Text = MaSanPhamHienTai.ToString();
			}
		}

		private void btnThemSanPham_Click(object sender, EventArgs e) {
			formInputSanPham.Visible = true;
			btnThemSubmit.Text = " thêm";
			isThem = true;
		}

		private void txtTim_TextChanged(object sender, EventArgs e) {
			table.DataSource = dao.search("TenSP", txtTim.Text);
		}
		#endregion
		
		#region form-input-SanPham

		private void btnDongFrom_Click(object sender, EventArgs e) {
			formInputSanPham.Visible = false;
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

			txtSanPhamID.Text = table.CurrentRow.Cells[3].Value.ToString();
			txtTen.Text = table.CurrentRow.Cells[4].Value.ToString();
			txtDonGiaBan.Text = table.CurrentRow.Cells[5].Value.ToString();
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
		#endregion


		////////
		///  CHI TIET SAN PHAM <summary>
		///////

		private bool isThemCTSP;
		private int MaSanPhamHienTai = -1; // update gia tri khi click vao DsChiTietSP o table-main-form
		private String tenSanPhamHienTai = null;
		#region danh-sach-chi-tiet-san-pham
		private void BtnDongDSCTSP_Click(object sender, EventArgs e) {
			formDanhSachCTSP.Visible = false;
			MaSanPhamHienTai = -1;
		}

		private void btnThemMoiCTSP_Click(object sender, EventArgs e) {
			formInputCTSP.Visible = true;
			btnThemCTSP.Text = " thêm";
			isThemCTSP = true;
		}

		private void tableDSCTSP_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) { //delete
				isThem = true;
				ChiTietSPDAO.delelte(Convert.ToInt32(tableDSCTSP.CurrentRow.Cells[2].Value));
				ReLoadCHTSP();
				return;
			}

			if (e.ColumnIndex == 1) {
				isThem = false;
				btnThemCTSP.Text = " sửa";
				setFormCTSP();
				formInputCTSP.Visible = true;
			}
		}
		#endregion


		#region form-chi-tiet-san-pham
		private void ReLoadCHTSP() {
			MessageBox.Show(MaSanPhamHienTai.ToString());
			tableDSCTSP.DataSource = ChiTietSPDAO.GetDataTableByField("MaSP", MaSanPhamHienTai.ToString());
		}

		private void btnDongFormCTSP_Click(object sender, EventArgs e) {
			formInputCTSP.Visible = false;
		}

		private void cbbSize_SelectedIndexChanged(object sender, EventArgs e) {
			txtMaS.Text = cbbSize.Text.Trim().Split('-')[0];
		}

		private void cbbMau_SelectedIndexChanged(object sender, EventArgs e) {
			txtMaMS.Text = cbbMauSac.Text.Trim().Split('-')[0];
		}

		private void btnThemCTSP_Click(object sender, EventArgs e) {
			ChiTietSP model = getFormCTSP();
			if (model == null) {
				return;
			}
			if (isThemCTSP) {
				ChiTietSPDAO.create(model);
			} else {
				ChiTietSPDAO.update(model);
			}
			ReLoadCHTSP();
		}

		private ChiTietSP getFormCTSP() {
			ChiTietSP model = new ChiTietSP();
			if (txtSoLuong.Value == 0) {
				MessageBox.Show("Yeu cau nhap so luong");
				return null;
			}
			
			
			if (!isThemCTSP) {
				model.MaCTSP = Convert.ToInt32(txtCTSPID.Text);
			}
		

			model.MaSP = MaSanPhamHienTai;
			model.MaS = Convert.ToInt32(txtMaS.Text);
			model.MaMS = Convert.ToInt32(txtMaMS.Text);
			model.SoLuong = Convert.ToInt32(txtSoLuong.Value);
			return model;
		}

		private void setFormCTSP() {
			txtCTSPID.Text = tableDSCTSP.CurrentRow.Cells[2].Value.ToString();
			txtSoLuong.Value = Convert.ToInt32(tableDSCTSP.CurrentRow.Cells[6].Value);

			// cbb
			int MaS = Convert.ToInt32(tableDSCTSP.CurrentRow.Cells[3].Value);
			int MaMS = Convert.ToInt32(tableDSCTSP.CurrentRow.Cells[4].Value);

			for (int i = 0; i < cbbSize.Items.Count; i++) {
				int value = Convert.ToInt32(cbbSize.GetItemText(cbbSize.Items[i]).Trim().Split('-')[0]);
				if (value == MaS) {
					cbbSize.SelectedIndex = i;
				}
			}

			for (int i = 0; i < cbbMauSac.Items.Count; i++) {
				int value = Convert.ToInt32(cbbMauSac.GetItemText(cbbMauSac.Items[i]).Trim().Split('-')[0]);
				if (value == MaMS) {
					cbbMauSac.SelectedIndex = i;
				}
			}

			//hidden
			txtMaS.Text = MaS.ToString();
			txtMaMS.Text = MaMS.ToString();
		}
		#endregion


	}
}
