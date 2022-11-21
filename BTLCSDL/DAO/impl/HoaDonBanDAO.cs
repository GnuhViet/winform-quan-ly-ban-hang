using BTLCSDL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSDL.DAO.impl {
	internal class HoaDonBanDAO : ReflectionDAO {
		public HoaDonBanDAO() : base(typeof(HoaDonBan)) {

		}

		public DataTable searchByTenSP(String TenSP) {
			return table("select distinct HoaDonBan.* from HoaDonBan " +
				"join ChiTietHDB CTH on HoaDonBan.MaHDB = CTH.MaHDB " +
				"join ChiTietSP CTS on CTH.MaCTSP = CTS.MaCTSP " +
				$"join SanPham SP on CTS.MaSP = SP.MaSP where TenSP like N'{TenSP}%'");
		}

		public DataTable searchByTenNV(String TenNV) {
			return table($"select distinct HoaDonBan.* from HoaDonBan join NhanVien NV on HoaDonBan.MaNV = NV.MaNV where HoTenNV like N'{TenNV}%'");
		}

		public DataTable searchByTenKH(String TenKH) {
			return table($"select distinct HoaDonBan.* from HoaDonBan join KhachHang KH on HoaDonBan.MaKH = KH.MaKH where HoTenKH like N'{TenKH}%'");
		}
	}
}
