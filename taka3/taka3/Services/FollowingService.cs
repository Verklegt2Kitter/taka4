using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using taka3.Models;
using System.Web.Security;


namespace taka3.Services
{
    public class FollowingService
    {
        ApplicationDbContext m_db = new ApplicationDbContext();
        
        //fanney/steindór fengu hjálp og til varð follow stuff
        public List<FriendModel> GetAllFriendList()
        {
           return m_db.FriendModel.ToList();
        }
        
        public void AddFollowingToUser(string thisUser, string userToFollow)
        {
            var userService = new UserService();
            
            var followMe = new FriendModel();

            followMe.User = userService.GetThisUserById(thisUser); // Application user.
            followMe.FollowingUserId = userToFollow;
            followMe.isFollowing = true;

            m_db.FriendModel.Add(followMe);
            m_db.SaveChanges();
        }
        public List<FriendModel> MyFollowingList(string userId)
        {
            var userService = new UserService();

            var me = userService.GetThisUserById(userId);
            var returnMe = (from l in GetAllFriendList()
                            where l.User == me
                            select l).ToList();
            return returnMe;
        }
        public FriendModel GetUserFriendInfoById(int id)
        {
            var list = GetAllFriendList();
            var thisUser = (from u in list
                             where u.Id == id
                              select u).SingleOrDefault();

            return thisUser;
        }
        public void UnFollwUser(string userId, string stopFollowId)
        {
            var list = MyFollowingList(userId);
            var stopFollow = (from f in list
                              where f.FollowingUserId == stopFollowId
                              select f).SingleOrDefault();

            var unfollow = GetUserFriendInfoById(stopFollow.Id);

           m_db.FriendModel.Remove(unfollow);


            m_db.SaveChanges();
        }

        internal object GetUserFriendInfoById(string userid)
        {
            throw new NotImplementedException();
        }
    }
}