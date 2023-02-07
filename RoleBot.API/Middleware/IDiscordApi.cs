using Refit;
using RoleBot.API.Models;

namespace RoleBot.API.Middleware;

public interface IDiscordApi
{
    [Post("/oauth2/token")]
    Task<string> GetAccessToken([Body(BodySerializationMethod.UrlEncoded)] AuthData data);

    [Post("/oauth2/token")]
    Task<string> RefreshToken([Body(BodySerializationMethod.UrlEncoded)] AuthData data);

    [Get("/users/@me")]
    Task<string> GetUser([Authorize] string authorization);

    [Get("/users/@me/guilds")]
    Task<string> GetUserGuilds([Authorize] string authorization);

    [Get("/guilds/{guildId}")]
    Task<string> GetGuildInfo([Authorize("Bot")] string token, string guildId);
}
