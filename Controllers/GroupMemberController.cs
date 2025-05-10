using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scoreoracle_backend.DTOs.GroupMember;
using scoreoracle_backend.Services;

namespace scoreoracle_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupMemberController : ControllerBase
    {
        private readonly GroupMemberService _groupMemberService;

        public GroupMemberController(GroupMemberService groupMemberService)
        {
            _groupMemberService = groupMemberService;
        }

        private Guid GetCurrentUserId()
        {
            var claim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if(claim == null || !Guid.TryParse(claim.Value, out var userId))
                throw new UnauthorizedAccessException("Invalid or missing user ID in token");
            
            return userId;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] GroupMemberRequestDto dto)
        {
            var userId = GetCurrentUserId();
            var added = await _groupMemberService.AddMember(dto, userId);
            return CreatedAtAction(nameof(GetGroupMemberById), new { id = added.Id }, added);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupMemberById(Guid id)
        {
            var member = await _groupMemberService.GetGroupMemberById(id);
            return member is null ? NotFound() : Ok(member);
        }

        [Authorize]
        [HttpGet("user/{userId}/group/{groupId}")]
        public async Task<IActionResult> GetGroupMember(Guid userId, Guid groupId)
        {
            var member = await _groupMemberService.GetGroupMember(userId, groupId);
            return member is null ? NotFound() : Ok(member);
        }

        [Authorize]
        [HttpGet("group/{groupId}/members")]
        public async Task<IActionResult> GetMembersByGroupId(Guid groupId)
        {
            var members = await _groupMemberService.GetMembersByGroupId(groupId);
            return Ok(members);
        }

        [Authorize]
        [HttpGet("group/{groupId}/admins")]
        public async Task<IActionResult> GetAdminsByGroupId(Guid groupId)
        {
            var admins = await _groupMemberService.GetAdminsByGroupId(groupId);
            return Ok(admins);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateGroupMember(Guid id, [FromBody] UpdateGroupMemberDto dto)
        {
            var userId = GetCurrentUserId();
            var updated = await _groupMemberService.UpdateGroupMember(id, dto, userId);
            return updated is null ? NotFound() : Ok(updated);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMember(Guid id)
        {
            var userId = GetCurrentUserId();
            var removed = await _groupMemberService.RemoveMember(id, userId);
            return removed ? NoContent() : NotFound();
        }

        [Authorize]
        [HttpDelete("user/{userId}/group/{groupId}")]
        public async Task<IActionResult> RemoveMemberByUserAndGroup(Guid userId, Guid groupId)
        {
            var currentUserId = GetCurrentUserId();
            var removed = await _groupMemberService.RemoveMemberByUserAndGroup(userId, groupId, currentUserId);
            return removed ? NoContent() : NotFound();
        }

        [HttpGet("user/{userId}/group/{groupId}/is-member")]
        public async Task<IActionResult> IsUserInGroup(Guid userId, Guid groupId)
        {
            var isMember = await _groupMemberService.IsUserInGroup(userId, groupId);
            return Ok(new { isMember });
        }

        [Authorize]
        [HttpGet("user/{userId}/group/{groupId}/is-admin")]
        public async Task<IActionResult> IsUserGroupAdmin(Guid userId, Guid groupId)
        {
            var isAdmin = await _groupMemberService.IsUserGroupAdmin(userId, groupId);
            return Ok(new { isAdmin });
        }
    }
}