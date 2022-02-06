using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoleBot.API.Middleware;
using RoleBot.API.Models;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.API.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
public class SignInController : ControllerBase
{
    private readonly IDiscordApi _api;
    private readonly IJwtService _jwtService;
    private readonly AuthData _authData;
    public SignInController(IDiscordApi api, AuthData authData, IJwtService jwtService)
    {
        _api = api;
        _authData = authData;
        _jwtService = jwtService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Auth(string code)
    {
        try
        {
            var userData = _authData with { Code = code };

            var jsonString = await _api.GetAccessToken(userData);

            var json = JsonObject.Parse(jsonString);

            if (json?["access_token"] == null)
            {
                return Unauthorized();
            }

            var accessToken = json["access_token"].ToString();

            var userJsonString = await _api.GetUser(accessToken);
            var userGuildJsonString = await _api.GetUserGuilds(accessToken);

            var token = _jwtService.GenerateAuthToken(accessToken, userJsonString, userGuildJsonString);

            if (token == null)
            {
                return Unauthorized();
            }
            
            _jwtService.AppendTokenCookie(Response.Cookies, token);
            
            var user = JsonConvert.DeserializeObject(userJsonString);
            var guilds = JsonConvert.DeserializeObject(userGuildJsonString);

            var serializedJson = JsonConvert.SerializeObject(new
            {
                user, guilds
            });

            return Ok(JsonObject.Parse(serializedJson));
        }
        catch
        {
            return Unauthorized();
        }
    }
}