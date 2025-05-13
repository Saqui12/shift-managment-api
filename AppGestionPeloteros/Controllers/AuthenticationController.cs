using Application.Services.DTOs.User;
using Application.Services.Iterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGestionPeloteros.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController(IAuthenticationService _service) : Controller
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            // Call the authentication service to perform login
            var result = await _service.Login(loginUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUser createUser)
        {
            // Call the authentication service to perform registration
            var result = await _service.Register(createUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize]
        [HttpGet("RefreshToken/{refreshToken}")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            // Call the authentication service to perform token renewal
            var result = await _service.RenewToken(refreshToken);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("{email}")]
       [Authorize("Admin")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            // Call the authentication service to perform user deletion
            var result = await _service.DeleteUser(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{email}")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            // Call the authentication service to get user details
            var result = await _service.GetByEmail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser updateUser)
        {
            // Call the authentication service to perform user update
            var result = await _service.Update(updateUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}