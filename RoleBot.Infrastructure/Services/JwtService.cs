using System.IdentityModel.Tokens.Jwt;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.Infrastructure.Services;

public class JwtService : IJwtService
{
    public Task<JwtSecurityToken?> GenerateAuthToken(string userId)
    {
        throw new NotImplementedException();

    }
    public bool VerifyAuthToken(TokenType tokenType, string tokenString)
    {
        throw new NotImplementedException();
    }
}