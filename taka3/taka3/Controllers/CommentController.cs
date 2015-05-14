using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using taka3.Models;
using taka3.Services;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace taka3.Controllers
{
	//Fall sem tekur inn comment við pósta frá notanda.	-Védís
    public class CommentController : Controller
    {
		CommentService userService = new CommentService();

	    public ActionResult CommentUpload(string commentBody, int? commentid, int postid)
	    {
		    Comment model = new Comment();
		    
 		    model.DateAndTime = DateTime.Now;
		    model.CommentBody = commentBody;
		    model.UserID = User.Identity.GetUserId();
		    model.PhotoID = postid;

 	 	    userService.AddComment(model);

		    //Redirectar aftur á newsfeedið
            return RedirectToAction("NewsFeed", "Home");
	    }
	}
}