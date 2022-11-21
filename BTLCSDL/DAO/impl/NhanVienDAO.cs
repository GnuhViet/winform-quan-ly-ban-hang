using BTLCSDL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTLCSDL.DAO.impl {
	internal class NhanVienDAO : ReflectionDAO {
		public NhanVienDAO() : base(typeof(NhanVien)) {
		}

		public DataTable getWithFillter(String MaCV, String GioiTinh, String fieldName, String fieldValue) {
			StringBuilder query = new StringBuilder("select * from NhanVien ");

			List<String> whereClause = new List<string>();

			if (MaCV != "") { 
				whereClause.Add($"MaCV = {MaCV} "); 
			}

			if (GioiTinh != "") {
				whereClause.Add($"GioiTinh = N'{GioiTinh}' ");
			}
			
			if (fieldValue != "") {
				if (fieldName.Equals("MaNV")) {
					whereClause.Add($"{fieldName} = {fieldValue}");
				} else {
					whereClause.Add($"{fieldName} like N'{fieldValue}%'");
				}
			}

			if(whereClause.Count > 0) {
				query.Append("where ");
			}

			bool c = false;
			foreach(String s in whereClause) {
				query.Append(s);
				query.Append("and ");
				c = true;
			}
			// Xoa end cuoi
			if (c) {
				query.Length -= 4;
			}
							
			return table(query.ToString());
		}
	}
}
