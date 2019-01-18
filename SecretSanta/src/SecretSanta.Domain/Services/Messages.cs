using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain.Services
{
    public class Messages
    {
        private ApplicationDbContext DbContext { get; set; }

        public Messages(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void AddMessage(Message message)
        {
            DbContext.Messages.Add(message);
            DbContext.SaveChanges();
        }

        public Message RetrieveMessage(int messageId)
        {
            return DbContext.Messages.Find(messageId);
        }
    }
}
