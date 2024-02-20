using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QArte.Services.DTOs;
using QArte.Persistance.Enums;
using QArte.Persistance.PersistanceModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using QArte.Services.ServiceInterfaces;
using Microsoft.Extensions.Configuration;

//new
namespace QArte.Services.Services
{
    public class TokennService : ITokennService
    {
        private readonly IConfiguration _configuration;

        public TokennService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(UserDTO user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

            var claims = new List<Claim>()
            {
                    //down here new Claim(JwtRegisteredClaimNames.Email, user.getEntity().Email)???
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                    new Claim("FirstName", user.FirstName ?? ""),
                    new Claim("LastName", user.LastName ?? ""),
                    //do i need to add userRole
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }


    }
}