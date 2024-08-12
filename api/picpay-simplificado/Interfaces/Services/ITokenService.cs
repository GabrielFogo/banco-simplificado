using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace picpay_simplificado.Interfaces.Services;

public interface ITokenService
{
    JwtSecurityToken GenerateAcessToken(IEnumerable<Claim> claims, IConfiguration _configuration);
}