using API_Usuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosGraficoAnualController: ControllerBase
    {
        public readonly DadosGraficoAnualService _services;
        public DadosGraficoAnualController (DadosGraficoAnualService dadosGraficoAnualServices)
        {
            _services = dadosGraficoAnualServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetGrafico());
        }
    }
}
