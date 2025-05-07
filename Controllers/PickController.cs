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

        [HttpPost]
        public async Task<IActionResult> CreatePick([FromBody] PickRequestDto dto)
        {
            var created = await _pickService.CreatePick(dto);
            return CreatedAtAction(nameof(GetPickById), new { id = created.Id }, created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPicks()
        {
            var picks = await _pickService.GetAllPicks();
            return Ok(picks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPickById(Guid id)
        {
            var pick = await _pickService.GetPickById(id);
            return pick is null ? NotFound() : Ok(pick);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPicksByUserId(Guid userId)
        {
            var picks = await _pickService.GetPicksByUserId(userId);
            return Ok(picks);
        }

        [HttpGet("group/{groupId}")]
        public async Task<IActionResult> GetPicksByGroupId(Guid groupId)
        {
            var picks = await _pickService.GetPicksByGroupId(groupId);
            return Ok(picks);
        }

        [HttpGet("user/{userId}/group/{groupId}")]
        public async Task<IActionResult> GetPicksByUserAndGroup(Guid userId, Guid groupId)
        {
            var picks = await _pickService.GetPicksByUserAndGroup(userId, groupId);
            return Ok(picks);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePick(Guid id, [FromBody] UpdatePickDto dto)
        {
            var updated = await _pickService.UpdatePick(id, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePick(Guid id)
        {
            var success = await _pickService.DeletePick(id);
            return success ? NoContent() : NotFound();
        }
    }
}
