using API_Usuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IaIndicaController : ControllerBase
    {
        public readonly IaIndicaServices _services;

        public IaIndicaController(IaIndicaServices iaIndicaServices)
        {
            _services = iaIndicaServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { resultado = _services.Analisar() });
        }
    }
}
