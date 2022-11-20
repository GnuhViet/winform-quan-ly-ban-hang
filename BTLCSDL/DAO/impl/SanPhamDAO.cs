using BTLCSDL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLCSDL.DAO.impl {
	internal class SanPhamDAO : ReflectionDAO {
		public SanPhamDAO(Type type) : base(type) {
		}

		public DataTable getWithMa(Dictionary<Type, List<String>> fillter) {
			StringBuilder whereClause = new StringBuilder();

			foreach (KeyValuePair<Type, List<String>> item in fillter) {
				String classShortName = string.Concat(Regex.Matches(((Type)item.Key).Name, "[A-Z]").OfType<Match>().Select(match => match.Value));
				String id = "Ma" + classShortName;

				if (((List<String>)item.Value).Count > 0) {
					foreach (String listValue in item.Value) {
						whereClause.Append(id + " = " + listValue + " or ");
					}
					// xoa chu "or "
					whereClause.Length -= 3;
					// thay = "and "
					whereClause.Append("and ");
				}
			}
			// xoa "and " o cuoi
			whereClause.Length -= 4;
			String query = "select DISTINCT SanPham.* from SanPham " +
							"join ChiTietSP on SanPham.MaSP = ChiTietSP.MaSP " +
							"where " + whereClause.ToString();
			return table(query);
		}

		public DataTable getAllWithChiTiet() {
			return table("select SanPham.*, MaMS, MaS, SoLuong");
		}
	}
}
