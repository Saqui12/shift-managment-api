using Application.Services.DTOs.Bloqueo;
using Application.Services.Iterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGestionPeloteros.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BloqueoController(IBloqueoServices _service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetBloqueos()
        {
            
            var bloqueos = await _service.GetBloqueos();

            return Ok(bloqueos);
        }
        [HttpPost]
        public async Task<IActionResult> AddBloqueo([FromBody] AddBloqueoDto bloqueos)
        {
            if (bloqueos == null)
                return BadRequest("Bloqueo cannot be null");
            var result = await _service.AddBloqueo(bloqueos);
            return Ok(result);
        }
        [HttpPut("{bloqueoid}")]
        public async Task<IActionResult> UpdateBloqueo(Guid bloqueoid, [FromBody] AddBloqueoDto bloqueos)
        {
            if (bloqueos == null)
                return BadRequest("Bloqueo cannot be null");
            var result = await _service.UpdateBloqueo(bloqueoid, bloqueos);
            return Ok(result);
        }
        [HttpDelete("{bloqueoid}")]
        public async Task<IActionResult> DeleteBloqueo(Guid bloqueoid)
        {
            var result = await _service.DeleteBloqueo(bloqueoid);
            return Ok(result);
        }

    }
}
