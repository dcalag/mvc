using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace mvc.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var mvcName = typeof(Controller).Assembly.GetName();
			var isMono = Type.GetType("Mono.Runtime") != null;

			ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData["Runtime"] = isMono ? "Mono" : ".NET";

			var dao = new PersonaDao();
			var persona = dao.Recuperar(1);

			return View("IndexPersona", persona);
		}

		public ActionResult Process(Persona persona)
		{
			persona.Mensaje = "Datos seleccionados: " + 
				persona.Nombre + " - " +
				persona.Edad + " - " +
				persona.SelectedSex + " - " +
				persona.Casado;
			return View("Persona", persona);
		}
	}
}

