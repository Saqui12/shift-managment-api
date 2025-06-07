using Application.Services.DTOs.Turno;
using Application.Services.Iterfaces;
using Dominio.Models.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGestionPeloteros.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TurnoController(ITurnoService _service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTurnos([FromQuery] TurnosParameters param)
        {
            var turnos = await _service.GetFiltered(param);
            var _turnos = turnos.Items.ToList();
            var metadata = new
            {
                turnos.TotalCount,
                turnos.PageSize,
                turnos.PageNumber,
                turnos.TotalPages,
                turnos.HasPreviousPage,
                turnos.HasNextPage
            };
            Response.Headers["X-Pagination"] = System.Text.Json.JsonSerializer.Serialize(metadata); 
            return Ok(_turnos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTurnoById(Guid id)
        {
            var turno = await _service.GetByIdAsync(id);
            return Ok(turno);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TurnoCompletoDto turnoCompleto)
        {
            var turno = await _service.CreateAsync(turnoCompleto);
            return CreatedAtAction(nameof(GetTurnoById), new { id = turno.TurnoId }, turno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TurnoUpdateDto turnoCompleto, CancellationToken cancellationToken)
        {
            var updatedTurno = await _service.UpdateAsync(id, turnoCompleto);
            return Ok(updatedTurno);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
