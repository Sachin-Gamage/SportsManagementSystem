using SportsManagement.Models;
using SportsManagement.Models.EntityManager;
using SportsManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SportsManagement.Controllers
{
    public class LoginController : Controller
    {
		private sportsmanagementEntities db = new sportsmanagementEntities();
		// GET: Login
		public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Login(UserLoginView userLogin)
		{
			if (ModelState.IsValid)
			{
				UserManager userManager = new UserManager();
				var user = userManager.GetUser(userLogin);
				if (user != null)
				{
					FormsAuthentication.SetAuthCookie(user.userEmail, false);
					Session["UserType"] = "2";
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Invalid Credentials");
				}
			}
			return View();
		}

		[HttpGet]
		public ActionResult Signout ()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Login", "Login");
		}
    }
}
