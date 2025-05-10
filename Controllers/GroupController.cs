using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        private Guid GetCurrentUserId()
        {
            var claim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if(claim == null || !Guid.TryParse(claim.Value, out var userId))
                throw new UnauthorizedAccessException("Invalid or missing user ID in token");
            
            return userId;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var groups = await _groupService.GetAllGroups(pageNumber, pageSize);
            return Ok(groups);
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupRequestDto dto)
        {
            var created = await _groupService.CreateGroup(dto);
            return CreatedAtAction(nameof(GetGroupById), new { id = created.Id }, created);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateGroup(Guid id, [FromBody] UpdateGroupDto dto)
        {
            var userId = GetCurrentUserId();
            var updated = await _groupService.UpdateGroup(id, dto, userId);
            return updated is null ? NotFound() : Ok(updated);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            var userId = GetCurrentUserId();
            var deleted = await _groupService.DeleteGroup(id, userId);
            return deleted ? NoContent() : NotFound();
        }
    }
}