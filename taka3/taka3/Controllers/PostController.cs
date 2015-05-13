using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using taka3.Models;
using taka3.Services;
using Microsoft.AspNet.Identity;

namespace taka3.Controllers
{
	//Controller sem tekur á móti póstum frá notendum (myndum/statusum)	-Védís
	//TODO BÆTA VIÐ AÐ HÆGT SÉ AÐ ADDA GROUPID	-Védís
    public class PostController : Controller
    {
		UserPostService userService = new UserPostService();

	   //steindor gerði fall sem sækir myndir
	   public ActionResult FileUpload(HttpPostedFileBase file, int? postid, string postBody)
	   {
		   string postbody = postBody;
		   string photo = null; //Bætti við svo hægt að seiva mynd í gagnagrunn	-Védís
		   string photonameshort = null;

		   if (file != null)
		   {
			   string pic = System.IO.Path.GetFileName(file.FileName);
			   string path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), pic);
			   // file is uploaded
			   file.SaveAs(path);
			   photo = path;
			   photonameshort = pic;
		   }

		   UserPost model = new UserPost();
		   model.UserID = User.Identity.GetUserId();
		   model.Image = photo;
		   model.ImageName = photonameshort;
		   model.PostBody = postbody;
		   model.DateAndTime = DateTime.Now;

		   userService.AddPosts(model);

		   //Redirectar aftur á newsfeedið
           return RedirectToAction("NewsFeed", "Home");
	   }
	}
}

