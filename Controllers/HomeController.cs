using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;

namespace mvc.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Inicio()
		{
			return View("Inicio");
		}

		public ActionResult Personas()
		{
			ListaPersonas lista = new ListaPersonas(); ;

			var dao = new PersonaDao();
			try
			{
				lista.Lista = dao.RecuperarTodos();
			}
			catch (Exception e)
			{
				lista.Mensaje = "Error: " + e.Message;
			}

			return View("Personas", lista);
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

		public ActionResult ProcessPersona(Persona persona)
		{
			var personaDao = new PersonaDao();
			try
			{
				personaDao.Guardar(persona);
				persona.Mensaje = "Elemento guardado correctamente.";
			}
			catch (Exception e)
			{
				persona.Mensaje = e.Message;
			}

			return View("Persona", persona);
		}

		public ActionResult ProcessLogin(Login login)
		{
			login.Mensaje = "Login ok!";

			FormsAuthentication.SetAuthCookie(login.Usuario, false);

			return View("Login", login);
		}

		public ActionResult Login()
		{
			return View("IndexLogin", new Login());
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();

			return View("Inicio");
		}
	}
}

