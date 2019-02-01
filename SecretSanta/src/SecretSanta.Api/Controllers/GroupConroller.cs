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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _GroupService;

        public GroupController(IGroupService groupService)
        {
            _GroupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }


        [HttpGet("{userId}")]
        public ActionResult<List<DTO.Group>> FetchAll()
        {
            List<Group> databaseGroups = _GroupService.FetchAll();
            return databaseGroups.Select(x => new DTO.Group(x)).ToList();
        }

        [HttpPut("{userId}")]
        public ActionResult AddGroup(DTO.Group group)
        {
            if (group == null)
            {
                return BadRequest();
            }

            _GroupService.AddGroup(DTO.Group.ToEntity(group));
            return Ok("Group Added");
        }

        [HttpPut("{userId}")]
        public ActionResult UpdateGroup(DTO.Group group)
        {
            if (group == null)
            {
                return BadRequest();
            }

            _GroupService.UpdateGroup(DTO.Group.ToEntity(group));
            return Ok("Group Updated");
        }
    }
}
