using API_Usuario.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static OllamaSharp.OllamaApiClient;

namespace API_Usuario.Services
{
    public class LoginService
    {
        private readonly IConfiguration _configuration;

        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UsuarioDTO? Logar(LoginDTO login)
        {
            if (login.Usuario == "admin" && login.Senha == "admin")
            {
                string token = this.GenerateJwtToken(login.Usuario);

                return new UsuarioDTO()
                {
                    Nome = "Administrador",
                    Token = token,
                    Avatar = "http://localhost:4200/assets/img/avatar.png"
                };
            }

            return null;
        }

        private string GenerateJwtToken(string usuario)
        {
            byte[] key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim(ClaimTypes.Role, "admin")
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
