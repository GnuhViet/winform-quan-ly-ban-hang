using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSDL.DAO {
	public class SQLServerConnection {
		private SqlConnection conn = null;

		String conS = @"Data Source=GNUH\SQLEXPRESS;Initial Catalog=QLBanGiay;Integrated Security=True";
		public SqlConnection getConnection() {
			if (conn != null) {
				return conn;
			}
			return new SqlConnection(conS);
		}
	}
}
