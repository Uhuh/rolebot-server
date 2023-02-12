using RoleBot.Infrastructure.Dtos;

namespace RoleBot.Infrastructure.Repositories.Interfaces;

public interface IGuildInfoRepository : IDisposable
{
    public Task<GuildInfoDto?> GetGuildInfo(string guildId);
    public void UpdateGuildEmojis(IEnumerable<GuildEmojiDto> emojis, string guildId);
    public void UpdateGuildRoles(IEnumerable<GuildRoleDto> roles, string guildId);
    public void AddGuildEmojis(IEnumerable<GuildEmojiDto> emojis, string guildId);
    public void AddGuildRoles(IEnumerable<GuildRoleDto> roles, string guildId);
}