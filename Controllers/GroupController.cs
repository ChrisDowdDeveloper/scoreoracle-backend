using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scoreoracle_backend.DTOs.Group;
using scoreoracle_backend.Services;

namespace scoreoracle_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var groups = await _groupService.GetAllGroups(pageNumber, pageSize);
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(Guid id)
        {
            var group = await _groupService.GetGroupById(id);
            return group is null ? NotFound() : Ok(group);
        }

        [HttpGet("public-groups")]
        public async Task<IActionResult> GetPublicGroups() 
        {
            var groups = await _groupService.GetPublicGroups();
            return Ok(groups);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetGroupsCreatedByUser(Guid userId)
        {
            var groups = await _groupService.GetGroupsCreatedByUser(userId);
            return Ok(groups);
        }

        [HttpGet("group-name/{keyword}")]
        public async Task<IActionResult> GetGroupsByName(string keyword)
        {
            var group = await _groupService.SearchGroupsByName(keyword);
            return Ok(group);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupRequestDto dto)
        {
            var created = await _groupService.CreateGroup(dto);
            return CreatedAtAction(nameof(GetGroupById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateGroup(Guid id, [FromBody] UpdateGroupDto dto)
        {
            var updated = await _groupService.UpdateGroup(id, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            var deleted = await _groupService.DeleteGroup(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}