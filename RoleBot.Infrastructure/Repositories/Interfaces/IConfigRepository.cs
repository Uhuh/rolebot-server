using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Repositories.Interfaces;

public interface IConfigRepository : IDisposable
{
    public Task<GuildConfig?> GetConfig(string guildId);
}