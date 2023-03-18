using Microsoft.AspNetCore.Mvc;
using Rolebot.API.Dtos;
using RoleBot.API.Middleware;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.API.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
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
    
    [JwtAuthorize]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<JoinRoleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGuildJoinRoles(string guildId)
    {
        var result = await _roleService.GetGuildJoinRoles(guildId);

        return Ok(result.Select(JoinRoleDto.From));
    }

    [JwtAuthorize]
    [HttpPut]
    [ProducesResponseType(typeof(IEnumerable<ReactRoleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateReactRole([FromBody] ReactRoleDto reactRole, string guildId)
    {
        var result = await _roleService.CreateReactRole(ReactRoleDto.To(reactRole), guildId);

        return Ok(ReactRoleDto.From(result));
    }
    
    [JwtAuthorize]
    [HttpPut]
    [ProducesResponseType(typeof(JoinRoleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateJoinRole([FromBody] JoinRoleDto role, string guildId)
    {
        var result = await _roleService.CreateJoinRole(JoinRoleDto.To(role), guildId);

        return Ok(JoinRoleDto.From(result));
    }
}