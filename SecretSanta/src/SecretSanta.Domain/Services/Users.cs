using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

//NEED TO DO:
/*
 * Need to be able to add and update a user, not worried about deleting
 * ADD
 * UPDATE
 */

namespace SecretSanta.Domain.Services
{
    
    public class Users
    {
        private ApplicationDbContext DbContext { get; set; }

        public Users(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public User AddUser(User user)
        {
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
            return user;
        }

        public User GetUserById(int userId)
        {
            return DbContext.Users.Find(userId);
        }

        public User UpdateUser(User user)
        {
            DbContext.Users.Update(user);
            DbContext.SaveChanges();
            return user;
        }
    }
}
