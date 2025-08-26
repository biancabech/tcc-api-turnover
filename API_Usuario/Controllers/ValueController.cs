
using API_Usuario.Services;
using Microsoft.AspNetCore.Mvc;
using API_Usuario.Models;
using Microsoft.AspNetCore.Http.HttpResults;
namespace API_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController
    {
        public readonly ValueService _services;
        public ValueController(ValueService ValueServices)
        {
            _services = ValueServices;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllValue());
        }
    }
}
