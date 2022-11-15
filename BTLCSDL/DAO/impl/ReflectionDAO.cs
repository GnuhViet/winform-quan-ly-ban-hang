using BTLCSDL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLCSDL.DAO.impl {
	public class ReflectionDAO : CommonDAO {
		private Type type;
		private String className;
		private String modelID;

		private PropertyInfo[] properties;

		private String insertQuery;
		private String selectQuery;
		private String updateQuery;
		private String deleteQuery;

		public ReflectionDAO(Type type) {
			this.type = type;
			className = type.Name;
			String classShortName = string.Concat(Regex.Matches(className, "[A-Z]").OfType<Match>().Select(match => match.Value));
			modelID = "Ma" + classShortName;

			properties = type.GetProperties();
			constructQuery();
		}

		private void constructQuery() {
			constructInsertQuery();
			constructUpdateQuery();
			constructDeletQuery();
			constructSelectQuery();
		}

		private void constructInsertQuery() {
			StringBuilder sb = new StringBuilder("insert into " + className + "(");
			// doc cac fied name de them vao cau insert
			foreach (PropertyInfo property in properties) {
				// Khoa cua model thi khong insert
				if (property.Name.Equals(modelID)) {
					continue;
				}
				sb.Append(property.Name + ",");
			}
			// xoa ky tu , cuoi, thay = ") "
			sb.Length -= 1; sb.Append(") values($)");
			insertQuery = sb.ToString();
		}

		private void constructUpdateQuery() {
			updateQuery = "update " + className + " set $ where " + modelID + " = #";
		}

		private void constructDeletQuery() {
			deleteQuery = "delete from " + className + " where " + modelID + " = #";
		}

		private void constructSelectQuery() {
			selectQuery = "select * from " + className + " where " + modelID + " = #";
		}

		public String mapping(PropertyInfo prop, Object model) {
			if (prop.GetValue(model) == null) {
				return "NULL";
			}
			else if (prop.PropertyType == typeof(string) || prop.PropertyType == typeof(String)) {
				return "N'" + prop.GetValue(model).ToString() + "'";
			} 
			else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(double)) {
				if (prop.Name.StartsWith("Ma") && !prop.Name.StartsWith(modelID) && (int)prop.GetValue(model) == 0) { // chi khoa ngoai, khong phai ID
					return "NULL";
				}
				return prop.GetValue(model).ToString();
			} 
			else if(prop.PropertyType == typeof(DateTime)) {
				return "'" + ((DateTime)prop.GetValue(model)).ToString("yyyy-MM-dd") + "'";
			}
			else {
				return null;
			}
		}

		// main

		public int create(Object model) {
			// add value
			StringBuilder sb = new StringBuilder("");
			foreach(var prop in properties) {
				if (prop.Name.Equals(modelID)) {
					continue;
				}
				sb.Append(mapping(prop, model) + ",");
			}
			// xoa ky tu , o cuoi
			sb.Length -= 1;

			// common
			String query = insertQuery.Replace("$", sb.ToString());
			try {
				int id = ExecuteScalar(query);
				MessageBox.Show("Thêm mới thành công");
				return id;
			} catch (Exception ex) {
				MessageBox.Show("Loi: " + ex.Message);
				return -1;
			}
		}

		public Object read(int id) {
			throw new NotImplementedException();
		}

		public void update(Object model) {
			// add value
			String id = "NULL";
			StringBuilder sb = new StringBuilder("");
			foreach (var prop in properties) {
				if (prop.Name.Equals(modelID)) {
					id = prop.GetValue(model).ToString(); // luu lai id
					continue;
				}
				sb.Append(prop.Name + "=" + mapping(prop, model) + ",");
			}
			// xoa ky tu , o cuoi
			sb.Length -= 1;

			// common
			String query = updateQuery.Replace("$", sb.ToString()).Replace("#", id);
			
			try {
				Execute(query);
				MessageBox.Show("Update thành công");
			} catch (Exception ex) {
				MessageBox.Show("Lỗi: " + ex.Message);
			}
		}

		public void delelte(Object model) {
			String id = "-1";
			foreach (var prop in properties) {
				if (prop.Name.Equals(modelID)) {
					id = prop.GetValue(model).ToString(); // luu lai id
					break;
				}
			}

			// common
			String query = deleteQuery.Replace("#", id);
			try {
				Execute(query);
			} catch (Exception ex) {
				MessageBox.Show("Loi: " + ex.Message);
			}
		}

		// get data func

		public Object setMapping(DataRow row) {
			Object model = Activator.CreateInstance(type);
			foreach (var prop in properties) {
				if (prop.PropertyType == typeof(string) || prop.PropertyType == typeof(String)) {
					string value = row[prop.Name].ToString();
					prop.SetValue(model, value);
				} 
				else if (prop.PropertyType == typeof(int)) {
					int value = Convert.ToInt32(row[prop.Name].ToString());
					prop.SetValue(model, value);
				} 
				else if (prop.PropertyType == typeof(double)) {
					double value = Convert.ToDouble(row[prop.Name].ToString());
					prop.SetValue(model, value);
				} 
				else if (prop.PropertyType == typeof(DateTime)) {
					DateTime value = Convert.ToDateTime(row[prop.Name].ToString());
					prop.SetValue(model, value);
				}
			}
			return model;
		}

		public List<Object> getListAll() {
			List<Object> list = new List<Object>();
			DataTable dt = getAll();
			for (int i = 0; i < dt.Rows.Count; i++) {
				list.Add(setMapping(dt.Rows[i]));
			}
			return list;
		}

		public List<Object> getListByField(String fieldName, String value) {
			List<Object> list = new List<Object>();
			DataTable dt = table("select * from " + className + " where " + fieldName + " = " + value);
			for (int i = 0; i < dt.Rows.Count; i++) {
				list.Add(setMapping(dt.Rows[i]));
			}
			return list;
		}

		public DataTable GetDataTableByField(String fieldName, String value) {
			return table("select * from " + className + " where " + fieldName + " = " + value);
		}

		public DataTable getAll() {
			return table("select * from " + className);
		}

		public DataTable search(String searchFieldName, String searchValue) {
			return table($"select * from {className} where {searchFieldName} like N'" + searchValue + "%'");
		}
	}
}
