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
<<<<<<< HEAD
    public class FriendController: Controller
=======
    public class FriendController : Controller
>>>>>>> 1db080c79d5b0c1db6656f57631127e9e8094492
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        FollowingService fservice = new FollowingService();

        public ActionResult Index()
        {
            return View(fservice.GetAllFriendList().ToList());
        }

        [HttpPost]
<<<<<<< HEAD
        public ActionResult FollowUser(string userID)
        {
            string currUserId = User.Identity.GetUserId();
            var fService = new FollowingService(); // kannski þarf að senda inn db
            fService.AddFollowingToUser(currUserId, userID);
=======
        [ValidateAntiForgeryToken]
        public ActionResult FollowUser(string userId)
        {
            string currUserId = User.Identity.GetUserId();
            var fService = new FollowingService();
            fService.AddFollowingToUser(currUserId, userId);
>>>>>>> 1db080c79d5b0c1db6656f57631127e9e8094492
            return View(); //TODO: Fix return statement

        }

        // GET: friends/Details/5
        public ActionResult Details(int? id)
        {
            FriendModel friendModel = db.FriendModel.Find(id);
            if (friendModel == null)
            {
                return HttpNotFound();
            }
            return View(friendModel);
        }

        [Authorize]
        public ActionResult GetUserFriends()
        {
            var userid = User.Identity.GetUserId();

            var model = fservice.GetUserFriendInfoById(userid);

            return View(model);
        }

    }
}