using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taka3.Models
{
	public class ProfilePageViewModel
	{
        public string userID { get; set; }
		public List<UserPost> UserPosts { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }
	}
}

/*IdentityManager manager = new IdentityManager();

			var userid = User.Identity.GetUserName();

			var user = manager.GetUser(userid);

			//var firstname = user.FirstName;

			return View("ProfilePage", user); //Skilar firstname þess notanda sem er innskráður	-Védís*/