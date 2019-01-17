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

        //Use this to see if a user exists
        //If exists, return user
        //Else, return null
        private User Find(int id)
        {
            User user = null; //CHANGE BEFORE DONE

            /* ADD HERE */

            return user;
        }
    }
}
