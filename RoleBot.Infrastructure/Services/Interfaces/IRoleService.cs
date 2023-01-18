using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Services.Interfaces;

public interface IRoleService
{
    public Task<List<ReactRole>?> GetGuildRoles(string guildId);
}