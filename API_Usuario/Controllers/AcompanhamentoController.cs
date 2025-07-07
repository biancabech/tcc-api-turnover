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

        public AcompanhamentoController (AcompanhamentoServices Acompanhamentoservices)
        {
            _services = Acompanhamentoservices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllAcompanhamentos());
        }
    }
}
