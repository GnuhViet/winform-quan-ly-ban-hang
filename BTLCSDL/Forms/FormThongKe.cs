using BTLCSDL.DAO.impl;
using BTLCSDL.Model;
using Bunifu.UI.WinForms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTLCSDL.Forms {
	public partial class FormThongKe : Form {
		private BaoCaoDAO dao;
		private DynamicDAO nhanVienDAO;
		private SaveFileDialog save;
		private Hashtable HTNhanVien;


		private String namHienTai = DateTime.Now.Year.ToString();
		private int month = DateTime.Now.Month;
		private String quyHienTai;


		public FormThongKe(BaoCaoDAO dao, DynamicDAO nhanVienDAO) {
			InitializeComponent();
			this.dao = dao;
			this.nhanVienDAO = nhanVienDAO;

			HTNhanVien = nhanVienDAO.getHashtableAll();
			foreach (NhanVien nv in nhanVienDAO.getListAll()) {
				cbbNhanVien.Items.Add(nv.HoTenNV);
			}

			save = new SaveFileDialog();
			save.DefaultExt = "xlsx";
			save.FileName = "untitled";
			save.Filter = "Excel (*.xlsx)|*.xlsx";
			txtNamBaoCaoNhap.Size = new System.Drawing.Size(123, 37);
			txtNamKhachHang.Size = new System.Drawing.Size(123, 37);
			
			quyHienTai = ((month + 2) / 3).ToString();
		}

		#region utils
		private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e) {
			String HoTenNV = cbbNhanVien.Text;
			baoCaoBan.DataSource = dao.HoaDonBanTheoNhanVien(HoTenNV);
			double TongTien = dao.TongTienHoaDonBanTheoNhanVien(HoTenNV);
			if (HoTenNV == "") {
				txtTongTien.Text = "  -Chưa Chọn Nhân Viên-";
				return;
			}
			txtTongTien.Text = TongTien.ToString();
		}

		private void addWorksheet(DataTable dt, XLWorkbook wb, String sheetName, String title) {
			var ws = wb.Worksheets.Add(sheetName);
			ws.Cell("B2").Value = title;

			ws.Range("B2:E2").Row(1).Merge();

			ws.Cell(4, 2).InsertTable(dt);
			ws.Columns().AdjustToContents();
			ws.Tables.FirstOrDefault().ShowAutoFilter = false;

			ws.Cells().Style.Border.LeftBorder = XLBorderStyleValues.Thin;
			ws.Cell("B2").Style.Border.LeftBorder = XLBorderStyleValues.None;
		}

		private void saveFile(XLWorkbook wb) {
			if (save.ShowDialog() == DialogResult.OK) {
				try {
					wb.SaveAs(save.FileName);
					MessageBox.Show("Lưu thành công");
				} catch {
					MessageBox.Show("Lưu thất bại");
				}
			}
		}

		#endregion

		private void FormThongKe_Load(object sender, EventArgs e) {
			baoCaoBan.DataSource = dao.HoaDonBanTheoNhanVien("");
			danhSachSanPhamTonKho.DataSource = dao.danhSachSanPhamTonKho();
			baoCaoNhap.DataSource = dao.HoaDonNhapTheoQuyVaNam(this.quyHienTai, this.namHienTai);
			topKhachHang.DataSource = dao.Top3KhachHang(this.quyHienTai, this.namHienTai);
		}

		private void btnTaoBaoCaoNhap_Click(object sender, EventArgs e) {
			String nam = txtNamBaoCaoNhap.Text;
			String quy = cbbQuyBaoCaoNhap.Text;

			if (quy == "" || quy == null) {
				MessageBox.Show("Chưa chọn quý");
				return;
			}
			if (nam == "") {
				MessageBox.Show("Chưa nhập năm");
				return;
			}
			try {
				int y = Convert.ToInt32(nam);
				if (y < 0) {
					MessageBox.Show("Năm không tồn tại");
					return;
				}
			} catch {
				MessageBox.Show("Năm không tồn tại");
				return;
			}

			baoCaoNhap.DataSource = dao.HoaDonNhapTheoQuyVaNam(quy, nam);
		}

		private void btnTaoBaoCaoKhach_Click(object sender, EventArgs e) {
			String nam = txtNamBaoCaoNhap.Text;
			String quy = cbbQuyBaoCaoNhap.Text;

			if (quy == "" || quy == null) {
				MessageBox.Show("Chưa chọn quý");
				return;
			}
			if (nam == "") {
				MessageBox.Show("Chưa nhập năm");
				return;
			}
			try {
				int y = Convert.ToInt32(nam);
				if (y < 0) {
					MessageBox.Show("Năm không tồn tại");
					return;
				}
			} catch {
				MessageBox.Show("Năm không tồn tại");
				return;
			}

			topKhachHang.DataSource = dao.Top3KhachHang(quy, nam);
		}

		// excel

		private void btnBaoCaoDSTonKho_Click(object sender, EventArgs e) {
			XLWorkbook wb = new XLWorkbook();
			addWorksheet(dao.danhSachSanPhamTonKho(), wb, "Sản Phẩm", "Báo Cáo Danh Sách Sản Phẩm Tồn Kho");
			saveFile(wb);
		}

		private void btnBaoCaoBan_Click(object sender, EventArgs e) {
			String HoTenNV = cbbNhanVien.Text;
			DataTable dt = dao.HoaDonBanTheoNhanVien(HoTenNV == null ? "" : HoTenNV);
			double TongTien = 0;

			if (HoTenNV == null || HoTenNV == "") {
				MessageBox.Show("Bạn chưa chọn nhân viên, \n sẽ xuất ra file toàn bộ hoá đơn");
				foreach (DataRow dr in dt.Rows) {
					TongTien += Convert.ToDouble(dr[2]);
				}
			} else {
				TongTien = dao.TongTienHoaDonBanTheoNhanVien(HoTenNV);
			}

			DataRow r = dt.NewRow();

			r[4] = "Tổng Tiền: " + TongTien;

			dt.Rows.Add(dt.NewRow());
			dt.Rows.Add(r);

			XLWorkbook wb = new XLWorkbook();
			addWorksheet(dt, wb, "Hoá Đơn Bán", "Báo Cáo Hoá Đơn Theo Nhân Viên");
			saveFile(wb);
		}

		private void btnBaoCaoNhap_Click(object sender, EventArgs e) {
			XLWorkbook wb = new XLWorkbook();
			addWorksheet((DataTable)baoCaoNhap.DataSource, wb,
				"Hoá Đơn Nhập", $"Báo Cáo Hoá Đơn Nhập Theo Quý:{cbbQuyBaoCaoNhap.Text}, Năm: {txtNamBaoCaoNhap.Text}");
			saveFile(wb);
		}
		
		private void btnTopKhachHang_Click(object sender, EventArgs e) {
			XLWorkbook wb = new XLWorkbook();
			addWorksheet((DataTable)topKhachHang.DataSource, wb,
				"Top Khách", $"Top Khách Hàng Mua Nhiều Nhất Theo Quý:{cbbQuyBaoCaoNhap.Text}, Năm: {txtNamBaoCaoNhap.Text}");
			saveFile(wb);
		}

		private void btnXuatBaoCao_Click(object sender, EventArgs e) {
			// xuat toan bo 4 bao cao
			XLWorkbook wb = new XLWorkbook();
			addWorksheet(dao.danhSachSanPhamTonKho(), wb, "Sản Phẩm", "Báo Cáo Danh Sách Sản Phẩm Tồn Kho");
			addWorksheet((DataTable)baoCaoBan.DataSource, wb, "Hoá Đơn Bán", "Báo Cáo Hoá Đơn Bán Trong Quý");
			addWorksheet((DataTable)baoCaoNhap.DataSource, wb, "Hoá Đơn Nhập", "Báo Cáo Hoá Đơn Nhập Trong Quý");
			addWorksheet((DataTable)topKhachHang.DataSource, wb, "Top Khách", "Top khách hàng mua nhiều nhất trong quý");
			saveFile(wb);
		}

	}
}
