using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class Pairing
    {
        public User Santa { get; set; }
        public User Recipient { get; set; }
    }
}
