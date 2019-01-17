using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

//Need to be able to create a group and add/remove users from the group
/*
 * NEED TO:
 * CREATE GROUP
 * ADD USERS
 * REMOVE USERS
 */
namespace SecretSanta.Domain.Services
{
    public class Groups
    {
        private ApplicationDbContext DbContext { get; set; }

        public Groups(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void CreateGroup()
        {

        }

        public void AddUser(int userId)
        {

        }

        public void RemoveUser(int userId)
        {

        }

        public void AddUsers(List<User> Users)
        {

        }
    }
}
