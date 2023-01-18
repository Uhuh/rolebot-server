using RoleBot.Infrastructure.Entities;
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
    
    public Task<GuildConfig?> GetConfig(string guildId)
    {
        return _repository.GetConfig(guildId);
    }
}