using System;
using System.Collections.Generic;

namespace mvc
{
	public class ListaPersonas : BaseModel
	{
		public List<Persona> Lista { get; set; }

		public ListaPersonas ()
		{
			Lista = new List<Persona> ();
		}
	}
}

