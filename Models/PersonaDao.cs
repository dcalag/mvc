using System;
using System.Configuration;
using FirebirdSql.Data.FirebirdClient;

namespace mvc
{
	public class PersonaDao
	{
		public PersonaDao()
		{
		}

		private string ConnectionString()
		{
			string connectionString =
				"User=" + ConfigurationManager.AppSettings["User"] + ";" +
				"Password=" + ConfigurationManager.AppSettings["Password"] + ";" +
				"Database=" + ConfigurationManager.AppSettings["Database"] + "; " +
				"DataSource=" + ConfigurationManager.AppSettings["Datasource"] + "; " +
				"Port=3050;" +
				"Dialect=3;" +
				"Charset=UTF8;" +
				"Role=;" +
				"Connection lifetime=15;" +
				"Pooling=true;" +
				"MinPoolSize=0;" +
				"MaxPoolSize=50;" +
				"Packet Size=8192;" +
				"ServerType=0";			
			return connectionString;
		}

		public Persona Recuperar(int AId)
		{
			FbConnection connection = new FbConnection(ConnectionString());
			FbTransaction transaction = null;
			var persona = new Persona();

			try
			{
				connection.Open();
				transaction = connection.BeginTransaction(System.Data.IsolationLevel.Snapshot);

				FbCommand command = new FbCommand();

				command.CommandText =
					"SELECT NOMBRE, EDAD FROM PERSONAS WHERE ID = @ID";
				command.Connection = connection;
				command.Transaction = transaction;

				command.Parameters.Add("ID", AId);

				// Execute Update
				FbDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					persona.Nombre = reader.GetString(0);
					persona.Edad = reader.GetString(1);
				}

				transaction.Commit();
				connection.Close();

				return persona;
			}
			catch (Exception e)
			{
				if (transaction != null)
					transaction.Rollback();				
				connection.Close();
				return persona;
			}
		}
	}
}

