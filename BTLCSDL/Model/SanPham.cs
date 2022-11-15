using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSDL.Model {
	internal class SanPham {
		public int MaSP { get; set; }
		public String TenSP { get; set; }
		public double DonGiaBan { get; set; }
		public double DonGiaNhap { get; set; }
		public String GioiTinh { get; set; }
		public String Anh { get; set; }
		public int MaTL { get; set; }
		public int MaCL { get; set; }
		public int MaQG { get; set; }
	}
}
