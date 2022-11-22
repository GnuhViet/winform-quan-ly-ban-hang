using BTLCSDL.DAO.impl;
using BTLCSDL.Model;
using Bunifu.UI.WinForms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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
		private ReflectionDAO nhanVienDAO;
		private SaveFileDialog save;
		private Hashtable HTNhanVien;	
		
		
		public FormThongKe(BaoCaoDAO dao, ReflectionDAO nhanVienDAO) {
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
			

			baoCaoBan.DataSource = dao.HoaDonTheoNhanVien("");
		}

		#region utils

		private void txtValidate_KeyPress(object sender, KeyPressEventArgs e) {
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
				e.Handled = true;
			}
		}

		private void txtValidate_TextChange(object sender, EventArgs e) {
			if (!Regex.IsMatch(((BunifuTextBox)sender).Text.Trim(), @"^\d+$")) {
				((BunifuTextBox)sender).Text = "";
				return;
			}
		}

		private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e) {
			String HoTenNV = cbbNhanVien.Text;
			baoCaoBan.DataSource = dao.HoaDonTheoNhanVien(HoTenNV);
			double TongTien = dao.TongTienHoaDonTheoNhanVien(HoTenNV);
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

		private void btnXuatBaoCao_Click(object sender, EventArgs e) {
			// xuat toan bo 4 bao cao
			XLWorkbook wb = new XLWorkbook();

			#region hoa don ban
			DataTable dtHoaDonBan = dao.HoaDonTheoNhanVien("");
			double TongTien = 0;
			DataRow r = dtHoaDonBan.NewRow();
			foreach (DataRow dr in dtHoaDonBan.Rows) {
				TongTien += Convert.ToDouble(dr[2]);
			}
			r[4] = "Tổng Tiền: " + TongTien;

			dtHoaDonBan.Rows.Add(dtHoaDonBan.NewRow());
			dtHoaDonBan.Rows.Add(r);
			#endregion

			addWorksheet(dao.danhSachSanPhamTonKho(), wb, "Sản Phẩm", "Báo Cáo Danh Sách Sản Phẩm Tồn Kho");
			addWorksheet(dtHoaDonBan, wb, "Hoá Đơn Bán", "Báo Cáo Hoá Đơn");

			saveFile(wb);
		}

		private void FormThongKe_Load(object sender, EventArgs e) {
			danhSachSanPhamTonKho.DataSource = dao.danhSachSanPhamTonKho();
		}


		private void btnBaoCaoDSTonKho_Click(object sender, EventArgs e) {
			XLWorkbook wb = new XLWorkbook();
			addWorksheet(dao.danhSachSanPhamTonKho(), wb, "Sản Phẩm", "Báo Cáo Danh Sách Sản Phẩm Tồn Kho");
			saveFile(wb);
		}

		private void btnBaoCaoBan_Click(object sender, EventArgs e) {
			String HoTenNV = cbbNhanVien.Text;
			DataTable dt = dao.HoaDonTheoNhanVien(HoTenNV == null ? "" : HoTenNV);
			double TongTien = 0;

			if (HoTenNV == null || HoTenNV == "") {
				MessageBox.Show("Bạn chưa chọn nhân viên, \n sẽ xuất ra file toàn bộ hoá đơn");
				foreach(DataRow dr in dt.Rows) {
					TongTien += Convert.ToDouble(dr[2]);
				}
			} else {
				TongTien = dao.TongTienHoaDonTheoNhanVien(HoTenNV);
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

		}

		private void btnTopKhachHang_Click(object sender, EventArgs e) {

		}
	}
}
