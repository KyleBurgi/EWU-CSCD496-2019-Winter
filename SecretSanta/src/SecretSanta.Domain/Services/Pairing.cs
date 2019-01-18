using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain.Services
{
    public class Pairing
    {
        private ApplicationDbContext DbContext { get; set; }

        public Pairing(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void CreatePairing(User santa, User recipient)
        {
            DbContext.Pairing.Add(new Domain.Pairing { SantaUser = santa, RecieverUser = recipient });
            DbContext.SaveChanges();
        }
    }
}
