using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace taka3.Models
{
   //fanney, hópur 11/5/2015
   public class GroupModel

    {
       [Key]
        public int GroupID { get; set; }

        public string GroupName { get; set; }
        public string UserName { get; set; }
    }
}