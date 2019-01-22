using SecretSanta.Domain.Interfaces;
using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserGroup> UserGroup { get; set; }
        public ICollection<Gift> Gifts { get; set; }

        public User()
        {
            Gifts = new List<Gift>();
            UserGroup = new List<UserGroup>();
        }

        public override string ToString()
        {
            //Console.Write(String.Format("{0}, {1}", LastName, FirstName));
            return String.Format("{0}, {1}", LastName, FirstName);
        }

    }
}
