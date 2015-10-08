using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MySqlConnection mySqlConnection = new MySqlConnection (
				"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas"
			);
			mySqlConnection.Open ();

			updateDatabase (mySqlConnection);

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "select * from articulo";
//				"select " +
//				"a.categoria as articulocategoria, " +
//				"c.nombre as categorianombre, " +
//				"count(*) as numeroarticulos " +
//				"from articulo a " +
//				"left join categoria c " +
//				"on a.categoria = c.id " +
//				"group by articulocategoria, categorianombre";

			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();

			showColumnNames (mySqlDataReader);
			show (mySqlDataReader);

			mySqlDataReader.Close ();

			mySqlConnection.Close ();
		}

		private static void updateDatabase(MySqlConnection mySqlConnection) {
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "insert into articulo (nombre, categoria) values ('artículo nuevo', 1)";
			mySqlCommand.ExecuteNonQuery ();
		}

		private static void showColumnNames(MySqlDataReader mySqlDataReader) {
			Console.WriteLine ("showColumnNames...");
			string[] columnNames = getColumnNames (mySqlDataReader);
			Console.WriteLine (string.Join (", ", columnNames));

		}

		public static string[] getColumnNames(MySqlDataReader mySqlDataReader) {
//			int count = mySqlDataReader.FieldCount;
//			string[] columnNames = new string[count];
//			for (int index = 0; index < count; index++) 
//				columnNames [index] = mySqlDataReader.GetName (index);
//			return columnNames;

			int count = mySqlDataReader.FieldCount;
			List<string> columnNames = new List<string> ();
			for (int index = 0; index < count; index++)
				columnNames.Add (mySqlDataReader.GetName (index));
			return columnNames.ToArray();
		}

		private static void show(MySqlDataReader mySqlDataReader) {
			Console.WriteLine ("show...");
			while (mySqlDataReader.Read()) 
				showRow (mySqlDataReader);

		}

		private static void showRow(MySqlDataReader mySqlDataReader) {
			int count = mySqlDataReader.FieldCount;
			string line = "";
			for (int index = 0; index < count; index++)
				line = line + mySqlDataReader [index] + " ";

			Console.WriteLine (line);
		}
	}
}
