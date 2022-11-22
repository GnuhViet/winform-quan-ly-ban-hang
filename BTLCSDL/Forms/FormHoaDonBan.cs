using BTLCSDL.DAO;
using BTLCSDL.DAO.impl;
using BTLCSDL.Model;
using Bunifu.UI.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLCSDL.Forms {
	public partial class FormHoaDonBan : Form {
		ReflectionDAO dao;
		ReflectionDAO khDAO;
		ReflectionDAO nvDAO;
		ReflectionDAO cthdbDAO;
		ReflectionDAO ctspDAO;
		ReflectionDAO spDAO;
		ReflectionDAO sizeDAO;
		ReflectionDAO msDAO;
		ReflectionDAO theLoaiDAO;
		ReflectionDAO chatLieuDAO;
		ReflectionDAO quocGiaDAO;

		private bool isThem;
		List<Object> listNhanVien;
		List<Object> listKhachHang;

		Hashtable HTSize;
		Hashtable HTMauSac;
		Hashtable HTTheLoai;
		Hashtable HTChatLieu;
		Hashtable HTQuocGia;
		Hashtable HTKhachHang;
		Hashtable HTNhanVien;
		Dictionary<String, List<ChiTietSP>> MapChiTietSP;

		public FormHoaDonBan(ReflectionDAO dao,
				ReflectionDAO khDAO,
				ReflectionDAO nvDAO,
				ReflectionDAO cthdbDAO,
				ReflectionDAO ctspDAO,
				ReflectionDAO spDAO,
				ReflectionDAO sizeDAO,
				ReflectionDAO msDAO,
				ReflectionDAO theLoaiDAO,
				ReflectionDAO chatLieuDAO,
				ReflectionDAO quocGiaDAO) {

			InitializeComponent();
			this.dao = dao;
			this.khDAO = khDAO;
			this.nvDAO = nvDAO;
			this.cthdbDAO = cthdbDAO;
			this.ctspDAO = ctspDAO;
			this.spDAO = spDAO;
			this.sizeDAO = sizeDAO;
			this.msDAO = msDAO;

			ControlExtension.Draggable(formThemHoaDon, true);
			ControlExtension.Draggable(panelChonSanPham, true);

			// load du lieu
			listNhanVien = nvDAO.getListAll();
			listKhachHang = khDAO.getListAll();

			HTSize = sizeDAO.getHashtableAll();
			HTMauSac = msDAO.getHashtableAll();
			HTTheLoai = theLoaiDAO.getHashtableAll();
			HTChatLieu = chatLieuDAO.getHashtableAll();
			HTQuocGia = quocGiaDAO.getHashtableAll();
			HTKhachHang = khDAO.getHashtableAll();
			HTNhanVien = nvDAO.getHashtableAll();
			
			MapChiTietSP = ((ChiTietSPDAO)ctspDAO).getMapAllWithMaSPKey();

			// add du lieu vao cbb
			foreach (NhanVien nv in listNhanVien) {
				cbbListNhanVien.Items.Add(nv.HoTenNV + " - " + nv.MaNV);
			}
			foreach (KhachHang kh in listKhachHang) {
				cbbListKhachHang.Items.Add(kh.HoTenKH + " - " + kh.MaKH);
			}

			// add gia tri empty
			cbbLocChatLieu.Items.Add("");
			cbbLocTheLoai.Items.Add("");
			cbbLocQuocGia.Items.Add("");
			// add vao cbb
			foreach (int i in HTChatLieu.Keys) {
				ChatLieu model = (ChatLieu)HTChatLieu[i];
				cbbLocChatLieu.Items.Add(model.MaCL + " - " + model.TenCL);
			}
			foreach (int i in HTTheLoai.Keys) {
				TheLoai model = (TheLoai)HTTheLoai[i];
				cbbLocTheLoai.Items.Add(model.MaTL + " - " + model.TenTL);
			}
			foreach (int i in HTQuocGia.Keys) {
				QuocGia model = (QuocGia)HTQuocGia[i];
				cbbLocQuocGia.Items.Add(model.MaQG + " - " + model.TenQG);
			}
		}

		private void FormHoaDon_Load(object sender, EventArgs e) {
			String fieldValue = txtTimHoaDon.Text;
			String fieldName = cbbLoaiTimKiem.Text;

			DataTable dt = null;

			if (fieldName.Equals("Mặt Hàng")) {
				dt = ((HoaDonBanDAO)dao).searchByTenSP(txtTimHoaDon.Text);
			} else if (fieldName.Equals("Nhân Viên")) {
				dt = ((HoaDonBanDAO)dao).searchByTenNV(txtTimHoaDon.Text);
			} else if (fieldName.Equals("Khách Hàng")) {
				dt = ((HoaDonBanDAO)dao).searchByTenKH(txtTimHoaDon.Text);
			}
			
			// them cot ten khach, Nhan Vien
			dt.Columns.Add("Khách Hàng", typeof(String));
			foreach (DataRow row in dt.Rows) {
				try {
					Convert.ToInt32(row["MaKH"]);
					row["Khách Hàng"] = ((KhachHang)HTKhachHang[Convert.ToInt32(row["MaKH"])]).HoTenKH;
				} catch {
					row["Khách Hàng"] = "";
				}
			}
			dt.Columns.Add("Nhân Viên", typeof(String));
			foreach (DataRow row in dt.Rows) {
				row["Nhân Viên"] = ((NhanVien)HTNhanVien[Convert.ToInt32(row["MaNV"])]).HoTenNV;
			}

			// sua va an ma khach, ma nv
			table.DataSource = dt;
			table.Columns["MaHDB"].HeaderText = "Mã Hoá Đơn Bán";
			table.Columns["NgayBan"].HeaderText = "Ngày Bán";
			table.Columns["TongTien"].HeaderText = "Tổng Tiền";
			table.Columns["MaKH"].Visible = false;
			table.Columns["MaNV"].Visible = false;

			// cai nay o nut tat...
			txtTongTienThanhToan.Text = "0";
			txtTienKhachTra.Text = "0";
			txtTienTraLai.Text = "0";
		}

		#region form-ngoai-cung
		// tim kiem
		private void txtTim_TextChanged(object sender, EventArgs e) {
			// neu la tim theo ma thi chi duoc nhap so
			if (cbbLoaiTimKiem.Text == "Mã") {
				if (!Regex.IsMatch(txtTimHoaDon.Text.Trim(), @"^\d+$")) {
					txtTimHoaDon.Text = "";
				}
			}
			FormHoaDon_Load(sender, e);
		}

		private void txtTimHoaDon_KeyPress(object sender, KeyPressEventArgs e) {
			// neu la tim theo ma thi chi duoc nhap so
			if (cbbLoaiTimKiem.Text == "Mã") {
				if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
					e.Handled = true;
				}
			}
		}

		private void cbbLoaiTimKiem_SelectedIndexChanged(object sender, EventArgs e) {
			txtTimHoaDon.PlaceholderText = "Nhập " + cbbLoaiTimKiem.Text;
			txtTimHoaDon.Text = "";
		}
		
		// them - sua - xoa
		private void table_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				isThem = true;
				HoaDonBan hdb = new HoaDonBan();
				hdb.MaHDB = Convert.ToInt32(table.CurrentRow.Cells[2].Value);
				dao.delelte(hdb);
				FormHoaDon_Load(sender, e);
				return;
			}

			if (e.ColumnIndex == 1) {
				isThem = false;
				btnThemSubmit.Text = " sửa";
				String MaHDB = table.CurrentRow.Cells[2].Value.ToString();
				loadChiTietHoaDonBan(MaHDB);
				setForm(MaHDB);
				formThemHoaDon.Visible = true;
			}
		}
		
		private void btnThemHoaDon_Click(object sender, EventArgs e) {
			isThem = true;
			formThemHoaDon.Visible = true;
		}
		
		private void loadChiTietHoaDonBan(String MaHDB) {
			DataTable dt = ((ChiTietSPDAO)ctspDAO).getWithSizeMauSanPham(Convert.ToInt32(MaHDB));
			danhSachSanPhamCuaHoaDon.Rows.Add();
			foreach(DataRow r in dt.Rows) {
				DataGridViewRow row = (DataGridViewRow)danhSachSanPhamCuaHoaDon.Rows[0].Clone();
				for (int i = 1; i < row.Cells.Count; i++) {
					row.Cells[i].Value = r[i-1].ToString();
				}
				danhSachSanPhamCuaHoaDon.Rows.Add(row);
			}
			danhSachSanPhamCuaHoaDon.Rows.RemoveAt(Top);
		}
		#endregion

		#region form hoa don =========================================
		// set ma nhan vien khi chon nv
		private void listNhanVien_SelectedIndexChanged(object sender, EventArgs e) {
			txtNhanVienID.Text = cbbListNhanVien.Text.Trim().Split('-')[1];
		}
		// set ma khach khi chon khach
		private void cbbListKhachHang_SelectedIndexChanged(object sender, EventArgs e) {
			String nv = cbbListKhachHang.Text;
			if (nv == null || nv == "") {
				txtKhachHangID.Text = "0";
				return;
			}
			txtKhachHangID.Text = cbbListKhachHang.Text.Trim().Split('-')[1];
		}
		
		private void btnChinhSuaDSSP_Click(object sender, EventArgs e) {
			panelChonSanPham.Visible = true;
			copyData(danhSachSanPhamCuaHoaDon, dsSanPhamDaChon);
			loadDanhSachChiTietSanPham();
		}

		private void btnDongFromHoaDon_Click(object sender, EventArgs e) {
			formThemHoaDon.Visible = false;
			// dua cac so ve 0
			txtTongTienThanhToan.Text = "0";
			txtTienKhachTra.Text = "0";
			txtTienTraLai.Text = "0";
			// clear danh sach
			danhSachSanPhamCuaHoaDon.Rows.Clear();			

			FormHoaDon_Load(sender, e);
		}

		private void btnThemHoaDonSubmit_Click(object sender, EventArgs e) {
			// tinh tien khach can tra
			int TienKhachTra = Convert.ToInt32(txtTienKhachTra.Text);
			int TongTienCanTra = (Convert.ToInt32(txtTongTienThanhToan.Text));
			if (TienKhachTra < TongTienCanTra) {
				txtTienKhachTra.Text = "";
				MessageBox.Show("Tien khac tra khong duoc nho nhon so tien can tra");
				return;
			}
			txtTienTraLai.Text = Convert.ToString(TienKhachTra - TongTienCanTra);
			MessageBox.Show("tra lai khach: " + txtTienTraLai.Text + "k vnd");


			// kiem tra
			HoaDonBan hd = getForm();
			if (hd == null) {
				return;
			}
			if (isThem) {
				int createId = dao.createNoMessage(hd);
				
				if (createId == -1) {
					MessageBox.Show("khong them duoc vi da ton tai ");
					return;
				}

				List<ChiTietHDB> list = getListCTHD(createId);
				int status = 0;
				foreach(ChiTietHDB c in list) {
					status = cthdbDAO.createNoMessage(c);
				}
				
				if (status == -1) {
					MessageBox.Show("Tạo Hoá Đơn Thất Bại");
				} else {
					MessageBox.Show("Tạo Hoá Đơn Thành Công");
				}
			} else { // sua
				List<ChiTietHDB> oldList = cthdbDAO.getListByField("MaHDB",hd.MaHDB.ToString()).Select(s => (ChiTietHDB)s).ToList();
				List<ChiTietHDB> newList = getListCTHD(Convert.ToInt32(table.CurrentRow.Cells[2].Value));
				// update old u new
				// delete old - new
				// create new - old

				// old - new
				List<ChiTietHDB> delete = new List<ChiTietHDB>();
				bool notIn;
				foreach(ChiTietHDB o in oldList) {
					notIn = true;
					foreach (ChiTietHDB n in newList) {
						if (o.MaHDB == n.MaHDB && o.MaCTSP == n.MaCTSP) {
							notIn = false;
							break;
						}	
					}
					if (notIn) {
						delete.Add(o);
					}
				}
				foreach(ChiTietHDB o in delete) {
					cthdbDAO.delelte(o);
				}

				// new - o
				List<ChiTietHDB> create = new List<ChiTietHDB>();
				foreach (ChiTietHDB n in newList) {
					notIn = true;
					foreach (ChiTietHDB o in oldList) {
						if (n.MaHDB == o.MaHDB && n.MaCTSP == o.MaCTSP) {
							notIn = false;
							break;
						}
					}
					if (notIn) {
						create.Add(n);
					}
				}
				foreach (ChiTietHDB n in create) {
					cthdbDAO.createNoMessage(n);
				}

				// old u new
				bool isContain = false;
				foreach (ChiTietHDB n in newList) {
					isContain = false;
					foreach (ChiTietHDB o in oldList) {
						if (o.MaHDB == n.MaHDB && o.MaCTSP == n.MaCTSP) {
							n.MaCTHDB = o.MaCTHDB;
							isContain = true;
							break;
						}
					}
					if (isContain) {
						cthdbDAO.updateNoMessage(n);
					}
				}

				dao.update(hd);
				btnDongFrom.PerformClick();
			}

			// load lai so luong san pham
			MapChiTietSP = ((ChiTietSPDAO)ctspDAO).getMapAllWithMaSPKey();

			FormHoaDon_Load(sender, e);
		}

		private void setForm(String MaHDB) {
			HoaDonBan hdb = (HoaDonBan)dao.getListByField("MaHDB", MaHDB)[0];
			txtHoaDonID.Text = hdb.MaHDB.ToString();
			txtTongTienThanhToan.Text = hdb.TongTien.ToString();
			dtpNgayBan.Value = hdb.NgayBan;

			for (int i = 0; i < cbbListNhanVien.Items.Count; i++) {
				string value = cbbListNhanVien.GetItemText(cbbListNhanVien.Items[i]);
				if (value.Replace(" ", "").Split('-')[1] == hdb.MaNV.ToString()) {
					cbbListNhanVien.Text = value;
				}
			}

			if (hdb.MaKH == 0) {
				txtKhachHangID.Text = "0";
				return;
			}

			for (int i = 0; i < cbbListKhachHang.Items.Count; i++) {
				string value = cbbListKhachHang.GetItemText(cbbListKhachHang.Items[i]);
				if (value.Replace(" ", "").Split('-')[1] == hdb.MaKH.ToString()) {
					cbbListKhachHang.Text = value;
				}
			}
		}

		private HoaDonBan getForm() {
			HoaDonBan hd = new HoaDonBan();
			if (txtHoaDonID.Text != "") {
				hd.MaHDB = Convert.ToInt32(txtHoaDonID.Text);
			}
			
			hd.NgayBan = dtpNgayBan.Value;
			hd.TongTien = Convert.ToInt32(txtTongTienThanhToan.Text);
			if (txtKhachHangID.Text == "") {
				hd.MaKH = 0;
			} else {
				hd.MaKH = Convert.ToInt32(txtKhachHangID.Text);
			}
			hd.MaNV = Convert.ToInt32(txtNhanVienID.Text);
			return hd;
		}

		private List<ChiTietHDB> getListCTHD(int hdID) {
			List<ChiTietHDB> cthd = new List<ChiTietHDB>();
			foreach (DataGridViewRow r in danhSachSanPhamCuaHoaDon.Rows) {
				ChiTietHDB chiTietHoaDon = new ChiTietHDB();
				chiTietHoaDon.MaHDB = hdID;
				chiTietHoaDon.SoLuong = Convert.ToInt32(r.Cells[2].Value);
				chiTietHoaDon.ThanhTien = Convert.ToDouble(r.Cells[1].Value);
				chiTietHoaDon.DonGiaBan = chiTietHoaDon.ThanhTien / chiTietHoaDon.SoLuong;
				
				int MaSP = Convert.ToInt32(r.Cells[4].Value);
				int MaS = Convert.ToInt32(r.Cells[5].Value.ToString().Replace(" ", "").Split('-')[0]);
				int MaMS = Convert.ToInt32(r.Cells[6].Value.ToString().Replace(" ", "").Split('-')[0]);

				chiTietHoaDon.MaCTSP = ((ChiTietSPDAO)ctspDAO).getMaCTSP(MaSP, MaS, MaMS);
				cthd.Add(chiTietHoaDon);
			}
			return cthd;
		}
		
		// validate nhap so
		private void txtTienKhachTra_TextChanged(object sender, EventArgs e) {
			if (!Regex.IsMatch(txtTienKhachTra.Text.Trim(), @"^\d+$")) {
				txtTienKhachTra.Text = "0";
				return;
			}
			if ("".Equals(txtTienKhachTra.Text)) {
				txtTienKhachTra.Text = "0";
			}
		}

		private void txtTienKhachTra_KeyPress(object sender, KeyPressEventArgs e) {
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
				e.Handled = true;
			}
		}

		#endregion

		#region panel chon san pham ===================================
		private void loadDanhSachChiTietSanPham() {
			DataTable dt = null;

			// doc fillter
			bool needFillter = false;

			Dictionary<Type, List<String>> test = new Dictionary<Type, List<string>>();
			if (cbbLocTheLoai.Text != null && cbbLocTheLoai.Text != "") {
				test.Add(typeof(TheLoai),
					new List<String>() { cbbLocTheLoai.Text.Split('-')[0] });
				needFillter = true;
			}
			if (cbbLocChatLieu.Text != null && cbbLocChatLieu.Text != "") {
				test.Add(typeof(ChatLieu),
					new List<String>() { cbbLocChatLieu.Text.Split('-')[0] });
				needFillter = true;
			}
			if (cbbLocQuocGia.Text != null && cbbLocQuocGia.Text != "") {
				test.Add(typeof(QuocGia),
					new List<String>() { cbbLocQuocGia.Text.Split('-')[0] });
				needFillter = true;
			}

			String val = txtTimSanPham.Text;
			String searchField = "";
			if (val != null && val != "") {
				searchField = cbbLocTim.Text;
				if (searchField == "Tên") {
					searchField = "TenSP";
				} else if (searchField == "Mã") {
					searchField = "MaSP";
				} else if (searchField == "Giá Bán") {
					searchField = "DonGiaBan";
				}
				needFillter = true;
			}
			// load san pham
			if (needFillter) {
				dt = ((SanPhamDAO)spDAO).getWithMaAndSearchWithField(test, searchField, val);
			} else {
				dt = spDAO.getAll();
			}

			dt.Columns.Add("Thể Loại", typeof(String));
			dt.Columns.Add("Chất Liệu", typeof(String));
			dt.Columns.Add("Quốc Gia", typeof(String));

			foreach (DataRow row in dt.Rows) {
				row["Thể Loại"] = ((TheLoai)HTTheLoai[Convert.ToInt32(row["MaTL"])]).TenTL;
				row["Chất Liệu"] = ((ChatLieu)HTChatLieu[Convert.ToInt32(row["MaCL"])]).TenCL;
				row["Quốc Gia"] = ((QuocGia)HTQuocGia[Convert.ToInt32(row["MaQG"])]).TenQG;
			}

			danhSachSanPham.DataSource = dt;

			foreach (DataGridViewRow row in danhSachSanPham.Rows) {
				String MaSP = row.Cells["MaSP"].Value.ToString();
				List<ChiTietSP> listByMaSP = (List<ChiTietSP>)MapChiTietSP[MaSP];
				HashSet<int> listMaS = new HashSet<int>();
				HashSet<int> listMaMS = new HashSet<int>();
				foreach (ChiTietSP item in listByMaSP) {
					listMaS.Add(item.MaS);
					listMaMS.Add(item.MaMS);
				}
				DataGridViewComboBoxCell cbbSize = (DataGridViewComboBoxCell)row.Cells[2];
				DataGridViewComboBoxCell cbbMauSac = (DataGridViewComboBoxCell)row.Cells[3];
				foreach (int MaS in listMaS) {
					cbbSize.Items.Add(MaS + " - " + ((Model.Size)HTSize[MaS]).TenS);
				}
				foreach (int MaMS in listMaMS) {
					cbbMauSac.Items.Add(MaMS + " - " + ((MauSac)HTMauSac[MaMS]).TenMS);
				}
			}

			// doi ten
			danhSachSanPham.Columns["MaSP"].HeaderText = "Mã";
			danhSachSanPham.Columns["TenSP"].HeaderText = "Tên";
			danhSachSanPham.Columns["DonGiaBan"].HeaderText = "Giá Bán";
			danhSachSanPham.Columns["GioiTinh"].HeaderText = "Giới Tính";

			danhSachSanPham.Columns["DonGiaNhap"].Visible = false;
			danhSachSanPham.Columns["Anh"].Visible = false;
			danhSachSanPham.Columns["MaTL"].Visible = false;
			danhSachSanPham.Columns["MaCL"].Visible = false;
			danhSachSanPham.Columns["MaQG"].Visible = false;

			int n = danhSachSanPham.Columns.Count;
			for (int i = 4; i < n; i++) {
				danhSachSanPham.Columns[i].ReadOnly = true;
			}
		}

		private void btnDongPanelChonSanPham_Click(object sender, EventArgs e) {
			panelChonSanPham.Visible = false;
		}

		private void btnXacNhanSanPham_Click(object sender, EventArgs e) {
			copyData(dsSanPhamDaChon, danhSachSanPhamCuaHoaDon);
			panelChonSanPham.Visible = false;
			// tinh tien
			double TongTien = 0;
			foreach(DataGridViewRow row in danhSachSanPhamCuaHoaDon.Rows) {
				TongTien += Convert.ToDouble(row.Cells[1].Value);
			}
			txtTongTienThanhToan.Text = TongTien.ToString();
		}
		
		// tim kiem va loc
		private void txtTimSanPham_TextChanged(object sender, EventArgs e) {
			if (cbbLocTim.Text == "Mã" || cbbLocTim.Text.StartsWith("Giá")) {
				if (!Regex.IsMatch(txtTimSanPham.Text.Trim(), @"^\d+$")) {
					txtTimSanPham.Text = "";
				}
			}
			loadDanhSachChiTietSanPham();
		}

		private void txtTimSanPham_KeyPress(object sender, KeyPressEventArgs e) {
			if (cbbLocTim.Text == "Mã" || cbbLocTim.Text.StartsWith("Giá")) {
				if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
					e.Handled = true;
				}
			}
		}

		private void cbbLocTheLoai_SelectedIndexChanged(object sender, EventArgs e) {
			loadDanhSachChiTietSanPham();
		}

		private void cbbLocChatLieu_SelectedIndexChanged(object sender, EventArgs e) {
			loadDanhSachChiTietSanPham();
		}

		private void cbbLocQuocGia_SelectedIndexChanged(object sender, EventArgs e) {
			loadDanhSachChiTietSanPham();
		}

		private void cbbLocTim_SelectedIndexChanged(object sender, EventArgs e) {
			txtTimSanPham.PlaceholderText = "Nhập " + cbbLocTim.Text;
		}
		
		// validate===
		// click vao cbbChonSize hoac cbbChonMauSac goi su kien ben duoi
		private void danhSachSanPham_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
			if (danhSachSanPham.IsCurrentCellDirty) {
				// This fires the cell value changed handler below
				danhSachSanPham.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}
		// click vao cbbChonSize hoac cbbChonMauSac
		private void danhSachSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex < 0) {
				return;
			}
			DataGridViewComboBoxCell cbbSize = (DataGridViewComboBoxCell)danhSachSanPham.Rows[e.RowIndex].Cells[2];
			DataGridViewComboBoxCell cbbMauSac = (DataGridViewComboBoxCell)danhSachSanPham.Rows[e.RowIndex].Cells[3];
			String MaSP = danhSachSanPham.Rows[e.RowIndex].Cells[5].Value.ToString(); // Mã sản phẩm
			
			if (cbbSize.Value != null && cbbMauSac.Value != null) {
				// tinh so luong
				int size = Convert.ToInt32(cbbSize.Value.ToString().Replace(" ", "").Split('-')[0]);
				int mau = Convert.ToInt32(cbbMauSac.Value.ToString().Replace(" ", "").Split('-')[0]);
				List<ChiTietSP> listByMaSP = (List<ChiTietSP>)MapChiTietSP[MaSP];
				foreach (ChiTietSP item in listByMaSP) {
					if (item.MaS == size && item.MaMS == mau) {
						danhSachSanPham.Rows[e.RowIndex].Cells[4].Value = item.SoLuong.ToString();
					}
				}
			}

			if (e.ColumnIndex == 2) { // bam vao cot size
				danhSachSanPham.CurrentRow.Cells[1].Value = ""; // xoa so luong
				if (cbbSize.Value == null) { // load toan bo mau sac
					danhSachSanPham.Rows[e.RowIndex].Cells[4].Value = "";
					cbbMauSac.Items.Clear();
					cbbMauSac.Items.Add("");

					List<ChiTietSP> listByMaSP = (List<ChiTietSP>)MapChiTietSP[MaSP];
					HashSet<int> listMaMS = new HashSet<int>();
					foreach (ChiTietSP item in listByMaSP) {
						listMaMS.Add(item.MaMS);
					}
					foreach (int MaMS in listMaMS) {
						cbbMauSac.Items.Add(MaMS + " - " + ((MauSac)HTMauSac[MaMS]).TenMS);
					}
				}

				if (cbbSize.Value != null) { // load lai cbb mau sac theo size
					cbbMauSac.Items.Clear();
					cbbMauSac.Items.Add("");

					String MaS = cbbSize.Value.ToString().Replace(" ", "").Split('-')[0];
					List<ChiTietSP> listByMaSP = (List<ChiTietSP>)MapChiTietSP[MaSP];
					foreach (ChiTietSP item in listByMaSP) {
						if (item.MaS.ToString() == MaS) {
							cbbMauSac.Items.Add(item.MaMS + " - " + ((MauSac)HTMauSac[item.MaMS]).TenMS);
						}
					}
				}
				danhSachSanPham.Invalidate();
				return;
			}

			if (e.ColumnIndex == 3) { // bam vao cot mau 
				danhSachSanPham.CurrentRow.Cells[1].Value = ""; // xoa so luong
				if (cbbMauSac.Value == null) { // load toan bo size
					danhSachSanPham.Rows[e.RowIndex].Cells[4].Value = "";
					cbbSize.Items.Clear();
					cbbSize.Items.Add("");

					List<ChiTietSP> listByMaSP = (List<ChiTietSP>)MapChiTietSP[MaSP];
					HashSet<int> listMaS = new HashSet<int>();
					foreach (ChiTietSP item in listByMaSP) {
						listMaS.Add(item.MaS);
					}
					foreach (int MaS in listMaS) {
						cbbSize.Items.Add(MaS + " - " + ((Model.Size)HTSize[MaS]).TenS);
					}
				}

				if (cbbMauSac.Value != null) { // load lai cbb size theo mau sac
					cbbSize.Items.Clear();
					cbbSize.Items.Add("");

					String MaMS = cbbMauSac.Value.ToString().Replace(" ", "").Split('-')[0];
					List<ChiTietSP> listByMaSP = (List<ChiTietSP>)MapChiTietSP[MaSP];
					foreach (ChiTietSP item in listByMaSP) {
						if (item.MaMS.ToString() == MaMS) {
							cbbSize.Items.Add(item.MaS + " - " + ((Model.Size)HTSize[item.MaS]).TenS);
						}
					}
				}

				danhSachSanPham.Invalidate();
				return;
			}
		}
		
		// Validate Nhap so Luong mua
		private void danhSachSanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 1) {
				if (((DataGridViewComboBoxCell)danhSachSanPham.CurrentRow.Cells[2]).Value == null) {
					MessageBox.Show("Chưa chọn size");
					danhSachSanPham.CancelEdit();
					danhSachSanPham.CurrentRow.Cells[1].Value = "";
					return;
				}
				if (((DataGridViewComboBoxCell)danhSachSanPham.CurrentRow.Cells[3]).Value == null) {
					MessageBox.Show("Chưa chọn màu");
					danhSachSanPham.CancelEdit();
					danhSachSanPham.CurrentRow.Cells[1].Value = "";
					return;
				}

				if (danhSachSanPham.CurrentRow.Cells[1].Value == null) {
					return;
				}

				if (!Regex.IsMatch(danhSachSanPham.CurrentRow.Cells[1].Value.ToString().Trim(), @"^\d+$")) {
					danhSachSanPham.CancelEdit();
					danhSachSanPham.CurrentRow.Cells[1].Value = "";
					return;
				}

				int SoLuong = Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[1].Value);
				int SoLuongConLai = Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[4].Value);
				if (SoLuongConLai == 0) {
					MessageBox.Show("Chưa chọn đủ size và màu");
					danhSachSanPham.CancelEdit();
					danhSachSanPham.CurrentRow.Cells[1].Value = "";
					return;
				}
				if (SoLuong > SoLuongConLai) {
					MessageBox.Show("Không được lớn hơn số sản phẩm còn lại");
					danhSachSanPham.CancelEdit();
					danhSachSanPham.CurrentRow.Cells[1].Value = "";
					return;
				}
			}
		}

		private void danhSachSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				if (((DataGridViewComboBoxCell)danhSachSanPham.CurrentRow.Cells[2]).Value == null) {
					MessageBox.Show("Chưa chọn size");
					return;
				}
				if (((DataGridViewComboBoxCell)danhSachSanPham.CurrentRow.Cells[3]).Value == null) {
					MessageBox.Show("Chưa chọn màu");
					return;
				}
				if (danhSachSanPham.CurrentRow.Cells[1].Value == null || danhSachSanPham.CurrentRow.Cells[1].Value.ToString() == "") {
					MessageBox.Show("Số lượng không được để trống");
					return;
				}

				DataGridViewRow row;
				if (dsSanPhamDaChon.Rows.Count == 0) {
					dsSanPhamDaChon.Rows.Add();
					row = (DataGridViewRow)dsSanPhamDaChon.Rows[0].Clone();
					dsSanPhamDaChon.Rows.RemoveAt(Top);
				} else {
					row = (DataGridViewRow)dsSanPhamDaChon.Rows[0].Clone();
				}

				row.Cells[1].Value = Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[1].Value) * Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[7].Value); // don gia
				row.Cells[2].Value = danhSachSanPham.CurrentRow.Cells[1].Value; // so luong
				row.Cells[3].Value = danhSachSanPham.CurrentRow.Cells[6].Value; // san pham
				row.Cells[4].Value = danhSachSanPham.CurrentRow.Cells[5].Value; // ma

				row.Cells[5].Value = ((DataGridViewComboBoxCell)danhSachSanPham.CurrentRow.Cells[2]).Value; // size
				row.Cells[6].Value = ((DataGridViewComboBoxCell)danhSachSanPham.CurrentRow.Cells[3]).Value; // mau

				row.Cells[7].Value = danhSachSanPham.CurrentRow.Cells[7].Value; // gia ban
				row.Cells[8].Value = danhSachSanPham.CurrentRow.Cells[14].Value; // the loai
				row.Cells[9].Value = danhSachSanPham.CurrentRow.Cells[15].Value; // chat lieu
				row.Cells[10].Value = danhSachSanPham.CurrentRow.Cells[16].Value; // quoc gia


				// neu da ton tai thi thay so luong thoi
				foreach (DataGridViewRow r in dsSanPhamDaChon.Rows) {
					if (r.Cells[4].Value.ToString().Replace(" ", "") == row.Cells[4].Value.ToString().Replace(" ", "")
							&& r.Cells[5].Value.ToString().Replace(" ", "") == row.Cells[5].Value.ToString().Replace(" ", "")
							&& r.Cells[6].Value.ToString().Replace(" ", "") == row.Cells[6].Value.ToString().Replace(" ", "")) {
						r.Cells[1].Value = row.Cells[1].Value;
						r.Cells[2].Value = row.Cells[2].Value;
						return;
					}
				}
				dsSanPhamDaChon.Rows.Add(row);
			}
		}

		private void dsSanPhamDaChon_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				((BunifuDataGridView)sender).Rows.Remove(((BunifuDataGridView)sender).CurrentRow);
			}

			// tinh lai tien
			double TongTien = 0;
			foreach(DataGridViewRow row in ((BunifuDataGridView)sender).Rows) {
				TongTien += Convert.ToDouble(row.Cells[1].Value.ToString()) * Convert.ToDouble(row.Cells[2].Value.ToString());
			}
			txtTongTienThanhToan.Text = TongTien.ToString();
		}
		#endregion


		// utils
		private void copyData(DataGridView source, DataGridView des) {
			des.Rows.Clear();
			DataGridViewRow row = new DataGridViewRow();
			for (int i = 0; i < source.Rows.Count; i++) {
				row = (DataGridViewRow)source.Rows[i].Clone();
				int intColIndex = 0;
				foreach (DataGridViewCell cell in source.Rows[i].Cells) {
					row.Cells[intColIndex].Value = cell.Value;
					intColIndex++;
				}
				des.Rows.Add(row);
			}
			des.AllowUserToAddRows = false;
			des.Refresh();
		}
	}
}
