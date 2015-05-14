﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taka3.Models
{
	public class ProfilePageViewModel
	{
		public List<UserPost> UserPosts { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }
		public int PostID { get; set; }
	}
}