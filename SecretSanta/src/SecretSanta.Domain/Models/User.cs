using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Gift> Gifts { get; set; }
        public List<Group> Groups { get; set; }
    }
}
