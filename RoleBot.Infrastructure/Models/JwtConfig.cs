using Microsoft.IdentityModel.Tokens;

namespace RoleBot.Infrastructure.Models;

public record JwtConfig(
    string Issuer,
    string Audience,
    SigningCredentials SigningCredentials,
    TokenValidationParameters TokenValidationParameters,
    TimeSpan ExpirationDate
);