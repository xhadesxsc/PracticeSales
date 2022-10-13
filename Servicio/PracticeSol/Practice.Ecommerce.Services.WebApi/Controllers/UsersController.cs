using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Practice.Ecommerce.Application.DTO;
using Practice.Ecommerce.Application.Interface;
using Practice.Ecommerce.Services.WebApi.Helpers;
using Practice.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;

        public UsersController(IUsersApplication authApplication, IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _usersApplication = authApplication;
            _appSettings = appSettings.Value;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]UsersDto usersDto)
        {
            var response = _usersApplication.Authenticate(usersDto.UserName, usersDto.Password);
            response = new Response<UsersDto>();
            response.IsSuccess = true;
            response.Data = new UsersDto()
            {
                UserId = 1,
                FirstName="Hades",
                LastName="Estrada",
                UserName="xhadesxsc",
                Password="1234",
                Token=""
            };
            if (response.IsSuccess)
            {
                if (true)//response.Data != null
                {

                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response.Message);
            }

            return BadRequest(response.Message);
        }

        private string BuildToken(Response<UsersDto> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<RespuestaAutenticacion>> Login([FromBody] CredencialesUsuario credenciales)
        {
            //var resultado = await signInManager.PasswordSignInAsync(credenciales.Email, credenciales.Password,
            //    isPersistent: false, lockoutOnFailure: false);

            if (true)
            {
                return await ConstruirToken(credenciales);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }

        private async Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario credenciales)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credenciales.Email)
            };

            //var usuario = await userManager.FindByEmailAsync(credenciales.Email);
            var claimsDB = new List<Claim>();//await userManager.GetClaimsAsync(usuario);
            claims.Add(new Claim("role", "admin"));
            claims.AddRange(claimsDB);

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddYears(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiracion, signingCredentials: creds);

            return new RespuestaAutenticacion()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion
            };
        }
    }
}