using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scoreoracle_backend.DTOs.Pick;
using scoreoracle_backend.Services;

namespace scoreoracle_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PickController : ControllerBase
    {
        private readonly PickService _pickService;

        public PickController(PickService pickService)
        {
            _pickService = pickService;
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
        public async Task<IActionResult> CreatePick([FromBody] PickRequestDto dto)
        {
            var currentUserId = GetCurrentUserId();

            var created = await _pickService.CreatePick(dto, currentUserId);
            return CreatedAtAction(nameof(GetPickById), new { id = created.Id }, created);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPicks()
        {
            var picks = await _pickService.GetAllPicks();
            return Ok(picks);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPickById(Guid id)
        {
            var pick = await _pickService.GetPickById(id);
            return pick is null ? NotFound() : Ok(pick);
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPicksByUserId(Guid userId)
        {
            var picks = await _pickService.GetPicksByUserId(userId);
            return Ok(picks);
        }

        [Authorize]
        [HttpGet("group/{groupId}")]
        public async Task<IActionResult> GetPicksByGroupId(Guid groupId)
        {
            var picks = await _pickService.GetPicksByGroupId(groupId);
            return Ok(picks);
        }

        [Authorize]
        [HttpGet("user/{userId}/group/{groupId}")]
        public async Task<IActionResult> GetPicksByUserAndGroup(Guid userId, Guid groupId)
        {
            var picks = await _pickService.GetPicksByUserAndGroup(userId, groupId);
            return Ok(picks);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePick(Guid id, [FromBody] UpdatePickDto dto)
        {
            var currentUserId = GetCurrentUserId();
            var updated = await _pickService.UpdatePick(id, dto, currentUserId);
            return updated is null ? NotFound() : Ok(updated);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePick(Guid id)
        {
            var currentUserId = GetCurrentUserId();
            var success = await _pickService.DeletePick(id, currentUserId);
            return success ? NoContent() : NotFound();
        }
    }
}
