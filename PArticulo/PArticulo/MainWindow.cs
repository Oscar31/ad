using System;
using System.Collections.Generic;
using Gtk;
using MySql.Data.MySqlClient;
using System.Data;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		Console.WriteLine ("MainWindow ctor.");
		IDbConnection dbConnection = App.Instance.DbConnection; 


		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from articulo";

		IDataReader dataReader = dbCommand.ExecuteReader ();
//		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
//		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		string[] columnNames = getColumnNames (dataReader);
		for (int index = 0; index < columnNames.Length; index++)
			treeView.AppendColumn (columnNames [index], new CellRendererText (), "text", index);

		//ListStore listStore = new ListStore (typeof(String), typeof(String));
		Type[] types = getTypes (dataReader.FieldCount);
		ListStore listStore = new ListStore (types);

		while (dataReader.Read()) {
			//listStore.AppendValues (dataReader [0].ToString(), dataReader [1].ToString());
			string[] values = getValues (dataReader);
			listStore.AppendValues (values);
		}

		dataReader.Close ();

		treeView.Model = listStore;

		dbConnection.Close ();
	}

	private string[] getColumnNames(IDataReader dataReader) {
		List<string> columnNames = new List<string> ();
		int count = dataReader.FieldCount;
		for (int index = 0; index < count; index++)
			columnNames.Add (dataReader.GetName (index));
		return columnNames.ToArray ();
	}

	private Type[] getTypes(int count) {
		List<Type> types = new List<Type> ();
		for (int index = 0; index < count; index++)
			types.Add (typeof(string));
		return types.ToArray ();
	}

	private string[] getValues(IDataReader dataReader) {
		List<string> values = new List<string> ();
		int count = dataReader.FieldCount;
		for (int index = 0; index < count; index++)
			values.Add (dataReader [index].ToString ());
		return values.ToArray ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
