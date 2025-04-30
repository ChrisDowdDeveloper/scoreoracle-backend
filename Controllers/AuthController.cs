using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scoreoracle_backend.DTOs.User;
using scoreoracle_backend.Services;

namespace scoreoracle_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AuthRequestDto dto)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var userId = Guid.Parse(jwtToken.Subject); // or .Claims["sub"]

            var response = await _authService.CreateUser(dto, userId, token);
            return Ok(response);
        }
    }
}