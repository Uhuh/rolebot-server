using Microsoft.EntityFrameworkCore;
using RoleBot.Infrastructure.Dtos;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Repositories.Interfaces;

namespace RoleBot.Infrastructure.Repositories;

public class GuildInfoRepository : IGuildInfoRepository
{
    private readonly RoleBotDbContext _context;

    public async Task<GuildInfoDto?> GetGuildInfo(string guildId)
    {
        var result = await _context.Set<GuildInfo>().Where(g => g.GuildId == guildId)
            .Include(g => g.GuildEmojis)
            .Include(g => g.GuildRoles)
            .FirstOrDefaultAsync();

        return result == null ? null : GuildInfoDto.From(result);
    }

    public async void UpdateGuildEmojis(IEnumerable<GuildEmojiDto> emojis, string guildId)
    {
        var emojisToRemove = await _context.Set<GuildEmoji>().Where(e => e.GuildId == guildId).ToListAsync();

        _context.RemoveRange(emojisToRemove);

        var emojisToAdd = emojis.Select(e => new GuildEmoji
        {
            GuildId = guildId,
            Name = e.Name,
            EmojiId = e.EmojiId,
            Animated = e.Animated
        }).ToList();

        await _context.Set<GuildEmoji>().AddRangeAsync(emojisToAdd);

        await _context.SaveChangesAsync();
    }

    public async void UpdateGuildRoles(IEnumerable<GuildRoleDto> roles, string guildId)
    {
        var rolesToRemove = await _context.Set<GuildRole>().Where(r => r.GuildId == guildId).ToListAsync();

        _context.RemoveRange(rolesToRemove);

        var rolesToAdd = roles.Select(r => new GuildRole
        {
            GuildId = guildId,
            Name = r.Name,
            Color = r.Color,
            Permissions = r.Permissions,
            Position = r.Position,
            RoleId = r.RoleId
        }).ToList();

        await _context.Set<GuildRole>().AddRangeAsync(rolesToAdd);

        await _context.SaveChangesAsync();
    }

    public async void AddGuildEmojis(IEnumerable<GuildEmojiDto> emojis, string guildId)
    {
        var emojisToAdd = emojis.Select(e => new GuildEmoji
        {
            GuildId = guildId,
            Name = e.Name,
            EmojiId = e.EmojiId,
            Animated = e.Animated
        });

        await _context.Set<GuildEmoji>().AddRangeAsync(emojisToAdd);
        await _context.SaveChangesAsync();
    }

    public async void AddGuildRoles(IEnumerable<GuildRoleDto> roles, string guildId)
    {
        var rolesToAdd = roles.Select(r => new GuildRole
        {
            GuildId = guildId,
            Name = r.Name,
            Color = r.Color,
            Permissions = r.Permissions,
            Position = r.Position,
            RoleId = r.RoleId
        });

        await _context.Set<GuildRole>().AddRangeAsync(rolesToAdd);
        await _context.SaveChangesAsync();
    }
    
    private bool _disposed = false;
    
    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}