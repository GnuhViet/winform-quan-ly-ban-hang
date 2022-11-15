using BTLCSDL.DAO.impl;
using BTLCSDL.Forms;
using BTLCSDL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLCSDL {
	public partial class MainForm : Form {
		#region define DAO & type
		private Type ChatLieuType;
		private ReflectionDAO ChatLieuDAO;

		private Type TheLoaiType;
		private ReflectionDAO TheLoaiDAO;

		private Type QuocGiaType;
		private ReflectionDAO QuocGiaDAO;

		private Type SizeType;
		private ReflectionDAO SizeDAO;

		private Type MauSacType;
		private ReflectionDAO MauSacDAO;

		private Type ChucVuType;
		private ReflectionDAO ChucVuDAO;

		private ReflectionDAO SanPhamDAO;
		private ReflectionDAO ChiTietSPDAO;
		#endregion

		public MainForm() {
			InitializeComponent();

			#region init DAO & TYPE
			ChatLieuType = typeof(ChatLieu);
			ChatLieuDAO = new ReflectionDAO(ChatLieuType);

			TheLoaiType = typeof(TheLoai);
			TheLoaiDAO = new ReflectionDAO(TheLoaiType);

			QuocGiaType = typeof(QuocGia);
			QuocGiaDAO = new ReflectionDAO(QuocGiaType);

			SizeType = typeof(Model.Size);
			SizeDAO = new ReflectionDAO(SizeType);

			MauSacType = typeof(Model.MauSac);
			MauSacDAO = new ReflectionDAO(MauSacType);

			ChucVuType = typeof(ChucVu);
			ChucVuDAO = new ReflectionDAO(ChucVuType);

			SanPhamDAO = new ReflectionDAO(typeof(SanPham));
			ChiTietSPDAO = new ReflectionDAO(typeof(ChiTietSP));
			#endregion

			SanPhamDropDownMenu.IsMainMenu = true;
			NhanVienDropDownMenu.IsMainMenu = true;
		}


		private Form activeForm;

		public void setOn(Button btn) {
			btn.BackColor = System.Drawing.Color.FromArgb(13, 72, 111);
		}

		public void setOffAll() {
			foreach (var button in panel1.Controls.OfType<Button>()) {
				if (button.Text.Equals(" Trang Chủ")) {
					continue;
				}
				button.BackColor = System.Drawing.Color.FromArgb(0, 54, 92);
			}
		}

		private void OpenChildForm(Form childForm, object btnSender) {
			if (activeForm != null)
				activeForm.Close();
			activeForm = childForm;
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			this.panelDesktopPane.Controls.Add(childForm);
			this.panelDesktopPane.Tag = childForm;
			childForm.BringToFront();
			childForm.Show();
			//lblTitle.Text = childForm.Text;
		}

		#region san pham
		private void btnSanPham_Click(object sender, EventArgs e) {
			//OpenChildForm(new FormSanPham(), sender);
			SanPhamDropDownMenu.Show(btnSanPham, btnSanPham.Width, 0);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsSanPham_Click(object sender, EventArgs e) {
			formName.Text = "Sản Phẩm";
			OpenChildForm(new FormSanPham(SanPhamDAO, ChatLieuDAO, TheLoaiDAO, QuocGiaDAO, SizeDAO, MauSacDAO, ChiTietSPDAO), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsChatLieu_Click(object sender, EventArgs e) {
			formName.Text = "Chất Liệu";
			OpenChildForm(new CommonForm(ChatLieuDAO, ChatLieuType, formName.Text), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsTheLoai_Click(object sender, EventArgs e) {
			formName.Text = "Thể Loại";
			OpenChildForm(new CommonForm(TheLoaiDAO, TheLoaiType, formName.Text), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsQuocGia_Click(object sender, EventArgs e) {
			formName.Text = "Quốc Gia";
			OpenChildForm(new CommonForm(QuocGiaDAO, QuocGiaType, formName.Text), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsSize_Click(object sender, EventArgs e) {
			formName.Text = "Size";
			OpenChildForm(new CommonForm(SizeDAO, SizeType, formName.Text), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsMauSac_Click(object sender, EventArgs e) {
			formName.Text = "Màu Sắc";
			OpenChildForm(new CommonForm(MauSacDAO, MauSacType, formName.Text), sender);
			setOffAll();
			setOn(btnSanPham);
		}
		#endregion


		#region nhan vien 
		private void btnNhanVien_Click(object sender, EventArgs e) {
			//OpenChildForm(new FormNhanVien(), sender);
			NhanVienDropDownMenu.Show(btnNhanVien, btnNhanVien.Width, 0);
			setOffAll();
			setOn(btnNhanVien);
		}

		private void dsNhanVien_Click(object sender, EventArgs e) {
			formName.Text = "Nhân Viên";
			OpenChildForm(new FormNhanVien(), sender);
			setOffAll();
			setOn(btnNhanVien);
		}

		private void dsChucVu_Click(object sender, EventArgs e) {
			formName.Text = "Chức Vụ";
			OpenChildForm(new CommonForm(ChucVuDAO, ChucVuType, formName.Text), sender);
			setOffAll();
			setOn(btnNhanVien);
		}

		#endregion

		private void btnTrangChu_Click(object sender, EventArgs e) {
			formName.Text = "Trang Chủ";
			if (activeForm != null)
				activeForm.Close();
			setOffAll();
		}

        private void btnHoaDon_Click(object sender, EventArgs e) {
			formName.Text = "Hoá Đơn";
			//OpenChildForm(new FormHoaDon(), sender);
			setOffAll();
			setOn(btnHoaDon);
		}

		private void btnThongKe_Click(object sender, EventArgs e) {
			formName.Text = "Thống Kê";
			//OpenChildForm(new FormThongKe(), sender);
			setOffAll();
			setOn(btnThongKe);
		}

		private void btnChucVu_Click(object sender, EventArgs e) {
			formName.Text = "Chức Vụ";
			OpenChildForm(new CommonForm(ChucVuDAO, ChucVuType, formName.Text), sender);
			setOffAll();
			//setOn(btnChucVu);
		}

		private void btnChatLieu_Click(object sender, EventArgs e) {

		}


	}
}
