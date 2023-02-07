using Microsoft.EntityFrameworkCore;
using RoleBot.Infrastructure.Dtos;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Repositories.Interfaces;

namespace RoleBot.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly RoleBotDbContext _context;

    public RoleRepository(RoleBotDbContext context)
    {
        _context = context;
    }

    public Task<List<ReactRoleDto>> GetGuildRoles(string guildId)
    {
        return _context.Set<ReactRole>().Where(r => r.GuildId == guildId)
            .Select(r => ReactRoleDto.From(r))
            .ToListAsync();
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