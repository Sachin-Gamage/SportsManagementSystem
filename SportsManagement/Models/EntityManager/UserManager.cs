using SportsManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsManagement.Models.EntityManager
{
	public class UserManager
	{
		public login GetUser (UserLoginView userLogin)
		{
			using (sportsmanagementEntities sportsmanagementEntities = new sportsmanagementEntities())
			{
				login user = sportsmanagementEntities.logins.Where(a=> a.userEmail == userLogin.userEmail 
				&& a.userEmail == userLogin.userEmail).First();
				return user;
			}
		}
	}
}