using Refit;
namespace RoleBot.API.Middleware;

[Headers("Authorization: Bearer")]
public interface IDiscordApi
{
    [Post("/token")]
    Task<string> GetAccessToken([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);
}
