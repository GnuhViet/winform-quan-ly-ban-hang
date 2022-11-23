using BTLCSDL.DAO;
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
		private DynamicDAO chatLieuDAO;

		private Type TheLoaiType;
		private DynamicDAO theLoaiDAO;

		private Type QuocGiaType;
		private DynamicDAO quocGiaDAO;

		private Type SizeType;
		private DynamicDAO sizeDAO;

		private Type MauSacType;
		private DynamicDAO mauSacDAO;

		private Type ChucVuType;
		private DynamicDAO chucVuDAO;

		private DynamicDAO sanPhamDAO;
		private DynamicDAO chiTietSPDAO;
		private DynamicDAO nhanVienDAO;
		private DynamicDAO hoaDonBanDAO;
		private DynamicDAO hoaDonNhapDAO;
		private DynamicDAO khachHangDAO;
		private DynamicDAO nhaCungCapDAO;
		private DynamicDAO chiTietHoaDonBanDAO;
		private DynamicDAO chiTietHoaDonNhapDAO;

		private BaoCaoDAO baoCaoDAO;
		#endregion

		public MainForm() {
			InitializeComponent();

			#region init DAO & TYPE
			ChatLieuType = typeof(ChatLieu);
			chatLieuDAO = new DynamicDAO(ChatLieuType);

			TheLoaiType = typeof(TheLoai);
			theLoaiDAO = new DynamicDAO(TheLoaiType);

			QuocGiaType = typeof(QuocGia);
			quocGiaDAO = new DynamicDAO(QuocGiaType);

			SizeType = typeof(Model.Size);
			sizeDAO = new DynamicDAO(SizeType);

			MauSacType = typeof(Model.MauSac);
			mauSacDAO = new DynamicDAO(MauSacType);

			ChucVuType = typeof(ChucVu);
			chucVuDAO = new DynamicDAO(ChucVuType);

			sanPhamDAO = new SanPhamDAO();
			chiTietSPDAO = new ChiTietSPDAO();
			nhanVienDAO = new NhanVienDAO();

			hoaDonBanDAO = new HoaDonBanDAO();
			khachHangDAO = new DynamicDAO(typeof(KhachHang));
			chiTietHoaDonBanDAO = new DynamicDAO(typeof(ChiTietHDB));
			nhaCungCapDAO = new DynamicDAO(typeof(NhaCungCap));
			hoaDonNhapDAO = new DynamicDAO(typeof(HoaDonNhap));
			chiTietHoaDonNhapDAO = new DynamicDAO(typeof(ChiTietHDN));

			baoCaoDAO = new BaoCaoDAO();
			#endregion

			SanPhamDropDownMenu.IsMainMenu = true;
			NhanVienDropDownMenu.IsMainMenu = true;
			HoaDonDropDownMenu.IsMainMenu = true;
			SanPhamDropDownMenu.PrimaryColor = Color.FromArgb(13, 72, 111);
			NhanVienDropDownMenu.PrimaryColor = Color.FromArgb(13, 72, 111);
			HoaDonDropDownMenu.PrimaryColor = Color.FromArgb(13, 72, 111);
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


		private void btnTrangChu_Click(object sender, EventArgs e) {
			formName.Text = "Trang Chủ";
			if (activeForm != null)
				activeForm.Close();
			setOffAll();
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
			OpenChildForm(new txtSanPhamHienTai(sanPhamDAO, chatLieuDAO, theLoaiDAO, quocGiaDAO, sizeDAO, mauSacDAO, chiTietSPDAO), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsChatLieu_Click(object sender, EventArgs e) {
			formName.Text = "Chất Liệu";
			OpenChildForm(new CommonForm(chatLieuDAO, ChatLieuType, formName.Text), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsTheLoai_Click(object sender, EventArgs e) {
			formName.Text = "Thể Loại";
			OpenChildForm(new CommonForm(theLoaiDAO, TheLoaiType, formName.Text), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsQuocGia_Click(object sender, EventArgs e) {
			formName.Text = "Quốc Gia";
			OpenChildForm(new CommonForm(quocGiaDAO, QuocGiaType, formName.Text), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsSize_Click(object sender, EventArgs e) {
			formName.Text = "Size";
			OpenChildForm(new CommonForm(sizeDAO, SizeType, formName.Text), sender);
			setOffAll();
			setOn(btnSanPham);
		}

		private void dsMauSac_Click(object sender, EventArgs e) {
			formName.Text = "Màu Sắc";
			OpenChildForm(new CommonForm(mauSacDAO, MauSacType, formName.Text), sender);
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
			OpenChildForm(new FormNhanVien(nhanVienDAO, chucVuDAO), sender);
			setOffAll();
			setOn(btnNhanVien);
		}

		private void dsChucVu_Click(object sender, EventArgs e) {
			formName.Text = "Chức Vụ";
			OpenChildForm(new CommonForm(chucVuDAO, ChucVuType, formName.Text), sender);
			setOffAll();
			setOn(btnNhanVien);
		}
		#endregion

		#region hoa don
		private void btnHoaDon_Click(object sender, EventArgs e) {
			formName.Text = "Hoá Đơn";
			HoaDonDropDownMenu.Show(btnHoaDon, btnHoaDon.Width, 0);
			setOffAll();
			setOn(btnHoaDon);
		}

		private void btnHoaDonBan_Click(object sender, EventArgs e) {
			OpenChildForm(new FormHoaDonBan(hoaDonBanDAO, khachHangDAO, nhanVienDAO,
											chiTietHoaDonBanDAO, chiTietSPDAO, sanPhamDAO,
											sizeDAO, mauSacDAO, theLoaiDAO, chatLieuDAO, quocGiaDAO), sender);
			formName.Text = "Hoá Đơn Bán";
			setOffAll();
			setOn(btnHoaDon);
		}

		private void btnHoaDonNhap_Click(object sender, EventArgs e) {
			OpenChildForm(new FormHoaDonNhap(hoaDonNhapDAO, chiTietHoaDonNhapDAO, nhaCungCapDAO, nhanVienDAO), sender);
			formName.Text = "Hoá Đơn Nhập";
			setOffAll();
			setOn(btnHoaDon);
		}
		#endregion

		private void btnKhachHang_Click(object sender, EventArgs e) {
			formName.Text = "Khách Hàng";
			OpenChildForm(new FormKhachHang(khachHangDAO), sender);
			setOffAll();
			setOn(btnKhachHang);
		}

        private void btnNhaCungCap_Click(object sender, EventArgs e) {
			formName.Text = "Nhà Cung Cấp";
			OpenChildForm(new FormNhaCungCap(nhaCungCapDAO), sender);
			setOffAll();
			setOn(btnNhaCungCap);
		}

		private void btnThongKe_Click(object sender, EventArgs e) {
			formName.Text = "Thống Kê";
			OpenChildForm(new FormThongKe(baoCaoDAO, nhanVienDAO), sender);
			setOffAll();
			setOn(btnThongKe);
		}
    }
}
