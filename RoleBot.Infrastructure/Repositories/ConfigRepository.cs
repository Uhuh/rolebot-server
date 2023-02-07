using Microsoft.EntityFrameworkCore;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Dtos;
using RoleBot.Infrastructure.Repositories.Interfaces;

namespace RoleBot.Infrastructure.Repositories;

public class ConfigRepository : IConfigRepository
{
    private readonly RoleBotDbContext _context;

    public ConfigRepository(RoleBotDbContext context)
    {
        _context = context;
    }
    
    public async Task<ConfigDto?> GetConfig(string guildId)
    {
        var config = await _context.Set<GuildConfig>().Where(c => c.GuildId == guildId).FirstOrDefaultAsync();

        return config == null ? null : ConfigDto.From(config);
    }

    public async Task<ConfigDto> UpdateConfig(ConfigDto updatedConfig)
    {
        var config = await _context.Set<GuildConfig>().Where(c => c.GuildId == updatedConfig.GuildId)
            .FirstOrDefaultAsync();

        if (config == null)
            return null;

        config.ReactType = updatedConfig.ReactType;
        config.HideEmojis = updatedConfig.HideEmojis;

        await _context.SaveChangesAsync();

        return ConfigDto.From(config);
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }

    private bool _disposed = false;
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}