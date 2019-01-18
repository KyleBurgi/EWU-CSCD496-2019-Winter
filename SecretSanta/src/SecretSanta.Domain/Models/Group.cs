using SecretSanta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain
{
    public class Group : Entity
    {
        public string GroupName { get; set; }
        public ICollection<UserGroup> UserGroup { get; set; }

        public Group(string groupName)
        {
            if (groupName == null)
                throw new ArgumentNullException(nameof(groupName));

            GroupName = groupName;
            UserGroup = new List<UserGroup>();
        }
    }
}
