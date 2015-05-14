using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using taka3.Models;
using System.Web.Security;


namespace taka3.Services
{
    public class UserPostService
    {
		ApplicationDbContext m_db = new ApplicationDbContext();

		// Sjabbalabbadingdong?
        public List<ApplicationUser> GetAllUsers()
        {
            return m_db.Users.ToList();
        }

		// ???? Hver setti þetta inn?
		public ApplicationUser GetThisUserById(string userId)
		{
			var thisUser = (from u in GetAllUsers()
							where u.Id == userId
							select u).SingleOrDefault();
			return thisUser;

		}

		//Skilar username útfrá userid sem er sent inn	-Védís
		public string GetUserNameById(string userId)
		{
			var result = (from user in m_db.Users
						  where user.Id == userId
						  select user.UserName).SingleOrDefault();
			return result;
		}

		//Bætir við og vista pósta í gagnagrunn
		public void AddPosts(UserPost post)
		{	
			if(post != null)
			{
				m_db.UserPosts.Add(post);
				m_db.SaveChanges();
			}
		}
		
		//Nær í alla pósta sem eru með ákveðið userid	-Védís 
		public IEnumerable<UserPost> GetPostsByUserId(string userid)
		{
			var result = from item in m_db.UserPosts
						 where item.UserID == userid
						 orderby item.DateAndTime descending
						 select item;
			return result;
		}

		//Nær í Alla pósta sem eru með ákveðið Groupid	-Védís
		public IEnumerable<UserPost> GetPostsByGroupId(int groupid)
		{
			var result = from item in m_db.UserPosts
						 where item.GroupID == groupid
						 select item;
			return result;
		}

		//Nær í 20 nýjustu pósta sem hafa verið settir inná síðuna	-Védís
		public IEnumerable<UserPost> GetAllUserPosts()
		{
			var result = (from item in m_db.UserPosts
						  orderby item.DateAndTime descending
						  select item).Take(20);
			return result;
		}

		//Nær í userid fyrir ákveðinn póst af 20 nýjustu póstunum	-Védís
		public string GetUserId(int postid)
		{
			var result = (from item in GetAllUserPosts()
						  where item.ID == postid
						  select item.UserID).SingleOrDefault();
			return result;
		}
    
    }
}