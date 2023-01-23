using RoleBot.Infrastructure.Models;

namespace RoleBot.Infrastructure.Services.Interfaces;

public interface IConfigService
{
    public Task<ConfigDto?> GetConfig(string guildId);
    public Task<ConfigDto?> UpdateConfig(ConfigDto config);
}