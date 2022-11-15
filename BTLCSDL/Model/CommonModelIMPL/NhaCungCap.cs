using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSDL.Model {
	internal class NhaCungCap : ICommonModel {
		public int MaNCC { get; set; }
		public String TenNCC { get; set; }
		public String DiaChi { get; set; }
		public String SoDT { get; set; }
		public String email { get; set; }
	}
}
