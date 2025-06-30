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
    }
}
