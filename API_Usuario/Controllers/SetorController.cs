using API_Usuario.DTOs;
using API_Usuario.Services;
using Microsoft.AspNetCore.Mvc;
using API_Usuario.Models;

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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _services.GetSetor(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
         
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] SetorDTO dto)
        {
            Setor setor = await _services.AddSetor(dto);
            return Ok(setor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] SetorDTO dto)
        {
            string resultado = await _services.UpdateSetor(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(new { mensagem = resultado });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            string resultado = await _services.DeleteSetor(id);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(new { mensagem = resultado });
        }
    }
}
