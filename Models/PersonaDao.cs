using System;
using System.Configuration;
using FirebirdSql.Data.FirebirdClient;

namespace mvc
{
	public class PersonaDao : BaseDao
	{
		public PersonaDao()
		{
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
			catch
			{
				if (transaction != null)
					transaction.Rollback();				
				connection.Close();
				throw;
			}
		}
	}
}

