using RoleBot.Infrastructure.Models;
using RoleBot.Infrastructure.Repositories.Interfaces;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.Infrastructure.Services;

internal class ConfigService : IConfigService
{
    private readonly IConfigRepository _repository;

    public ConfigService(IConfigRepository repository)
    {
        _repository = repository;
    }
    
    public Task<ConfigDto?> GetConfig(string guildId)
    {
        return _repository.GetConfig(guildId);
    }

    public Task<ConfigDto> UpdateConfig(ConfigDto updatedConfig)
    {
        return _repository.UpdateConfig(updatedConfig);
    }
}