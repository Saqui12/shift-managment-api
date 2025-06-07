using Application.Services.DTOs.Cliente;
using Application.Services.Iterfaces;
using Dominio.Models.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGestionPeloteros.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ClientesController(IClientesService _service) : Controller
    {
        

        [HttpGet]
        public async Task<IActionResult> GetClientesFilter([FromQuery] ClientesParameters param)
        {
            var clientes = await _service.GetAllFilterAsync(param);

            var metadata = new
            {
                clientes.TotalCount,
                clientes.PageSize,
                clientes.HasNextPage,
                clientes.HasPreviousPage,
                clientes.TotalPages,
                clientes.PageNumber
            };
            Response.Headers["X-Pagination"] = System.Text.Json.JsonSerializer.Serialize(metadata);
            return Ok(clientes.Items);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody]ClienteCreationDto client)
        {
            var newClient=  await _service.CreateAsync(client);
            return CreatedAtAction(nameof(GetClienteById), new { id = newClient.ClienteId }, newClient);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(Guid id)
        {
            var cliente = await _service.GetByIdAsync(id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(Guid id,[FromBody] ClienteDto cliente)
        {
            await _service.UpdateAsync(id, cliente);
            return NoContent();
        }

    }
}
