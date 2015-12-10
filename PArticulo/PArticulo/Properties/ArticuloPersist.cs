using System;
using SerpisAd;
using System.Data;
namespace PArticulo
{
	public class ArticuloPersister
	{

		
		

		public static Articulo Load(Object id){
			Articulo articulo = new Articulo();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "select * from articulo where id = @id";
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			if (!dataReader.Read ())
				//TODO throw exception
			articulo.Nombre = (string)dataReader ["nombre"];
			articulo.Categoria = dataReader ["categoria"];
			if (articulo.Categoria is DBNull)
				articulo.Categoria = null;
			articulo.Precio = (decimal)dataReader ["precio"];
			dataReader.Close ();
			return articulo;

		}

		public static void Insert (Articulo articulo){








	}




		public static void Update (Articulo articulo){






		}



}
}
