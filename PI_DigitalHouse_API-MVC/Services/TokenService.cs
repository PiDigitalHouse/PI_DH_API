using Microsoft.IdentityModel.Tokens;
using PI_DigitalHouse_API_MVC.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PI_DigitalHouse_API_MVC.Services
{
    public static class TokenService
    {
        public static string GerarChaveToken(Usuario usuario)
        {
            var jwt = new JwtSecurityTokenHandler();
            var verifySignature = Encoding.ASCII.GetBytes(Ambiente.Chave);
            var payload = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(verifySignature),
                    SecurityAlgorithms.HmacSha256)
            };
            var chave = jwt.CreateToken(payload);
            return jwt.WriteToken(chave);
        }
    }
}
