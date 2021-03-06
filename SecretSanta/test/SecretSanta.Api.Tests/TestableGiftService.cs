﻿using SecretSanta.Domain.Models;
using SecretSanta.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Api.Tests
{
    public class TestableGiftService : IGiftService
    {
        public Task<List<Gift>> ToReturn { get; set; }
        public int GetGiftsForUser_UserId { get; set; }

        public async Task<List<Gift>> GetGiftsForUser(int userId)
        {
            GetGiftsForUser_UserId = userId;
            return await ToReturn;
        }
    }
}
