using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Tryitter.Services
{
  public class TokenGenerator
  {
    public string Generate()
    {
      var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Expires = System.DateTime.Now.AddDays(3)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
    }
  }
}