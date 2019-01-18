using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain.Services
{
    public class Groups
    {
        private ApplicationDbContext DbContext { get; set; }

        public Groups(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void CreateGroup(string title)
        {
            DbContext.Groups.Add(new Group(title));
            DbContext.SaveChanges();
        }

        public void CreateGroup(Group group)
        {
            if (DbContext.Groups.Find(group.Id) == null)
                AddGroup(group);

            DbContext.SaveChanges();
        }

        public Group AddGroup(Group group)
        {
            DbContext.Groups.Add(group);
            DbContext.SaveChanges();
            return group;
        }

        public void Updategroup(Group group)
        {
            if (group.Id == default(int))
                AddGroup(group);

            else
                DbContext.Groups.Update(group);

            DbContext.SaveChanges();
        }

        public Group FindGroupById(int groupId)
        {
            return DbContext.Groups.Find(groupId);
        }

        public void RemoveUserFromGroup(User user, int groupId)
        {
            Group group = FindGroupById(groupId);
            UserGroup userGroup = DbContext.UserGroup.Find(user.Id, groupId);

            if (group != null)
            {
                if (!group.UserGroup.Contains(userGroup))
                {
                    user.UserGroup.Remove(userGroup);
                    group.UserGroup.Remove(userGroup);
                    DbContext.UserGroup.Remove(userGroup);
                }
                DbContext.Groups.Update(group);
            }
            DbContext.SaveChanges();
        }
 
        public void AddUserToGroup(User user, int groupId)
        {
            Group group = FindGroupById(groupId);
            UserGroup userGroup = DbContext.UserGroup.Find(user.Id, groupId);

            if (group != null)
            {
                if (!group.UserGroup.Contains(userGroup))
                {
                    user.UserGroup.Add(userGroup);
                    group.UserGroup.Add(userGroup);
                    DbContext.UserGroup.Add(userGroup);
                }
                DbContext.Groups.Update(group);
            }
            DbContext.SaveChanges();
        }
    }
}
