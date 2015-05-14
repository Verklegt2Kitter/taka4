using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taka3.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public String UserID { get; set; }
        public String CommentBody { get; set; }
        public DateTime DateAndTime { get; set; }
		public int PhotoID { get; set; }
    }
}