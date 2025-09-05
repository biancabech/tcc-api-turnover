using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using API_Usuario.Services;
using API_Usuario.DTOs;

namespace API_Usuario.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _service;

        public LoginController(LoginService loginService)
        {
            _service = loginService;
        }

        [HttpPost()]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            UsuarioDTO? usuario = _service.Logar(login);

            if (usuario == null)
            {
                return Unauthorized();
            }

            return Ok(usuario);
        }
    }
}
