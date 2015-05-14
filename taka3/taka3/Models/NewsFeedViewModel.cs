using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taka3.Models
{
	public class NewsFeedViewModel
	{
		public List<UserPostViewModel> AllUserPosts { get; set; }
	}

	public class UserPostViewModel
	{
		ApplicationDbContext m_db = new ApplicationDbContext();

		public int ID { get; set; }
		public string UserID { get; set; }
		//public int GroupID { get; set; }
		public string PostBody { get; set; }
		public DateTime DateAndTime { get; set; }
		public string Image { get; set; }
		public string ImageName { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; } 
	}
}