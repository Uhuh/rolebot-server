using RoleBot.Infrastructure.Dtos;

namespace RoleBot.Infrastructure.Services.Interfaces;

public interface IRoleService
{
    public Task<List<ReactRoleDto>> GetGuildRoles(string guildId);
}