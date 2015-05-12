using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using taka3.Models;
using taka3.Services;
using SecurityWebAppTest.Models;
using System.Web.Security;

namespace taka3.Controllers
{
    public class HomeController : Controller
    {
		UserService userService = new UserService();

        public ActionResult Index()
        {

			IdentityManager manager = new IdentityManager();

			//Búa til nýjan user ef það er enginn til með UserName username	-Védís
			var passwordHash = new PasswordHasher();
			string password = passwordHash.HashPassword("Password@123");
			var user = new ApplicationUser
			{
				UserName = "SarahPalin",
				Email = "sarah@palin.com",
				PasswordHash = password,
				FirstName = "Sarah",
				LastName = "Palin",
				Country = "USA",
				BirthDate = DateTime.Parse("1948-02-05 17:30:00"),
				Gender = "female",
				LockoutEnabled = true
			};

			var temp = manager.GetUser("SarahPalin");
			if(temp == null)
			{
				manager.CreateUser(user, password);
			}



			//Sendir á Fréttaveituna(NewsFeed) ef notandi er skráður inn	-Védís
			if (Request.IsAuthenticated)
			{
				return View("NewsFeed");
			}
			else
			{
				return View();
			}
        }

		//steindor gerði fall sem sækir myndir
		public ActionResult FileUpload(HttpPostedFileBase file, int? postid, string postBody)
		{
			string postbody = postBody;
			string photo = null;

			if (file != null)
			{
				string pic = System.IO.Path.GetFileName(file.FileName);
				string path = System.IO.Path.Combine(
									   Server.MapPath("~/Content/images"), pic);
				// file is uploaded
				file.SaveAs(path);

				// save the image path path to the database or you can send image
				// directly to database
				// in-case if you want to store byte[] ie. for DB
				/*using (MemoryStream ms = new MemoryStream())
				{
					file.InputStream.CopyTo(ms);
					byte[] array = ms.GetBuffer();
				}*/

				photo = path;

			}

			UserPost model = new UserPost();
			model.UserID = User.Identity.GetUserId();
			model.Image = photo;
			model.PostBody = postbody;
			model.DateAndTime = DateTime.Now;

			userService.AddPosts(model);
			// after successfully uploading redirect the user
			return RedirectToAction("ProfilePage", "Home");
		}

        public ActionResult Groups()
        {
            ViewBag.Message = "Your application groups page.";

            return View();
        }

		public ActionResult NewsFeed()
		{
			return View();
		}

		public ActionResult ProfilePage()
		{
			ViewBag.Message = "Your newsfeed.";

			IdentityManager manager = new IdentityManager();

			var userid = User.Identity.GetUserName();

			var user = manager.GetUser(userid);

			//var firstname = user.FirstName;

			return View("ProfilePage", user); //Skilar firstname þess notanda sem er innskráður	-Védís
		}

		public ActionResult Hamburger()
		{
			ViewBag.Message = "Your settings page.";

			return View();
		}

       //fanney gerði heimasíðu hópa
       public ActionResult GroupProfilePage()
        {
            ViewBag.Message = "Group homepage.";

          //  ApplicationDbContext db = new ApplicationDbContext();

            //1. hvaða hópur --- Fanney, úr fyrirlestri Dabs

            // 2. sækja hópmeðlimi
            /*  var groupMembers = new List<string>();


               var statuses = (from s in db.GroupPosts
                               where groupMembers.Contains(s.UserName)
                               select s).ToList();*/
            return View();
        }
        //fanney, reynir að útfæra leitarbox
      // public static MembershipUserCollection FindUserByName(
         //  string userNameToMatch
          // );

    }
}