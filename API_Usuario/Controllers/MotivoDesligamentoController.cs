using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Usuario.Services;

namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivoDesligamentoController : ControllerBase
    {
        public readonly MotivoDesligamentoServices _services;

        public MotivoDesligamentoController(MotivoDesligamentoServices MotivoDesligamentoServices)
        {
            _services = MotivoDesligamentoServices;
        }
    }
}
