using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RoleBot.Infrastructure.Models;
using RoleBot.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace RoleBot.Infrastructure.Services;

public class JwtService : IJwtService
{
    private const string AuthCookieName = "JwtAuthCookie";
    private const string RefreshCookieName = "JwtRefreshCookie";

    private readonly JwtConfig _jwtConfig;
    private readonly ILogger<JwtService> _logger;

    public JwtService(JwtConfig jwtConfig, ILogger<JwtService> logger)
    {
        _jwtConfig = jwtConfig;
        _logger = logger;
    }
    
    public string? GenerateAuthToken(string accessTokenJson, string userJsonString, string userGuildJsonString)
    {
        var guilds = JsonConvert.DeserializeObject<List<Guild>>(userGuildJsonString);

        // The only guilds we'll allow users to see/modify are those with the manage guild perms.
        var guildsWithManagePermissions = guilds?.FindAll(g => (g.permissions & 0x20) == 0x20).Select(g => new
        {
            g.id,
            g.icon,
            g.name
        }).ToList();
            
        var claims = new List<Claim>
        {
            new("access_token", accessTokenJson),
            new("user", userJsonString),
            new("guilds", JsonConvert.SerializeObject(guildsWithManagePermissions))
        };

        var token = new JwtSecurityToken(
            _jwtConfig.Issuer,
            _jwtConfig.Audience,
            claims,
            notBefore: DateTime.UtcNow,
            DateTime.UtcNow.Add(_jwtConfig.ExpirationDate),
            _jwtConfig.SigningCredentials
        );

        // Generate the JWT token string to return all the way up.
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public void VerifyAuthToken(HttpContext context, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token, _jwtConfig.TokenValidationParameters, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var guildsString = jwtToken.Claims.First(x => x.Type == "guilds").Value;
            var guilds = JsonConvert.DeserializeObject<List<Guild>>(guildsString);

            var guildId = context.Request.Query["guildId"];
            var guild = guilds?.Find(g => g.id == guildId);

            context.Items["Guild"] = guild;

            _logger.LogInformation("Verified user.");
        }
        catch {}
    }

    public void AppendTokenCookie(IResponseCookies cookies, JwtSecurityToken token)
    {
        var expiration = token.ValidTo;
        var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
        var cookieOptions = new CookieOptions { Secure = false, Expires = expiration, HttpOnly = false };
        
        cookies.Append(AuthCookieName, encodedToken, cookieOptions);
    }
}