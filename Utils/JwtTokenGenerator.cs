using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TicketSystem.Utils
{
    public class JwtTokenGenerator
    {
        public static string GenerateJwtToken(int idUsuario, int idPerfil, string secretKey)
        {
            var (idAleatorioUno, idAleatorioDos, idAleatorioTres) = TokenHelper.GenerarIds(idUsuario, idPerfil);

            var claims = new[]
            {
                new Claim("IdUsuario", idUsuario.ToString()),
                new Claim("IdPerfil", idPerfil.ToString()),
                new Claim("IdAleatorioUno", idAleatorioUno.ToString()),
                new Claim("IdAleatorioDos", idAleatorioDos.ToString()),
                new Claim("IdAleatorioTres", idAleatorioTres.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "dylancueto.com",
                audience: "dylancueto.com",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
