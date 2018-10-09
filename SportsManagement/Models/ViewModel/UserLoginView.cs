using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagement.Models.ViewModel
{
	public class UserLoginView
	{
		[Key]
		public int userId { get; set; }
		[Required(ErrorMessage ="*")]
		[Display(Name = "Email")]
		public string userEmail { get; set; }
		[Required(ErrorMessage ="*")]
		[Display(Name ="Password")]
		public string userPassword { get; set; }

	}
}