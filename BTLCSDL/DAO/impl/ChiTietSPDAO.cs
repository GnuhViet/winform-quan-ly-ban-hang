using BTLCSDL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSDL.DAO.impl {
	internal class ChiTietSPDAO : ReflectionDAO {
		public ChiTietSPDAO() : base(typeof(ChiTietSP)) {
		} 

		public Dictionary<String, List<ChiTietSP>> getMapAllWithMaSPKey() {
			Dictionary<String, List<ChiTietSP>> res = new Dictionary<String, List<ChiTietSP>>();	
			DataTable dt = table("select MaSP from SanPham");	
			foreach(DataRow dr in dt.Rows) {
				String MaSP = dr["MaSP"].ToString();
				List<object> list = getListByField("MaSP", MaSP);
				res.Add(MaSP, list.Select(s => (ChiTietSP)s).ToList());
			}
			return res;
		}

		public int getMaCTSP(int MaSP, int MaS, int MaMS) {
			int r = -1;
			DataTable dt = table($"select MaCTSP from ChiTietSP where MaSP = {MaSP} and MaS = {MaS} and MaMS = {MaMS}");
			if (dt.Rows.Count > 0) {
				r = Convert.ToInt32(dt.Rows[0][0]);
			}
			return r;
		}

		public DataTable getWithSizeMauSanPham(int MaHDB) {
			return table("select SP.DonGiaBan, CTH.SoLuong, SP.TenSP, SP.MaSP, " +
				"CONCAT(S.MaS,' - ',TenS) as [Size], CONCAT(MS.MaMS,' - ',TenMS) as [MauSac], " +
				"GioiTinh, TenTL, TenCL, TenQG " +
				"from ChiTietSP " +
				"join SanPham SP on ChiTietSP.MaSP = SP.MaSP " +
				"join Size S on ChiTietSP.MaS = S.MaS " +
				"join MauSac MS on ChiTietSP.MaMS = MS.MaMS " +
				"join ChatLieu CL on SP.MaCL = CL.MaCL " +
				"join TheLoai TL on SP.MaTL = TL.MaTL " +
				"join QuocGia QG on SP.MaQG = QG.MaQG " +
				"join ChiTietHDB CTH on ChiTietSP.MaCTSP = CTH.MaCTSP " +
				"join HoaDonBan HDB on CTH.MaHDB = HDB.MaHDB " +
				"where HDB.MaHDB = " + MaHDB);
		}
	}
}
