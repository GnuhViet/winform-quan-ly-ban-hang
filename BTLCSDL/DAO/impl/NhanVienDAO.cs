using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTLCSDL.DAO.impl {
	internal class NhanVienDAO : ReflectionDAO {
		public NhanVienDAO(Type type) : base(type) {
		}

		public DataTable getWithFillter(String MaCV, String GioiTinh, String fieldName, String fieldValue) {
			String query = "select * from NhanVien where ";

			if (MaCV != "") {
				query += $"MaCV = {MaCV} and ";
			}

			if (GioiTinh != "") {
				query += $"GioiTinh = N'{GioiTinh}' and ";
			}

			if (fieldName.Equals("MaNV")) {
				query += $"{fieldName} = {fieldValue}";
			} else {
				query += $"{fieldName} like N'{fieldValue}%'";
			}
							
			return table(query);
		}
	}
}
