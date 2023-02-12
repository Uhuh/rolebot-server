using System.ComponentModel.DataAnnotations.Schema;

namespace RoleBot.Infrastructure.Entities;

public class GuildEmoji : IEntity
{
    [Column("id")]
    public long Id { get; set; }
    [Column("guildId")]
    public string GuildId { get; set; }
    [Column("emojiId")]
    public string EmojiId { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("animated")]
    public bool Animated { get; set; }
    
    public GuildInfo GuildInfo { get; }
}