using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taka3.Models
{
	public class NewsFeedViewModel
	{
		public List<UserPost> AllUserPosts { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }
	}
}