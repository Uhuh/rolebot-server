using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Dtos;

namespace RoleBot.Infrastructure.Repositories.Interfaces;

public interface IConfigRepository : IDisposable
{
    public Task<ConfigDto?> GetConfig(string guildId);
    public Task<ConfigDto?> UpdateConfig(ConfigDto updatedConfig);
}