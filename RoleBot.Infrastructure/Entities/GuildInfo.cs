using System.ComponentModel.DataAnnotations.Schema;

namespace RoleBot.Infrastructure.Entities;

public class GuildInfo : IEntity
{
    [Column("id")]
    public long Id { get; set; }
    [Column("guildId")]
    public string GuildId { get; set; }
    
    public ICollection<GuildRole> GuildRoles { get; set; }
    public ICollection<GuildEmoji> GuildEmojis { get; set; }
}