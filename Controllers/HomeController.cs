using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using System.Configuration;

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

			if (id == 0)
				persona = new Persona();
			else
			{
				var dao = new PersonaDao();
				try
				{
					persona = dao.Recuperar(id);
				}
				catch (Exception e)
				{
					persona = new Persona();
					persona.Mensaje = "Error: " + e.Message;
				}
			}

			return View("IndexPersona", persona);
		}

		public ActionResult ProcessPersona(Persona persona)
		{
			if (persona.Eliminar > 0)
			{
				var personaDao = new PersonaDao();
				try
				{
					personaDao.Eliminar(persona.Id);
					persona = new Persona();
					persona.Mensaje = "Elemento eliminado correctamente";
					return View("Persona", persona);
				}
				catch (Exception e)
				{
					persona.Mensaje = e.Message;					
					return View("Persona", persona);
				}
			}
			else
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
		}


		public ActionResult ProcessLogin(Login login)
		{
			var adminUser = ConfigurationManager.AppSettings["AdminUser"];
			var adminPass = ConfigurationManager.AppSettings["AdminPass"];

			if (login.Usuario == adminUser && login.Password == adminPass)
			{
				FormsAuthentication.SetAuthCookie(login.Usuario, false);
				login.LoginOk = 1;
				return View("Login", login);
			}
				
			login.Mensaje = "Credenciales incorrectas.";
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

