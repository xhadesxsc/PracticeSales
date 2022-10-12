using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Practice.Ecommerce.Application.DTO;
using Practice.Ecommerce.Application.Interface;
using Practice.Ecommerce.Services.WebApi.Helpers;
using Practice.Ecommerce.Transversal.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Practice.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication authApplication, IOptions<AppSettings> appSettings)
        {
            _usersApplication = authApplication;
            _appSettings = appSettings.Value;
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
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}