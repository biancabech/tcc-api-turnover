using API_Usuario.DTOs;
using API_Usuario.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompanhamentoController : ControllerBase
    {
        public readonly AcompanhamentoServices _services;

        public AcompanhamentoController(AcompanhamentoServices Acompanhamentoservices)
        {
            _services = Acompanhamentoservices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllAcompanhamentos());
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AcompanhamentoDTOs dto)
        {
            string resultado = await _services.AddAcompanhamento(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(resultado);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AcompanhamentoDTOs dto)
        {
            string resultado = await _services.UpdateAcompanhamento(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            string resultado = await _services.DeleteAcompanhamento(id);
            if (resultado.Contains("Não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
    }
}