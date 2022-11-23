using BTLCSDL.Model;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSDL.DAO.impl {
	public class BaoCaoDAO : CommonDAO {
		public BaoCaoDAO() {

		}
		
		public DataTable danhSachSanPhamTonKho() {
			return table("select * from SanPhamTonKho");
		}
		
		public DataTable HoaDonBanTheoNhanVien(String HoTenNV) {
			int Luong = 0;
			SqlConnection con = connection.getConnection();

			sqlCommand = new SqlCommand("SELECT * from fn_DanhSachHoaDonTheoNhanVien(@HoTenNV)", con);
			sqlCommand.Parameters.AddWithValue("@HoTenNV", HoTenNV);

			DataTable dt = new DataTable();
			dt.Columns.Add("Mã Hoá Đơn Bán", typeof(int));
			dt.Columns.Add("Ngày Bán", typeof(DateTime));
			dt.Columns.Add("Tổng Tiền", typeof(double));
			dt.Columns.Add("Tên Nhân Viên", typeof(String));
			dt.Columns.Add("Tên Khách", typeof(String));
					
			con.Open();
			IDataReader reader = sqlCommand.ExecuteReader();
			while (reader.Read()) {
				dt.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
			}
			con.Close();
			return dt;
		}
		
		public double TongTienHoaDonBanTheoNhanVien(String HoTenNV) {
			double Tien = 0;
			SqlConnection con = connection.getConnection();

			con.Open();
			try {
				sqlCommand = new SqlCommand("SELECT dbo.fn_TinhTongTienTheoNhanVien(@HoTenNV)", con);
				sqlCommand.Parameters.AddWithValue("@HoTenNV", HoTenNV);
				Tien = Convert.ToInt32(sqlCommand.ExecuteScalar());
			} catch { }

			con.Close();
			return Tien;
		}

		public DataTable HoaDonNhapTheoQuyVaNam(String quy,String nam) {
			SqlConnection con = connection.getConnection();
			String monthS = "1";
			String monthE = "3";
			if (quy == "1") {
				monthS = "1";
				monthE = "3";
			} else if (quy == "2") {
				monthS = "4";
				monthE = "6";
			} else if (quy == "3") {
				monthS = "7";
				monthE = "9";
			} else if (quy == "4") {
				monthS = "10";
				monthE = "12";
			}

			sqlCommand = new SqlCommand("SELECT * from fn_BaoCaoHoaDonNhapTheoQuyVaNam(@monthStart, @monthEnd, @nam)", con);
			
			sqlCommand.Parameters.AddWithValue("@monthStart", Convert.ToInt32(monthS));
			sqlCommand.Parameters.AddWithValue("@monthEnd", Convert.ToInt32(monthE));
			sqlCommand.Parameters.AddWithValue("@nam", Convert.ToInt32(nam));

			DataTable dt = new DataTable();
			dt.Columns.Add("Mã", typeof(int));
			dt.Columns.Add("Ngày Nhập", typeof(DateTime));
			dt.Columns.Add("Mã Số Thuế", typeof(String));
			dt.Columns.Add("Tên Nhà Cung Cấp", typeof(String));
			dt.Columns.Add("Tên Nhân Viên", typeof(String));
			dt.Columns.Add("Tổng Tiền", typeof(Double));

			con.Open();
			IDataReader reader = sqlCommand.ExecuteReader();
			while (reader.Read()) {
				dt.Rows.Add(reader[0].ToString(), 
					reader[1].ToString(), 
					reader[2].ToString(), 
					reader[3].ToString(),
					reader[4].ToString(),
					reader[5].ToString());
			}
			con.Close();
			return dt;
		}
		
		public DataTable Top3KhachHang(String quy, String nam) {
			SqlConnection con = connection.getConnection();
			String monthS = "1";
			String monthE = "3";
			if (quy == "1") {
				monthS = "1";
				monthE = "3";
			} else if (quy == "2") {
				monthS = "4";
				monthE = "6";
			} else if (quy == "3") {
				monthS = "7";
				monthE = "9";
			} else if (quy == "4") {
				monthS = "10";
				monthE = "12";
			}

			sqlCommand = new SqlCommand("SELECT * from fn_Top3KhachHang(@monthStart, @monthEnd, @nam)", con);

			sqlCommand.Parameters.AddWithValue("@monthStart", Convert.ToInt32(monthS));
			sqlCommand.Parameters.AddWithValue("@monthEnd", Convert.ToInt32(monthE));
			sqlCommand.Parameters.AddWithValue("@nam", Convert.ToInt32(nam));

			DataTable dt = new DataTable();
			dt.Columns.Add("Mã", typeof(int));
			dt.Columns.Add("Họ Tên", typeof(String));
			dt.Columns.Add("Số Điện Thoại", typeof(String));
			dt.Columns.Add("Tổng Tiền", typeof(Double));

			con.Open();
			IDataReader reader = sqlCommand.ExecuteReader();
			while (reader.Read()) {
				dt.Rows.Add(reader[0].ToString(),
					reader[1].ToString(),
					reader[2].ToString(),
					reader[3].ToString());
			}
			con.Close();
			return dt;
		}
	}
}
