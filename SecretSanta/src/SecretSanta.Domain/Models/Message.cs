using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class Message
    {
        public User Santa { get; set; }
        public User Recipient { get; set; }
        public List<string> Messages { get; set; }
    }
}
