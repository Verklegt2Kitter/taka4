using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using taka3.Models;

namespace taka3.Services
{
	public class CommentService
	{
		ApplicationDbContext m_db = new ApplicationDbContext();

		public void AddComment(Comment post)
		{
			if (post != null)
			{
				m_db.Comments.Add(post);
				m_db.SaveChanges();
			}
		}
	}
}