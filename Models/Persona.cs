using System;
using System.Collections.Generic;

namespace mvc
{
	public class Persona : BaseModel
	{
		public Int64 Id { get; set; }
		public string Nombre { get; set; }
		public string Edad { get; set; }
		public List<SelectItem> Sexo { get; set; }
		public string SelectedSex { get; set; }
		public bool Casado { get; set; }

		public Persona()
		{
			Id = 0;
			Mensaje = "";
			Nombre = "";
			Edad = "";
			SelectedSex = "M";
			Casado = false;
			Sexo = new List<SelectItem>();
			Sexo.Add(new SelectItem("M", "Masculino"));
			Sexo.Add(new SelectItem("F", "Femenino"));
		}
	}

	public class SelectItem
	{
		public string Value { get; set; }
		public string Text { get; set; }

		public SelectItem(string AValue, string AText)
		{
			Value = AValue;
			Text = AText;
		}
	}
}

