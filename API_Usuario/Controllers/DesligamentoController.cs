using API_Usuario.DTOs;
using API_Usuario.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesligamentoController : ControllerBase
    {
        public readonly DesligamentoServices _services;

        public DesligamentoController(DesligamentoServices DesligamentoServices)
        {
            _services = DesligamentoServices;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllDesligamentos());
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] DesligamentoDTOs dto)
        {
            string resultado = await _services.AddDesligamento(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(resultado);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] DesligamentoDTOs dto)
        {
            string resultado = await _services.UpdateDesligamento(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            string resultado = await _services.DeleteDesligamento(id);
            if (resultado.Contains("Não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
    }
}
