using BTLCSDL.DAO;
using BTLCSDL.DAO.impl;
using BTLCSDL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLCSDL.Forms {
	public partial class FormThongKe : Form {
		//private ThongKeDAO dao;
		private ModelDAO<NhanVien> nvDao;

		public FormThongKe() {
			InitializeComponent();
			//dao = new ThongKeDAO();
			nvDao = new NhanVienDao();
		}

        private void FormThongKe_Load(object sender, EventArgs e) {
			loadTop10SanPham();
			loadBangLuong();
			loadDoanhThu((int)txtThangBD.Value, (int)txtThangKT.Value, (int)txtNam.Value);
		}

		public void loadTop10SanPham() {
			/*
			List<SanPham> top10 = dao.top10SanPhamBanChay();
			int i = top10.Count;
			foreach (SanPham sp in top10) {
				top10sanphambanchay.series.add(sp.tensanpham);
				top10sanphambanchay.series[sp.tensanpham].charttype = system.windows.forms.datavisualization.charting.seriescharttype.bar;
				top10sanphambanchay.series[sp.tensanpham].points.addy(sp.soluong);
				top10sanphambanchay.series[sp.tensanpham]["pixelpointwidth"] = "60";
				top10sanphambanchay.series[sp.tensanpham]["pointwidth"] = "0.5";
				top10sanphambanchay.series[sp.tensanpham].font = new system.drawing.font("consolas", 15f);
			}
			*/

			top10SanPhamBanChay.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
			top10SanPhamBanChay.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
			top10SanPhamBanChay.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
			top10SanPhamBanChay.ChartAreas[0].AxisX.Interval = 0;
			top10SanPhamBanChay.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
			top10SanPhamBanChay.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
			top10SanPhamBanChay.ChartAreas[0].AxisX.LineWidth = 0;
		}
		
		public void loadBangLuong() {
			List<NhanVien> listNhanVien = ((NhanVienDao)nvDao).getListAll();
			foreach(NhanVien nv in listNhanVien) {
				//nv.Luong = dao.tinhLuong(nv.id);
			}
			var bindingList = new BindingList<NhanVien>(listNhanVien);
			var source = new BindingSource(bindingList, null);
			bangLuong.DataSource = source;
		}

		public void loadDoanhThu(int bd, int kt, int nam) {

			DataTable dt = null; //dao.DoanhThu(bd, kt, nam);
			int i = 0;
			foreach (DataRow row in dt.Rows) {
				String thang = row[0].ToString();
				String SoLuong = row[1].ToString();
				String DonGia = row[2].ToString();

				chartDoanhThu.Series["Tháng"].Points.AddXY("Tháng " + thang, DonGia);
				chartDoanhThu.Series["Tháng"].Points[i++].Label = "Số sản phẩm: " + SoLuong;
			}

			chartDoanhThu.ChartAreas[0].AxisY.Title = "Số Tiền";

			chartDoanhThu.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			chartDoanhThu.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
			chartDoanhThu.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
			chartDoanhThu.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
		}

		private void btnTinhLuong_Click(object sender, EventArgs e) {

			int Luong = 123;//dao.tinhLuong(Convert.ToInt32(20));
			MessageBox.Show("Luong cua nhan vien co ma tren la: " + Luong.ToString(), "Thong Bao!");
		}

		private void txtThangBD_ValueChanged(object sender, EventArgs e) {
			chartDoanhThu.Series.RemoveAt(0);
			chartDoanhThu.Series.Add("Tháng");
			chartDoanhThu.Series["Tháng"].ChartType = SeriesChartType.Column;
			loadDoanhThu((int)txtThangBD.Value,(int)txtThangKT.Value,(int)txtNam.Value);
		}
	}
}
