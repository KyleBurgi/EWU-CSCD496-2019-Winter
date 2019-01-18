using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretSanta.Domain.Services
{
    public class Gifts
    {
        private ApplicationDbContext DbContext { get; set; }

        public Gifts(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void CreateGift(User user, Gift gift)
        {
            DbContext.Gifts.Add(gift);
            DbContext.SaveChanges();
        }

        public void AddGift(Gift gift)
        {
            DbContext.Gifts.Add(gift);
            DbContext.SaveChanges();
        }

        public void UpdateGift(User user, Gift gift)
        {
            if (gift.Id == default(int))
                DbContext.Gifts.Add(gift);
            else
                DbContext.Gifts.Update(gift);

            DbContext.SaveChanges();
        }

        public void DeleteGift(User user, Gift gift)
        {
            DbContext.Gifts.Remove(gift);
            user.Gifts.Remove(gift);
            DbContext.SaveChanges();
        }
    }
}
