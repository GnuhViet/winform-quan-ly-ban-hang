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
	internal class SanPhamDAO : DynamicDAO {
		public SanPhamDAO() : base(typeof(SanPham)) {
		}

		public DataTable getWithMaAndSearchWithField(Dictionary<Type, List<String>> fillter, String fieldName, String fieldValue) {
			StringBuilder whereClause = new StringBuilder();

			String query = "select DISTINCT SanPham.* from SanPham " +
							"left join ChiTietSP on SanPham.MaSP = ChiTietSP.MaSP ";

			if (fieldName != "") {
				if (fieldName == "MaSP") {
					whereClause.Append($" SanPham.MaSP = {fieldValue} and ");
				} else {
					whereClause.Append($" {fieldName} like N'{fieldValue}%' and ");
				}
			}

			foreach (KeyValuePair<Type, List<String>> item in fillter) {
				String classShortName = string.Concat(Regex.Matches(((Type)item.Key).Name, "[A-Z]").OfType<Match>().Select(match => match.Value));
				String id = "Ma" + classShortName;

				int size = ((List<String>)item.Value).Count;
				if (size > 0) {
					/*
					select *
					from SanPham
					where MaSP in (select MaSP
								   from ChiTietSP
								   where MaS in (1, 10)
								   group by MaSP
								   having count(distinct MaS) = 2) 
					 */
					if (id == "MaS" || id == "MaMS") { // bang n-n
						StringBuilder subQuery = new StringBuilder($"select MaSP from ChiTietSP where {id} in (");
						foreach (String listValue in item.Value) {
							subQuery.Append(listValue + ",");
						}
						// xoa dau ",", thay = ")"
						subQuery.Length -= 1;
						subQuery.Append($") group by MaSP having count(distinct {id}) = {size}");
						whereClause.Append("SanPham.MaSP in (" + subQuery.ToString() + ") ");
						// thay = "and "
						whereClause.Append("and ");
					} 
					else { // bang 1-n
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
				}
			}

			if (whereClause.Length > 0) {
				// xoa chu end thua
				whereClause.Length -= 4;
				query += "where " + whereClause.ToString();
			}

			// phai loc xem thang nao phai thoa man du cac tieu chi la co nhieu size va co nhieu mau

			DataTable tb = new DataTable();

			return table(query);
		}

		public DataTable getAllWithChiTiet() {
			return table("select SanPham.*, MaMS, MaS, SoLuong");
		}
	}
}
