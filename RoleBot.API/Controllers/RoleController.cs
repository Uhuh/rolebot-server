using Microsoft.AspNetCore.Mvc;
using Rolebot.API.Dtos;
using RoleBot.API.Middleware;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.API.Controllers;

[Route("/api/[controller]/[action]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [JwtAuthorize]
    [HttpGet]
    [ProducesResponseType(typeof(List<ReactRoleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGuildRoles(string guildId)
    {
        var result = await _roleService.GetGuildRoles(guildId);

        return Ok(result);
    }
}