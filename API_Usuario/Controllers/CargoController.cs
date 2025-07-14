using API_Usuario.DTOs;
using API_Usuario.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        public readonly CargoService _services;

        public CargoController(CargoService CargoService)
        {
            _services = CargoService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllCargo());
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CargoDTOs dto)
        {
            string resultado = await _services.AddCargo(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(resultado);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] CargoDTOs dto)
        {
            string resultado = await _services.UpdateCargo(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            string resultado = await _services.DeleteCargo(id);
            if (resultado.Contains("Não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
    }
}
