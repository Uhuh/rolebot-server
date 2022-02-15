using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleBot.API.Middleware;
using RoleBot.API.Models;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.API.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IDiscordApi _api;
    private readonly IJwtService _jwtService;
    private readonly AuthData _authData;
    public AuthController(IDiscordApi api, AuthData authData, IJwtService jwtService)
    {
        _api = api;
        _authData = authData;
        _jwtService = jwtService;
    }
    
    [AllowAnonymous]
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

            return Ok();
        }
        catch (Exception e)
        {
            return Unauthorized();
        }
    }
}