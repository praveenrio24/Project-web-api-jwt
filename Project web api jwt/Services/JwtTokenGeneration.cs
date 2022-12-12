using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_web_api_jwt.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project_web_api_jwt.Services
{
    public class JwtTokenGeneration: IJwtTokenGeneration
    {
        private readonly IConfiguration _iconfiguration;

        public JwtTokenGeneration(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

		public string Authenticate(string UserId)
		{
			// Else we generate JSON Web Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
			 new Claim(ClaimTypes.Name, UserId)
			  }),
				Expires = DateTime.UtcNow.AddMinutes(60),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);

		}
	}
}
