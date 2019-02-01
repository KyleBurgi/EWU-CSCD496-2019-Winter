using System.Collections.Generic;
using SecretSanta.Domain.Services;
using SecretSanta.Domain.Models;

namespace SecretSanta.Api.Tests
{
    public class TestableUserService : IUserService
    {
        User IUserService.AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

        List<User> IUserService.FetchAll()
        {
            throw new System.NotImplementedException();
        }

        User IUserService.UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}