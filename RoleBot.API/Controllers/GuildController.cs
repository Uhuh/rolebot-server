using Microsoft.AspNetCore.Mvc;
using Rolebot.API.Dtos;
using RoleBot.API.Middleware;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.API.Controllers;

[Route("/api/[controller]/[action]")]
public class GuildController : ControllerBase
{
    private readonly IConfigService _service;
    public GuildController(IConfigService service)
    {
        _service = service;
    }

    [JwtAuthorize]
    [HttpGet]
    [ProducesResponseType(typeof(ConfigDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetConfig(string guildId)
    {
        var result = await _service.GetConfig(guildId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}