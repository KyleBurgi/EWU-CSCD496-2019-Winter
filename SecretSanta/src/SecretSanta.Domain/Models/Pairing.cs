using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class Pairing : Entity
    {
        public int RecieverId { get; set; }
        public User RecieverUser { get; set; }
        public int SantaId { get; set; }
        public User SantaUser { get; set; }
    }
}
