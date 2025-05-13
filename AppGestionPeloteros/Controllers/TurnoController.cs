using Application.Services.DTOs;
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
        [HttpGet("week")]
        public async Task<IActionResult> GetTurnosByWeek(DateOnly week)
        {
                var turnos = await _service.GetByWeek(week);
                return Ok(turnos);
                      
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTurnos([FromQuery]TurnosParameters param)
        {
            var turnos = await _service.GetFiltered(param);
            return Ok(turnos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTurnoById(Guid id)
        {

            var turno = await _service.GetByIdAsync(id);
            return Ok(turno);
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]TurnoCompletoDto turnoCompleto)
        {
                var turno = await _service.CreateAsync(turnoCompleto);
                return CreatedAtAction(nameof(GetTurnoById), new { id = turno.TurnoId }, turno);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
