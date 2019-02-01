using System.Collections.Generic;
using SecretSanta.Domain.Services;
using SecretSanta.Domain.Models;

namespace SecretSanta.Api.Tests
{
    public class TestableGroupService : IGroupService
    {
        Group IGroupService.AddGroup(Group group)
        {
            throw new System.NotImplementedException();
        }

        List<Group> IGroupService.FetchAll()
        {
            throw new System.NotImplementedException();
        }

        Group IGroupService.UpdateGroup(Group group)
        {
            throw new System.NotImplementedException();
        }
    }
}