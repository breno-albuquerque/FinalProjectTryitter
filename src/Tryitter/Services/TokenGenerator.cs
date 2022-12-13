using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tryitter.Entities;

namespace Tryitter.Services
{
    public class TokenGenerator
    {
        public string Generate(Student student)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = AddClaims(student),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")),
                SecurityAlgorithms.HmacSha256Signature
              ),
                Expires = DateTime.Now.AddDays(3)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static ClaimsIdentity AddClaims(Student student)
        {
            ClaimsIdentity claims = new();
            claims.AddClaim(new Claim("id", student.StudentId.ToString()!)); 
            claims.AddClaim(new Claim("email", student.Email));
            return claims;
        }
    }
}