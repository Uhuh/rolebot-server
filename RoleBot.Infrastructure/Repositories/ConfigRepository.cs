using Microsoft.EntityFrameworkCore;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Repositories.Interfaces;

namespace RoleBot.Infrastructure.Repositories;

public class ConfigRepository : IConfigRepository
{
    private readonly RoleBotDbContext _context;

    public ConfigRepository(RoleBotDbContext context)
    {
        _context = context;
    }
    
    public Task<GuildConfig?> GetConfig(string guildId)
    {
        return _context.Set<GuildConfig>().Where(c => c.GuildId == guildId).FirstOrDefaultAsync();
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