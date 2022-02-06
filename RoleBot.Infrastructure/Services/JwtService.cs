using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Nodes;
using RoleBot.Infrastructure.Models;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.Infrastructure.Services;

public class JwtService : IJwtService
{
    private const string AuthCookieName = "JwtAuthCookie";
    private const string RefreshCookieName = "JwtRefreshCookie";

    private readonly JwtConfig _jwtConfig;
    
    public JwtService(JwtConfig jwtConfig)
    {
        _jwtConfig = jwtConfig;
    }
    
    public JwtSecurityToken? GenerateAuthToken(string accessTokenJson, string userJsonString, string userGuildJsonString)
    {
        var claims = new List<Claim>
        {
            new("access_token", accessTokenJson.ToString()),
            new("user", userJsonString),
        };

        var token = new JwtSecurityToken(
            _jwtConfig.Issuer,
            _jwtConfig.Audience,
            claims,
            notBefore: DateTime.UtcNow,
            DateTime.UtcNow.Add(_jwtConfig.ExpirationDate),
            _jwtConfig.SigningCredentials
        );

        return token;
    }
    public bool VerifyAuthToken(TokenType tokenType, string tokenString)
    {
        throw new NotImplementedException();
    }

    public void AppendTokenCookie(IResponseCookies cookies, JwtSecurityToken token)
    {
        var expiration = token.ValidTo;
        var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
        var cookieOptions = new CookieOptions { Secure = true, Expires = expiration, HttpOnly = false };
        
        cookies.Append(AuthCookieName, encodedToken, cookieOptions);
    }
}