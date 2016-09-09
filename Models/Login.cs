using System;
namespace mvc
{
	public class Login : BaseModel
	{
		public string Usuario { get; set; }

		public string Password { get; set; }

		public Login()
		{
			Usuario = "";
			Password = "";
		}
	}
}

