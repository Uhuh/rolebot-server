using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using RoleBot.API.Middleware;
using RoleBot.API.Models;

namespace RoleBot.API.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
public class SignInController : ControllerBase
{
    private readonly IDiscordApi _api;
    private AuthData _authData;
    public SignInController(IDiscordApi api, AuthData authData)
    {
        _api = api;
        _authData = authData;
    }
    
    [HttpPost]
    public async Task<IActionResult> Auth(string code)
    {
        var userData = _authData with { Code = code };

        var jsonString = await _api.GetAccessToken(userData);

        var json = JsonObject.Parse(jsonString);

        if (json != null && json["access_token"] != null)
        {
            var accessToken = json["access_token"].ToString();

            return Ok(await _api.GetUser(accessToken));
        }
        
        return Ok(json);
    }
}