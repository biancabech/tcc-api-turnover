using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Usuario.Services;
using API_Usuario.DTOs;

namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        public readonly FuncionarioServices _services;

        public FuncionarioController(FuncionarioServices FuncionarioServices)
        {
            _services = FuncionarioServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllFuncionarios());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult> GetById (Guid id)
        {
            var result = await _services.GetFuncionario(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult> GetByName(string cpf)
        {
            var result = await _services.GetFuncionarioCpf(cpf);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] FuncionarioDTOs dto)
        {
            string resultado = await _services.AddFuncionario(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(new { mensagem = resultado });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] FuncionarioDTOs dto)
        {
            string resultado = await _services.UpdateFuncionario(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(new { mensagem = resultado });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            string resultado = await _services.DeleteFuncionario(id);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(new { mensagem = resultado });
        }
    }
}
