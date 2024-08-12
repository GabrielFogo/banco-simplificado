using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using picpay_simplificado.Interfaces.Services;

namespace picpay_simplificado.Services;

public class TokenService : ITokenService
{
    public JwtSecurityToken GenerateAcessToken(IEnumerable<Claim> claims, IConfiguration _configuration)
    {
        var key = _configuration.GetSection("JWT").GetValue<string>("SecretKey") ??
                  throw new InvalidOperationException("Invalid Secret key");

        var privateKey = Encoding.UTF8.GetBytes(key);
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(privateKey),
            SecurityAlgorithms.HmacSha256Signature
            );
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_configuration.GetSection("JWT")
                .GetValue<double>("TokenValidityInMinutes")),
            Audience = _configuration.GetSection("JWT").GetValue<string>("ValidAudience"),
            Issuer = _configuration.GetSection("JWT").GetValue<string>("ValidIssuer"),
            SigningCredentials = signingCredentials
        };

        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateJwtSecurityToken(tokenDescriptor);

        return token;
    }
}