using Application.Services.DTOs.Auth;
using Application.Services.DTOs.User;
using Application.Services.Iterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace AppGestionPeloteros.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController(IAuthenticationService _service) : Controller
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
           
            var result = await _service.Login(loginUser);
            if (result.Success)
            {
                //Response.Cookies.Append("JWT", result.Token, new CookieOptions
                //{
                //    HttpOnly = true,
                //    Secure = true,
                //    SameSite = SameSiteMode.None,
                //    Path = "/"
                //});
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
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var userDto = await _service.GetAllUser();
            return Ok(userDto);
        }


        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userDto = await _service.GetAuthenticatedUserAsync(User);
            return Ok(userDto);
        }


        [Authorize]
        [HttpGet("RefreshToken/{refreshToken}")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
       
            var result = await _service.RenewToken(refreshToken);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            
            var result = await _service.DeleteUser(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            
            var result = await _service.GetByEmail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("getUserRole/{email}")]
        public async Task<IActionResult> GetUserRoleByEmail(string email)
        {
            // Call the authentication service to get user details
            var result = await _service.GetRoleIdByEmail(email);
            if (!result.IsNullOrEmpty())
            {
                return Ok(result);
            }
            return NotFound(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("AddUserToRole/{userid}")]
        public async Task<IActionResult> AddUserToRole(string userid, [FromBody] string role)
        {
            // Call the authentication service to get user details
            var result = await _service.AddUserToRole(userid, role);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [Authorize]
        [HttpPut("updateuser/{id}")]
        public async Task<IActionResult> UpdateUser(string userid, [FromBody] UpdateUser updateUser)
        {
            // Call the authentication service to perform user update
            var result = await _service.Update(userid , updateUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Borrar la cookie del token JWT
            Response.Cookies.Delete("JWT", new CookieOptions
            {
                Path = "/",
                Secure = true,
                SameSite = SameSiteMode.Lax
            });

            return Ok(new { message = "Sesión cerrada correctamente" });
        }
        [Authorize]
        [HttpPost("resetPassword/{id}")]
        public async Task<IActionResult> resetPassword(string id, [FromBody] PasswordResetDto pass)
        {
            var result = await _service.ResetPassword(id, pass);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();

                return BadRequest(new
                {
                    message = "Error al restablecer la contraseña",
                    errors = errors
                });

            }
            
            
            return Ok(new { message = "Contraseña restablecida correctamente" });
        }

    }
}