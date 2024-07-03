using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Api.Filters;
using UserManagement.Common.Constants;
using UserManagement.Common.Dtos;
using UserManagement.Common.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        [ValidateDto]
        public IActionResult GetToken([FromQuery]GenerateTokenDto generateTokenDto)
        {
            //Step-1 - Create Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration[KeyVaultSecretConst.JwtSecretKey]);

            //Step-2 - Collect Claims
            var claims = new List<Claim>
            {
                new("UserId", generateTokenDto.UserId),
                new(ClaimTypes.Email, generateTokenDto.Email)
            };

            //Step-3 - Create Token Descriptor using Secret Key, Claims and Set Expiry
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            //Step-4 - Generate Token using Token Handler and Token Descriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //Step-5 - Get Token String from TokenHandler
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new BaseResponse<string>(tokenString));
        }
    }
}
