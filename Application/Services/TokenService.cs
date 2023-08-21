using Domain.DTO.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services
{
    public class TokenService
    {
        public string GenerateToken(AllActiveUsersWithTheirActiveRole userWithRoles)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Setting.GenerateSecretByte();

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            {
                new Claim (ClaimTypes.Name, userWithRoles.UserName.ToString()),
                new Claim(ClaimTypes.Role, userWithRoles.RoleName.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
