using API_Usuario.DTOs;
using API_Usuario.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitCulturalController : ControllerBase
    {
        public readonly FitCulturalServices _services;

        public FitCulturalController (FitCulturalServices FitCulturalServices)
        {
            _services = FitCulturalServices;
        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllFitCulturals());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _services.GetFitCultural(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] FitCulturalDTOs dto)
        {
            string resultado = await _services.AddFitCultural(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(resultado);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] FitCulturalDTOs dto)
        {
            string resultado = await _services.UpdateFitCultural(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(new { mensagem = resultado });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            string resultado = await _services.DeleteFitCultural(id);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(new { mensagem = resultado });
        }
    }
}
