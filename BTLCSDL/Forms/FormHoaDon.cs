using BTLCSDL.DAO;
using BTLCSDL.DAO.impl;
using BTLCSDL.Model;
using System;
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

namespace BTLCSDL.Forms {
	public partial class FormHoaDon : Form {
		ModelDAO<HoaDon> hdDao;
		ModelDAO<NhanVien> nvDao;
		ModelDAO<SanPham> spDao;
		ChiTietHoaDonDAO cthdDao;
		private bool isThem;
		List<NhanVien> listNhanVien;
		List<SanPham> listSanPham;

		public FormHoaDon() {
			InitializeComponent();
			hdDao = new HoaDonDao();
			nvDao = new NhanVienDao();
			spDao = new SanPhamDAO();
			cthdDao = new ChiTietHoaDonDAO();


			listNhanVien = ((NhanVienDao)nvDao).getListAll();


			foreach (NhanVien nv in listNhanVien) {
				cbbListNhanVien.Items.Add(nv.HoVaTen + " - " + nv.id);
			}
			//txtNamSinh.CustomFormat = "yyyy-MM-dd";
			//txtNgayBDLam.CustomFormat = "yyyy-MM-dd";

			ControlExtension.Draggable(formThemHoaDon, true);
			ControlExtension.Draggable(panelChonSanPham, true);
		}

		private void FormHoaDon_Load(object sender, EventArgs e) {
			table.DataSource = ((HoaDonDao)hdDao).getAll();
			txtTongTienThanhToan.Text = "0";
			txtTienKhachTra.Text = "0";
			txtTienTraLai.Text = "0";
		}


		private void txtTim_TextChanged(object sender, EventArgs e) {
			if (!Regex.IsMatch(txtTimHoaDon.Text.Trim(), @"^\d+$")) {
				txtTimHoaDon.Text = "";
			}

			if ("".Equals(txtTimHoaDon.Text)) {
				FormHoaDon_Load(sender, e);
				return;
			}

			table.DataSource = ((HoaDonDao)hdDao).search(Convert.ToInt32(txtTimHoaDon.Text));
			// check nhung san pham da chon
		}

		private void txtTimHoaDon_KeyPress(object sender, KeyPressEventArgs e) {
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
				e.Handled = true;
			}
		}

		private void table_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				isThem = true;
				hdDao.delelte(Convert.ToInt32(table.CurrentRow.Cells[2].Value));
				FormHoaDon_Load(sender, e);
				return;
			}

			if (e.ColumnIndex == 1) {
				isThem = false;
				btnThemSubmit.Text = " sửa";
				setForm();
				loadListSanPham();
				loadDanhSachSanPhamHoaDon();
				formThemHoaDon.Visible = true;
			}
		}

		private void btnThemHoaDon_Click(object sender, EventArgs e) {
			formThemHoaDon.Visible = true;
		}

		// form hoa don =========================================
		private void listNhanVien_SelectedIndexChanged(object sender, EventArgs e) {
			txtNhanVienID.Text = cbbListNhanVien.Text.Trim().Split('-')[1];
		}

		private void btnThemSanPham_Click(object sender, EventArgs e) {
			panelChonSanPham.Visible = true;
			danhSachSanPham.DataSource = ((SanPhamDAO)spDao).getDanhSach();
			int n = danhSachSanPham.Columns.Count;
			for (int i = 2; i < n; i++) {
				danhSachSanPham.Columns[i].ReadOnly = true;
			}

			// list tam thoi
			tmp = new List<SanPham>(listSanPham);
			CheckNhungSanPhamDaChon();
		}

		private void loadDanhSachSanPhamHoaDon() {
			var bindingList = new BindingList<SanPham>(listSanPham);
			var source = new BindingSource(bindingList, null);
			danhSachSanPhamCuaHoaDon.DataSource = source;
		}

		private void btnDongFromHoaDon_Click(object sender, EventArgs e) {
			formThemHoaDon.Visible = false;
			// xoa danh sach san pham neu submit
			listSanPham = null;
			FormHoaDon_Load(sender, e);
		}

		private HoaDon getForm() {
			HoaDon hd = new HoaDon();
			if (txtHoaDonID.Text != "") {
				hd.id = Convert.ToInt32(txtHoaDonID.Text);
			}
			hd.TongTienThanhToan = Convert.ToInt32(txtTongTienThanhToan.Text);
			hd.TienKhachTra = Convert.ToInt32(txtTienKhachTra.Text);
			hd.TienTraLai = Convert.ToInt32(txtTienTraLai.Text);
			hd.NhanVienId = Convert.ToInt32(txtNhanVienID.Text);
			hd.NgayBan = dtpNgayBan.Value;
			return hd;
		}

		private void setForm() {
			txtHoaDonID.Text = Convert.ToString(table.CurrentRow.Cells[2].Value);
			txtTongTienThanhToan.Text = Convert.ToString(table.CurrentRow.Cells[3].Value).Split(',')[0];
			txtTienKhachTra.Text = table.CurrentRow.Cells[4].Value.ToString().Split(',')[0];
			txtTienTraLai.Text = Convert.ToString(table.CurrentRow.Cells[5].Value).Split(',')[0];
			txtNhanVienID.Text = Convert.ToString(table.CurrentRow.Cells[6].Value);
			dtpNgayBan.Value = Convert.ToDateTime(table.CurrentRow.Cells[7].Value);
		}

		private void loadListSanPham() {
			List<ChiTietHoaDon> cthdList = cthdDao.getListByHoaDonID(Convert.ToInt32(txtHoaDonID.Text));
			listSanPham = new List<SanPham>();
			foreach(ChiTietHoaDon cthd in cthdList) {
				SanPham sp = ((SanPhamDAO)spDao).getById(cthd.SanPhamId);
				sp.SoLuong = cthd.SoLuong;
				sp.ThanhTien = sp.SoLuong * sp.DonGia;
				listSanPham.Add(sp);
			}
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
			HoaDon hd = getForm();
			if (hd == null) {
				return;
			}
			if (isThem) {
				int createId = hdDao.create(hd);
				// create chi tiet hoa dn
				if (createId == -1) {
					MessageBox.Show("khong them duoc vi da ton tai ");
					return;
				}

				List<ChiTietHoaDon> list = getListCTHD(createId);
				foreach(ChiTietHoaDon c in list) {
					cthdDao.create(c);
				}

			} else { // sua
				List<ChiTietHoaDon> oldList = cthdDao.getListByHoaDonID(hd.id);
				List<ChiTietHoaDon> newList = getListCTHD(hd.id);


				bool isContain = false;
				foreach (ChiTietHoaDon newCTHD in newList) {
					isContain = false;
					foreach(ChiTietHoaDon old in oldList) {
						if (old.SanPhamId == newCTHD.SanPhamId) {
							isContain = true;
							break;
						}					
					}
					if(isContain) {
						cthdDao.update(newCTHD);
					} else {
						cthdDao.create(newCTHD);
					}
				}

				hdDao.update(hd);
				btnDongFrom.PerformClick();
			}

			// xoa danh sach san pham neu submit
			listSanPham = null;

			FormHoaDon_Load(sender, e);
		}

		private List<ChiTietHoaDon> getListCTHD(int hdID) {
			List<ChiTietHoaDon> cthd = new List<ChiTietHoaDon>();
			foreach (SanPham sp in listSanPham) {
				ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
				chiTietHoaDon.HoaDonId = hdID;
				chiTietHoaDon.SanPhamId = sp.id;
				chiTietHoaDon.SoLuong = sp.SoLuong;
				cthd.Add(chiTietHoaDon);
			}
			return cthd;
		}

		private void CheckNhungSanPhamDaChon() {
			foreach (DataGridViewRow row in danhSachSanPham.Rows) {
				DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
				foreach (SanPham sp in tmp) {
					if (sp.id == Convert.ToInt32(row.Cells[2].Value)) {
						chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
						row.Cells[1].Value = sp.SoLuong;
					}
				}
			}
		}

		// panel chon san pham ===================================
		private	List<SanPham> tmp;

		private void btnDongPanelChonSanPham_Click(object sender, EventArgs e) {
			panelChonSanPham.Visible = false;
			tmp = null;
			loadDanhSachSanPhamHoaDon();
		}

		private void btnXacNhanSanPham_Click(object sender, EventArgs e) {
			bool isContain = false;
			int index;
			foreach(SanPham spNew in tmp) {
				if (spNew.SoLuong == 0) {
					MessageBox.Show("vui long dien so luong san pham can mua");
					return;
				}
			}
			listSanPham = new List<SanPham>(tmp);

			// tinh tong tien
			int Tong = 0;
			foreach (SanPham sp in listSanPham) {
				Tong += sp.ThanhTien;
			}
			txtTongTienThanhToan.Text = Tong.ToString();

			panelChonSanPham.Visible = false;
			loadDanhSachSanPhamHoaDon();
		}

		private void txtTimSanPham_TextChanged(object sender, EventArgs e) {
			danhSachSanPham.DataSource = ((SanPhamDAO)spDao).getDanhSach(txtTimSanPham.Text);
			// check nhung san pham da chon
			CheckNhungSanPhamDaChon();
		}

		private void danhSachSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) { // nut chon
				if (Convert.ToBoolean(danhSachSanPham.CurrentCell.Value)) {
					foreach (SanPham s in tmp) {
						if (s.id == Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[2].Value)) {
							tmp.Remove(s);
							return;
						}
					}	
				}

				int SoLuong = Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[1].Value);

				if (SoLuong > Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[4].Value)) {
					MessageBox.Show("Khong duoc lon hon so san pham con lai");
					danhSachSanPham.CurrentRow.Cells[1].Value = "";
					danhSachSanPham.CancelEdit();
					return;
				}

				SanPham sp = new SanPham();
				sp.id = Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[2].Value);
				sp.SoLuong = SoLuong;
				sp.TenSanPham = Convert.ToString(danhSachSanPham.CurrentRow.Cells[3].Value);
				sp.DonGia = Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[5].Value);
				sp.ThanhTien = sp.SoLuong * sp.DonGia;

				tmp.Add(sp);
				return;
			}
		}

		private void danhSachSanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 1) {
				if (!Regex.IsMatch(danhSachSanPham.CurrentRow.Cells[1].Value.ToString().Trim(), @"^\d+$")) {
					danhSachSanPham.CancelEdit();
					danhSachSanPham.CurrentRow.Cells[1].Value = "";
					return;
				}

				int SoLuong = Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[1].Value);

				if (SoLuong > Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[4].Value)) {
					MessageBox.Show("Khong duoc lon hon so san pham con lai");
					danhSachSanPham.CancelEdit();
					danhSachSanPham.CurrentRow.Cells[1].Value = "";
					return;
				}

				foreach (SanPham sp in tmp) {
					int idHientai = Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[2].Value);
					if (idHientai == sp.id) {
						sp.SoLuong = SoLuong;
						sp.ThanhTien = SoLuong * Convert.ToInt32(danhSachSanPham.CurrentRow.Cells[5].Value);
					}
				}
			}
		}

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
    }
}
