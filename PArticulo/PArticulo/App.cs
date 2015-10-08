using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PArticulo
{
	public class App
	{
		private static App instance = new App();
		public static App Instance {
			get { return instance;}
		}

		private App() {
		}

		private IDbConnection dbConnection;
		public IDbConnection DbConnection {
			get { 
				if (dbConnection == null) {
					dbConnection = new MySqlConnection (
						"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas"
						);
					dbConnection.Open ();
				}
				return dbConnection;
			}
		}

	}
}