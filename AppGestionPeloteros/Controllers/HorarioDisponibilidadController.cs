using Application.Services.DTOs.HorarioDisponibilidad;
using Application.Services.Iterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGestionPeloteros.Controllers
{
        [Authorize]
        [Route("api/[controller]")]
    public class HorarioDisponibilidadController(IHorarioDisponibilidadService _service) : Controller
    {

        [HttpPost]
        public async Task<IActionResult> CreateHorarioDisponibilidad([FromBody] HorarioDisponibilidadCreation horario)
        {
            var newHorario = await _service.CreateAsync(horario);
            return CreatedAtAction(nameof(GetHorarioDisponibilidadById), new { id = newHorario.HorarioDisponibilidadId }, newHorario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHorarioDisponibilidadById(Guid id)
        {
            var horario = await _service.GetByIdAsync(id);
            return Ok(horario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorarioDisponibilidad(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHorarioDisponibilidad(Guid id, [FromBody] UpdateHorariosDisponibilidadDto horario)
        {
            await _service.UpdateAsync(id, horario);
            return NoContent();
        }
    }
}
