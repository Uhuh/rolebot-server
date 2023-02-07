using RoleBot.Infrastructure.Dtos;

namespace RoleBot.Infrastructure.Repositories.Interfaces;

public interface IRoleRepository : IDisposable
{
    public Task<List<ReactRoleDto>> GetGuildRoles(string guildId);
}