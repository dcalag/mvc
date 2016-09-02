using System;
using System.Configuration;

namespace mvc
{
	public class BaseDao
	{
		public BaseDao ()
		{
		}

		protected string ConnectionString()
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
	}
}

