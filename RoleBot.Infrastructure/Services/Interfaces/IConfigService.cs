using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Services.Interfaces;

public interface IConfigService
{
    public Task<GuildConfig?> GetConfig(string guildId);
}