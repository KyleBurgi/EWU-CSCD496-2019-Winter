using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class Message
    {
        public User Santa { get; set; }
        public User Recipient { get; set; }
        public DateTime Timestamp { get; set; }
        public string MessageText { get; set; }
    }
}
