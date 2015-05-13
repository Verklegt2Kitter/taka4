using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace taka3.Models
{
    public class FriendModel
    {
        public int Id { get; set; }

        public string FollowingUserId { get; set; }

        public bool isFollowing { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}