using SecretSanta.Domain.Interfaces;
using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class Message : Entity
    {
        public int SantaId { get; set; }
        public User SantaUser { get; set; }
        public int RecieverId { get; set; }
        public User ReciverUser { get; set; }
        public string MessageText { get; set; }
    }
}
