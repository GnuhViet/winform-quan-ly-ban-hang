using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSDL.Model {
	internal class HoaDonNhap {
		public int MaHDN { get; set; }
		public DateTime NgayNhap { get; set; }
		public String MaSoThue { get; set; }
		public double TongTien { get; set; }
		public int MaNCC { get; set; }
		public int MaNV { get; set; }
	}
}
