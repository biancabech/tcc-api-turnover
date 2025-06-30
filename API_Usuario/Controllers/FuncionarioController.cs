using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Usuario.Services;

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
        public async Task<ActionResult<List<Funcionario>>> GetAll()
        {
            return Ok(await _context.Funcionarios);
        }
    }
}
