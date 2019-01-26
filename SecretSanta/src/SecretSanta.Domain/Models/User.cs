using SecretSanta.Domain.Interfaces;
using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretSanta.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserGroup> UserGroup { get; set; }
        public ICollection<Gift> Gifts { get; set; }

        public User(string firstName, string lastName)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName), "FirstNameNull");
            if (lastName == null) throw new ArgumentNullException(nameof(lastName), "LastNameNull");

            FirstName = firstName;
            LastName = lastName;
        }

        public User()
        {
            Gifts = new List<Gift>();
            UserGroup = new List<UserGroup>();
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", LastName, FirstName);
        }

        public List<string> PrintWishList()
        {
            List<string> wishlistTitles = new List<string>();
            foreach (Gift g in Gifts)
                wishlistTitles.Add(g.GiftTitle);

            return wishlistTitles; 
        }

    }
}
