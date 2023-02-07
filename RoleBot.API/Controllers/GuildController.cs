using Microsoft.AspNetCore.Mvc;
using Rolebot.API.Dtos;
using RoleBot.API.Middleware;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.API.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class GuildController : ControllerBase
{
    private readonly IConfigService _service;
    private readonly IDiscordApi _api;
    private readonly string _token;

    public GuildController(IConfigService service, IDiscordApi api, IConfiguration configuration)
    {
        _service = service;
        _api = api;
        _token = configuration["BotToken"];
    }

    [JwtAuthorize]
    [HttpGet(nameof(Get))]
    [ProducesResponseType(typeof(ConfigDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string guildId)
    {
        var result = await _service.GetConfig(guildId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [JwtAuthorize]
    [HttpPost(nameof(Update))]
    [ProducesResponseType(typeof(ConfigDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromBody] ConfigDto config)
    {
        var result = await _service.UpdateConfig(ConfigDto.To(config));

        if (result == null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }

    [JwtAuthorize]
    [HttpGet(nameof(GetGuildInfo))]
    [ProducesResponseType(typeof(ConfigDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGuildInfo(string guildId)
    {
        var result = await _api.GetGuildInfo(_token, guildId);

        return Ok(result);
    }
    
}