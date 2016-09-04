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
			ListaPersonas lista = new ListaPersonas ();;

			var dao = new PersonaDao();
			try{
				lista.Lista = dao.RecuperarTodos();
			}
			catch (Exception e) {
				lista.Mensaje = "Error: " + e.Message;
			}

			return View("Personas", lista);

			/*
			Persona persona = null;

			var dao = new PersonaDao();
			try{
				persona = dao.Recuperar(1);
			}
			catch (Exception e) {
				persona = new Persona ();
				persona.Mensaje = "Error: " + e.Message;
			}

			return View("IndexPersona", persona);
			*/
		}

		public ActionResult IndexPersona(Int64 id)
		{
			Persona persona = null;

			var dao = new PersonaDao();
			try{
				persona = dao.Recuperar(id);
			}
			catch (Exception e) {
				persona = new Persona ();
				persona.Mensaje = "Error: " + e.Message;
			}

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

