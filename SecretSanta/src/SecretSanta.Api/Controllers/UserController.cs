using Microsoft.AspNetCore.Mvc;
using SecretSanta.Domain.Models;
using SecretSanta.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService userService)
        {
            _UserService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("{userId}")]
        public ActionResult<List<User>> FetchAll()
        {
            return _UserService.FetchAll();
        }

        [HttpGet("{userId}")]
        public ActionResult<User> AddUser(DTO.User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _UserService.AddUser(DTO.User.ToEntity(user));
            return Ok();
        }

        [HttpGet("{userId}")]
        public ActionResult<User> UpdateUser(DTO.User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _UserService.UpdateUser(DTO.User.ToEntity(user));
            return Ok();
        }
    }
}
