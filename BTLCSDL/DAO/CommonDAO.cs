using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace BTLCSDL.DAO {
	public class CommonDAO {
		protected SqlDataAdapter sqlDataAdapter;
		protected SqlCommand sqlCommand;
		protected SQLServerConnection connection = null;

		public CommonDAO() {
			connection = new SQLServerConnection();
		}

		public DataTable table(string query) {
			DataTable dataTable = new DataTable();
			SqlConnection con = connection.getConnection();

			con.Open();
			sqlDataAdapter = new SqlDataAdapter(query, con);
			sqlDataAdapter.Fill(dataTable);
			con.Close();

			return dataTable;
		}

		public void Execute(string query) {
			SqlConnection con = connection.getConnection();
			con.Open();
			sqlCommand = new SqlCommand(query, con);
			sqlCommand.ExecuteNonQuery();
			con.Close();
		}

		public int ExecuteScalar(string query) {
			SqlConnection con = connection.getConnection();
			query += "; SELECT SCOPE_IDENTITY();";
			SqlCommand cmd = new SqlCommand(query, con);

			con.Open();
			int modified = Convert.ToInt32(cmd.ExecuteScalar());
			con.Close();
			return modified;
		}
	}
}
