using Refit;

namespace RoleBot.API.Models;

public record AuthData(
    [property: AliasAs("client_id")]
    string ClientId,
    [property: AliasAs("client_secret")]
    string ClientSecret,
    [property: AliasAs("code")]
    string Code,
    [property: AliasAs("grant_type")]
    string GrantType,
    [property: AliasAs("redirect_uri")]
    string RedirectUri
);