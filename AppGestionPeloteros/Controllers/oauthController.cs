using Application.Services.Iterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text.Json;

namespace AppGestionPeloteros.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class oauthController(IoauthService _googleAuth) : ControllerBase
    {      

        [HttpGet("signin")]
        public IActionResult SignInWithGoogle()
        {
            var url = _googleAuth.GetAuthorizationUrl();
            return Redirect(url);
        }

        [HttpGet("callback")]
        public async Task<IActionResult> Callback([FromQuery] string code)
        {
            var token = await _googleAuth.ExchangeCodeForTokenAsync(code);

            var calendars = await _googleAuth.GetUserCalendarsAsync(token.AccessToken);
   

            return Ok(new
            {
                TokenInfo = token,
                Calendars = calendars,

            });
        }
        [HttpGet("event/${AccessToken}")]
        public async Task<IActionResult> GetEvents(string AccessToken)
        {

            var desde = new DateTime(2025, 1, 1);
            var hasta = new DateTime(2025, 6, 30);
            var eventos = await _googleAuth.GetCalendarEventsAsync(AccessToken, "manuelnunez427@gmail.com", desde,hasta);

            return Ok(new
            {
                TokenInfo = AccessToken,
                Events = eventos
            });
        }
    }
}
