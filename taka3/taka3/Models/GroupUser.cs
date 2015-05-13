using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taka3.Models
{
    public class GroupUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
    }
}