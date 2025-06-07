using Application.Services.DTOs.Bloqueo;
using Application.Services.Iterfaces;
using Dominio.Models.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGestionPeloteros.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class BloqueoController(IBloqueoServices _service) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetBloqueosFiltered([FromQuery] BloqueoParameters param)
        {

            var bloqueos = await _service.GetFilteredBloqueos(param);
            var metadata = new
            {
                bloqueos.TotalCount,
                bloqueos.PageSize,
                bloqueos.HasNextPage,
                bloqueos.HasPreviousPage,
                bloqueos.TotalPages,
                bloqueos.PageNumber
            };
            Response.Headers["X-Pagination"] = System.Text.Json.JsonSerializer.Serialize(metadata);
            return Ok(bloqueos.Items);
        }
        [HttpPost]
        public async Task<IActionResult> AddBloqueo([FromBody] AddBloqueoDto bloqueos)
        {
 
            var result = await _service.AddBloqueo(bloqueos);
            return Ok(result);
        }
        [HttpPut("{bloqueoid}")]
        public async Task<IActionResult> UpdateBloqueo(Guid bloqueoid, [FromBody] AddBloqueoDto bloqueos)
        {

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
