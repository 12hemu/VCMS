using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VCMS411.Models;

namespace VCMS411.Service
{
    public class TokenGeneration: ITokenGeneration
    {
        //TokenGeneration.cs
        private readonly IConfiguration _configuration;
         public TokenGeneration(IConfiguration configuration) { _configuration = configuration; }
        public string GenerateToken(UserCreds userCreds)
        { var key = _configuration.GetValue<string>("JwtConfig:Key");
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor() { Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier,userCreds.UserName) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature) };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); }
    }
}
