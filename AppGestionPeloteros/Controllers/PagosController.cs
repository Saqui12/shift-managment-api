using Application.Services.DTOs.Pago;
using Application.Services.Iterfaces;
using Dominio.Models.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGestionPeloteros.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PagosController(IPagosService _service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]PagosParameters param)
        {
            return Ok(await _service.GetAllFilterAsync(param));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PagoCreationDto pago)
        {
            var newPago = await _service.CreateAsync(pago);
            return CreatedAtAction(nameof(GetAll), new { id = newPago.Id }, newPago);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] PagoDto pago)
        {
            await _service.UpdateAsync(id, pago);
            return NoContent();
        }
    }
}
