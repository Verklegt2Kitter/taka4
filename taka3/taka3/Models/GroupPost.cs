using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taka3.Models
{
   //public class GroupStatus //láta erfa status
   public class GroupPost

    {
        // Klasi sem pósta textastöðu á hópasíðu ---- Fanney
        public int ID { get; set; }
        public string Body { get; set; }
        public System.DateTime DateInserted { get; set; }
        public string GroupName { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public object UserName { get; set; }
    }
}