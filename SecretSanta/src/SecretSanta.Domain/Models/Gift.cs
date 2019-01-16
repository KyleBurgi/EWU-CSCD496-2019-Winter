using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class Gift
    {
        public string GiftTitle { get; set; }
        public int OrderOfImportance { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
