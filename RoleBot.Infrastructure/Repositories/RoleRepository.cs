using Microsoft.EntityFrameworkCore;
using RoleBot.Infrastructure.Dtos;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Enums;
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

    public async Task<ReactRoleDto> CreateReactRole(ReactRoleDto reactRoleDto, string guildId)
    {
        var newReactRole = new ReactRole
        {
            Name = reactRoleDto.Name,
            GuildId = guildId,
            Description = reactRoleDto.Description,
            RoleId = reactRoleDto.RoleId,
            CategoryId = reactRoleDto.CategoryId,
            CategoryAddDate = new DateTime(),
            EmojiId = reactRoleDto.EmojiId,
            EmojiTag = reactRoleDto.EmojiTag,
            Type = ReactRoleType.Normal
        };

        await _context.Set<ReactRole>().AddAsync(newReactRole);

        await _context.SaveChangesAsync();

        return ReactRoleDto.From(newReactRole);
    }

    public Task<List<JoinRoleDto>> GetGuildJoinRoles(string guildId)
    {
        return _context.Set<JoinRole>().Where(r => r.GuildId == guildId)
            .Select(r => JoinRoleDto.From(r))
            .ToListAsync();
    }

    public async Task<JoinRoleDto> CreateJoinRole(JoinRoleDto joinRole, string guildId)
    {
        var newJoinRole = new JoinRole
        {
            RoleId = joinRole.RoleId,
            GuildId = guildId,
            Name = joinRole.Name
        };

        await _context.Set<JoinRole>().AddAsync(newJoinRole);

        await _context.SaveChangesAsync();

        return JoinRoleDto.From(newJoinRole);
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