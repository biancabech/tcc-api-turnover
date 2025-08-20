using API_Usuario.DTOs;
using API_Usuario.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Usuario.Models;

namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        public readonly EnderecoService _service;

        public EnderecoController(EnderecoService Enderecoservice)
        {
            _service = Enderecoservice;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _service.GetAllEndereco());
        }
        
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] EnderecoDTOs dto)
        {
            Endereco endereco = await _service.AddEndereco(dto);
            return Ok(endereco);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] EnderecoDTOs dto)
        {
            string resultado = await _service.UpdateEndereco(id, dto);
                if (resultado.Contains("Não encontrado")) return NotFound(resultado);
                return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            string resultado = await _service.DeleteEndereco(id);
            if (resultado.Contains("Não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
    }
}
