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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var cargo = await _services.GetCargo(id);
            if (cargo == null) return NotFound("Cargo não encontrado");
            return Ok(cargo);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CargoDTOs dto)
        {
            string resultado = await _services.AddCargo(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(new { resultado });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] CargoDTOs dto)
        {
            string resultado = await _services.UpdateCargo(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(new { resultado });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            string resultado = await _services.DeleteCargo(id);
            if (resultado.Contains("Não encontrado")) return NotFound(resultado);
            return Ok(new { resultado });
        }
    }
}
