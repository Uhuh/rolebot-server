using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Nodes;

namespace RoleBot.Infrastructure.Services.Interfaces;

public enum TokenType
{
    Auth,
    Refresh,
}

public interface IJwtService
{
    public string? GenerateAuthToken(string accessToken, string userJsonString, string userGuildJsonString);
    public void VerifyAuthToken(HttpContext context, string token);
    public void AppendTokenCookie(IResponseCookies cookies, JwtSecurityToken token);
}