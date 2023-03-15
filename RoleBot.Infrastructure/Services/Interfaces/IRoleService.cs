using RoleBot.Infrastructure.Dtos;

namespace RoleBot.Infrastructure.Services.Interfaces;

public interface IRoleService
{
    public Task<List<ReactRoleDto>> GetGuildRoles(string guildId);
    public Task<ReactRoleDto> CreateReactRole(ReactRoleDto reactRole, string guildId);
    public Task<List<JoinRoleDto>> GetGuildJoinRoles(string guildId);
    public Task<JoinRoleDto> CreateJoinRole(JoinRoleDto joinRole, string guildId);
}