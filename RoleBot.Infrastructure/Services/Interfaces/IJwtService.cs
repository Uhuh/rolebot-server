using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;

namespace RoleBot.Infrastructure.Services.Interfaces;

public enum TokenType
{
    Auth,
    Refresh,
}

public interface IJwtService
{
    public Task<JwtSecurityToken?> GenerateAuthToken(string userId);
    public bool VerifyAuthToken(TokenType tokenType, string tokenString);
}