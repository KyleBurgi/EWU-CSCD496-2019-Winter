using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Api.DTO
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<GroupUser> GroupUsers { get; set; }

        public Group() { }

        public Group(SecretSanta.Domain.Models.Group group)
        {
            Id = group.Id;
            Name = group.Name;
        }

        public static Domain.Models.Group ToEntity(DTO.Group group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            return new Domain.Models.Group { Id = group.Id, Name = group.Name };
        }
    }
}
