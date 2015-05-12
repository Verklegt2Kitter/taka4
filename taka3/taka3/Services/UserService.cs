using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using taka3.Models;
using System.Web.Security;


namespace taka3.Services
{
    public class UserService
    {
		ApplicationDbContext m_db = new ApplicationDbContext();

		public void AddPosts(UserPost post)
		{
			
			if(post != null)
			{
				m_db.UserPosts.Add(post);
				m_db.SaveChanges();
			}
		}

		public IEnumerable<UserPost> GetPostsByUserId(string userid)
		{
			var result = from item in m_db.UserPosts
						 where item.UserID == userid
						 select item;
			return result;
		}

		public IEnumerable<UserPost> GetPostsByGroupId(int groupid)
		{
			var result = from item in m_db.UserPosts
						 where item.GroupID == groupid
						 select item;
			return result;
		}

    
    }
}