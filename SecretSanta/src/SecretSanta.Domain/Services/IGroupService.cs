using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SecretSanta.Domain.Services
{
    public interface IGroupService
    {
        Group AddGroup(Group group);
        Group UpdateGroup(Group group);
        List<Group> FetchAll();
    }
}
