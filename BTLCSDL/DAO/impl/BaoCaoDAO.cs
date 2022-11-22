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
		
		public DataTable HoaDonTheoNhanVien(String HoTenNV) {
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

		public double TongTienHoaDonTheoNhanVien(String HoTenNV) {
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
	}
}
