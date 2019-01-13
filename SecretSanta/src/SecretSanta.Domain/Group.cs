using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class Group
    {
        public string GroupTitle { get; set; }
        public List<User> GroupUsers { get; set; }

    }
}
