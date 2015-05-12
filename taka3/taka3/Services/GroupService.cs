using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using taka3.Models;

namespace taka3.Services
{
    public class GroupService
    {
        ApplicationDbContext m_db = new ApplicationDbContext();
        public void AddGroup(GroupModel m)
        {
            m_db.Group.Add(m);
            m_db.SaveChanges();
        }

        public IEnumerable<GroupModel> AllGroups()
        {
            return m_db.Group;
        }

        internal static void AddGroupModel(GroupModel m)
        {
            throw new NotImplementedException();
        }
    }
}