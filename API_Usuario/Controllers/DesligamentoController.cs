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
    }
}
