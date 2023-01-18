using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Repositories.Interfaces;

public interface IRoleRepository : IDisposable
{
    public Task<List<ReactRole>> GetGuildRoles(string guildId);
}