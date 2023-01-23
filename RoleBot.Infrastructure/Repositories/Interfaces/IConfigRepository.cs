using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Models;

namespace RoleBot.Infrastructure.Repositories.Interfaces;

public interface IConfigRepository : IDisposable
{
    public Task<ConfigDto?> GetConfig(string guildId);
    public Task<ConfigDto?> UpdateConfig(ConfigDto updatedConfig);
}