using System;
using System.Data;
using System.Collections;
using SerpisAd;

namespace PArticulo
{
	public class ArticuloPersister
	{



			public static Articulo load(object id) {
							IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
							dbCommand.CommandText = "select * from articulo where id = @id";
							DbCommandHelper.AddParameter (dbCommand, "id", id);
							IDataReader dataReader = dbCommand.ExecuteReader ();
							if (!dataReader.Read ())
								//TODO throw exception
								return artiuclo;
							Articulo.nombre = (string)dataReader ["nombre"];
							Articulo.categoria = dataReader ["categoria"];
							if (Articulo.categoria is DBNull)
								Articulo.categoria = null;
								Articulo.precio = (decimal)dataReader ["precio"];
								dataReader.Close ();
					}

		private static void insert() {
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "insert into articulo (nombre, categoria, precio) " +
				"values (@nombre, @categoria, @precio)";

			nombre = entryNombre.Text;
			categoria = ComboBoxHelper.GetId (comboBoxCategoria);
			precio = Convert.ToDecimal(spinButtonPrecio.Value);

			DbCommandHelper.AddParameter (dbCommand, "nombre", nombre);
			DbCommandHelper.AddParameter (dbCommand, "categoria", categoria);
			DbCommandHelper.AddParameter (dbCommand, "precio", precio);
			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}
















		}
	}


