using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Domain.Models;
using SecretSanta.Domain.Services;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _GiftService;

        public GiftController(IGiftService giftService)
        {
            _GiftService = giftService ?? throw new ArgumentNullException(nameof(giftService));
        }

        // GET api/Gift/5
        [HttpGet("{userId}")]
        public ActionResult<List<DTO.Gift>> GetGiftForUser(int userId)
        {
            if (userId <= 0)
            {
                return NotFound();
            }
            List<Gift> databaseUsers = _GiftService.GetGiftsForUser(userId);

            return databaseUsers.Select(x => new DTO.Gift(x)).ToList();
        }

        // GET api/Gift/4
        [HttpPut("{userId}")]
        public ActionResult<List<DTO.Gift>> AddGiftToUser(int userId, DTO.Gift gift)
        {
            if (userId <= 0)
            {
                return NotFound();
            }

            if (gift == null)
            {
                return BadRequest();
            }

            _GiftService.AddGiftToUser(userId, DTO.Gift.ToEntity(gift));
            return Ok("Added Gift To User");
        }

        [HttpPut("{userId}")]
        public ActionResult<List<DTO.Gift>> UpdateGiftForUser(int userId, DTO.Gift gift)
        {
            if (userId <= 0)
            {
                return NotFound();
            }

            if (gift == null)
            {
                return BadRequest();
            }

            _GiftService.UpdateGiftForUser(userId, DTO.Gift.ToEntity(gift));
            return Ok("Updated Gift For User");
        }

        [HttpDelete("{userId}")]
        public void RemoveGift(DTO.Gift gift)
        {
            if (gift == null)
            {
                BadRequest();
            }

            _GiftService.RemoveGift(DTO.Gift.ToEntity(gift));
        }
    }
}