﻿using System;
using System.Configuration;
using FirebirdSql.Data.FirebirdClient;
using System.Collections.Generic;

namespace mvc
{
	public class PersonaDao : BaseDao
	{
		public PersonaDao()
		{
		}		

		public List<Persona> RecuperarTodos()
		{
			FbConnection connection = new FbConnection(ConnectionString());
			FbTransaction transaction = null;
			var lista = new List<Persona>();

			try
			{
				connection.Open();
				transaction = connection.BeginTransaction(System.Data.IsolationLevel.Snapshot);

				FbCommand command = new FbCommand();
				Persona persona;

				command.CommandText =
					"SELECT ID, NOMBRE, EDAD FROM PERSONAS";
				command.Connection = connection;
				command.Transaction = transaction;

				// Execute Update
				FbDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					persona = new Persona();
					persona.Id = reader.GetInt64(0);
					persona.Nombre = reader.GetString(1);
					persona.Edad = reader.GetString(2);
					lista.Add(persona);
				}

				transaction.Commit();
				connection.Close();

				return lista;
			}
			catch
			{
				if (transaction != null)
					transaction.Rollback();				
				connection.Close();
				throw;
			}
		}

		public void Guardar(Persona APersona)
		{
			FbConnection connection = new FbConnection(ConnectionString());
			FbTransaction transaction = null;

			try
			{
				connection.Open();
				transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				FbCommand command = new FbCommand();

				if (APersona.Id == 0)
				{
					command.CommandText =
						       "INSERT INTO PERSONAS (NOMBRE, EDAD, SEXO, CASADO) " +
						       "VALUES (@NOMBRE, @EDAD, @SEXO, @CASADO) ";
					command.Connection = connection;
					command.Transaction = transaction;

					command.Parameters.Add("@NOMBRE", FbDbType.VarChar);
					command.Parameters.Add("@EDAD", FbDbType.VarChar);
					command.Parameters.Add("@SEXO", FbDbType.VarChar);
					command.Parameters.Add("@CASADO", FbDbType.Integer);

					command.Parameters[0].Value = APersona.Nombre;
					command.Parameters[1].Value = APersona.Edad;
					command.Parameters[2].Value = APersona.SelectedSex;
					if (APersona.Casado)
						command.Parameters[3].Value = 1;
					else
						command.Parameters[3].Value = 0;					

					command.ExecuteNonQuery();
				}
				else
				{ 
					command.CommandText =
						"UPDATE PERSONAS SET NOMBRE=@NOMBRE, EDAD=@EDAD, SEXO=@SEXO, CASADO=@CASADO WHERE ID = @ID";
					command.Connection = connection;
					command.Transaction = transaction;

					command.Parameters.Add("@NOMBRE", FbDbType.VarChar);
					command.Parameters.Add("@EDAD", FbDbType.VarChar);
					command.Parameters.Add("@SEXO", FbDbType.VarChar);
					command.Parameters.Add("@CASADO", FbDbType.Integer);
					command.Parameters.Add("@ID", FbDbType.Integer);

					command.Parameters[0].Value = APersona.Nombre;
					command.Parameters[1].Value = APersona.Edad;
					command.Parameters[2].Value = APersona.SelectedSex;
					if (APersona.Casado)
						command.Parameters[3].Value = 1;
					else
						command.Parameters[3].Value = 0;
					command.Parameters[4].Value = APersona.Id;

					command.ExecuteNonQuery();
				}

				transaction.Commit();
				connection.Close();
			}
			catch
			{
				if (transaction != null)
					transaction.Rollback();
				connection.Close();
				throw;
			}
		}

		public void Eliminar(Int64 AId)
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
					"DELETE FROM PERSONAS WHERE ID = @ID";
				command.Connection = connection;
				command.Transaction = transaction;

				command.Parameters.Add("ID", AId);

				// Execute Update
				command.ExecuteNonQuery();

				transaction.Commit();
				connection.Close();
			}
			catch
			{
				if (transaction != null)
					transaction.Rollback();
				connection.Close();
				throw;
			}
		}

		public Persona Recuperar(Int64 AId)
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
					"SELECT NOMBRE, EDAD, SEXO, CASADO FROM PERSONAS WHERE ID = @ID";
				command.Connection = connection;
				command.Transaction = transaction;

				command.Parameters.Add("ID", AId);

				// Execute Update
				FbDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					persona.Nombre = reader.GetString(0);
					persona.Edad = reader.GetString(1);
					persona.SelectedSex = reader.GetString(2);
					persona.Casado = false;
					if (reader.GetInt32(3) == 1)
						persona.Casado = true;
					persona.Id = AId;
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

