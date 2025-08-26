using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Usuario.Services;
using API_Usuario.DTOs;

namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivoDesligamentoController : ControllerBase
    {
        public readonly MotivoDesligamentoServices _services;

        public MotivoDesligamentoController(MotivoDesligamentoServices MotivoDesligamentoServices)
        {
            _services = MotivoDesligamentoServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllMotivoDesligamento());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _services.GetMotivoDesligamento(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MotivoDesligamentoDTOs dto)
        {
            string resultado = await _services.AddMotivoDesligamento(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(new { mensagem = resultado });

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] MotivoDesligamentoDTOs dto)
        {
            string resultado = await _services.UpdateMotivoDesligamento(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(new { mensagem = resultado });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            string resultado = await _services.DeleteMotivoDesligamento(id);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(new { mensagem = resultado });
        }
    }
}
