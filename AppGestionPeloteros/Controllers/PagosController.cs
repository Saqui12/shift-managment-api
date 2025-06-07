using Application.Services.DTOs.Pago;
using Application.Services.Iterfaces;
using Dominio.Entities;
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
            var pagos = await _service.GetAllFilterAsync(param);
            var _pagos = pagos.Items;
            var metadata = new
            {
                pagos.TotalCount,
                pagos.PageSize,
                pagos.PageNumber,
                pagos.TotalPages,
                pagos.HasPreviousPage,
                pagos.HasNextPage
            };
            Response.Headers["X-Pagination"] = System.Text.Json.JsonSerializer.Serialize(metadata);
            return Ok(_pagos);

        }
        [HttpGet("GetByTurnoId/{id}")]
        public async Task<IActionResult> GetByTurnoIdAsync(Guid id )
        {
            return Ok(await _service.GetByTurnoAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PagoCreationDto pago)
        {
            var newPago = await _service.CreateAsync(pago);
            return CreatedAtAction(nameof(GetAll), new { id = newPago.TransaccionId }, newPago);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] PagoUpdateDto pago)
        {
            await _service.UpdateAsync(id, pago);
            return NoContent();
        }
    }
}
