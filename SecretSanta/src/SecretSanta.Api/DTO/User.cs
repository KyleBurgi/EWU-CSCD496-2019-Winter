using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Api.DTO
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Gift> Gifts { get; set; }
        //public List<GroupUser> GroupUsers { get; set; }

        public User() { }

        public User(SecretSanta.Domain.Models.User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            //TODO: Gifts
            //TODO: GroupUsers
        }

        public static Domain.Models.User ToEntity(DTO.User gift)
        {
            //pretend this is implemented
            return null;
        }
    }
}
