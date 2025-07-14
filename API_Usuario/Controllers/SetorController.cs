using API_Usuario.DTOs;
using API_Usuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        public readonly SetorService _services;

        public SetorController(SetorService SetorServices)
        {
            _services = SetorServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllSetor());
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] SetorDTO dto)
        {
            string resultado = await _services.AddSetor(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(resultado);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] SetorDTO dto)
        {
            string resultado = await _services.UpdateSetor(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            string resultado = await _services.DeleteSetor(id);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
    }
}
