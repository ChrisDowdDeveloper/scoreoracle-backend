using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] GroupMemberRequestDto dto)
        {
            var added = await _groupMemberService.AddMember(dto);
            return CreatedAtAction(nameof(GetGroupMemberById), new { id = added.Id }, added);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupMemberById(Guid id)
        {
            var member = await _groupMemberService.GetGroupMemberById(id);
            return member is null ? NotFound() : Ok(member);
        }

        [HttpGet("user/{userId}/group/{groupId}")]
        public async Task<IActionResult> GetGroupMember(Guid userId, Guid groupId)
        {
            var member = await _groupMemberService.GetGroupMember(userId, groupId);
            return member is null ? NotFound() : Ok(member);
        }

        [HttpGet("group/{groupId}/members")]
        public async Task<IActionResult> GetMembersByGroupId(Guid groupId)
        {
            var members = await _groupMemberService.GetMembersByGroupId(groupId);
            return Ok(members);
        }

        [HttpGet("group/{groupId}/admins")]
        public async Task<IActionResult> GetAdminsByGroupId(Guid groupId)
        {
            var admins = await _groupMemberService.GetAdminsByGroupId(groupId);
            return Ok(admins);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateGroupMember(Guid id, [FromBody] UpdateGroupMemberDto dto)
        {
            var updated = await _groupMemberService.UpdateGroupMember(id, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMember(Guid id)
        {
            var removed = await _groupMemberService.RemoveMember(id);
            return removed ? NoContent() : NotFound();
        }

        [HttpDelete("user/{userId}/group/{groupId}")]
        public async Task<IActionResult> RemoveMemberByUserAndGroup(Guid userId, Guid groupId)
        {
            var removed = await _groupMemberService.RemoveMemberByUserAndGroup(userId, groupId);
            return removed ? NoContent() : NotFound();
        }

        [HttpGet("user/{userId}/group/{groupId}/is-member")]
        public async Task<IActionResult> IsUserInGroup(Guid userId, Guid groupId)
        {
            var isMember = await _groupMemberService.IsUserInGroup(userId, groupId);
            return Ok(new { isMember });
        }

        [HttpGet("user/{userId}/group/{groupId}/is-admin")]
        public async Task<IActionResult> IsUserGroupAdmin(Guid userId, Guid groupId)
        {
            var isAdmin = await _groupMemberService.IsUserGroupAdmin(userId, groupId);
            return Ok(new { isAdmin });
        }
    }
}