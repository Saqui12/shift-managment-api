using Application.Services.DTOs.Recurso;
using Application.Services.Iterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGestionPeloteros.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class RecursosController(IRecursoServices _service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
 
            var recursos = await _service.GetRecursos();
            return Ok(recursos);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddRecursoDto recurso)
        {
            
            var newRecurso = await _service.AddRecurso(recurso);
            return CreatedAtAction(nameof(GetAll), new { id = newRecurso!.Id }, newRecurso);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] AddRecursoDto recurso)
        {
            
            await _service.UpdateRecurso(id, recurso);
            return NoContent();
        }
        [Authorize(Roles = "NotAllowed")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            
            await _service.DeleteRecurso(id);
            return NoContent();
        }
    }
}
