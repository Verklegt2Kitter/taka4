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

        public GroupModel GetGroupById(int id)
        {
            var result = (from tempitem in m_db.Group
                         where tempitem.GroupID == id
                         select tempitem).SingleOrDefault();
            return result;
        }

        public IEnumerable<GroupModel> GetGroupsForUser(string userid)
        {
            var result = from item in m_db.GroupUser
                         where item.UserId == userid
                         select item;

            var model = new List<GroupModel>();

            foreach (var item in result)
            {
                var temp = GetGroupById(item.GroupId);
                if(temp != null)
                {
                    model.Add(temp);
                }
            }

            return model;
        }

        /*internal static void AddGroupModel(GroupModel m)
        {
            throw new NotImplementedException();
        }*/

    }
}