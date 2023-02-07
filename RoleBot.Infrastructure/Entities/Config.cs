using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RoleBot.Infrastructure.Enums;

namespace RoleBot.Infrastructure.Entities;

public class GuildConfig : IEntity
{
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("guildId")]
    public string GuildId { get; set; }
    
    [Required]
    [Column("reactType")]
    public GuildReactType ReactType { get; set; }
    
    [Required]
    [Column("hideEmojis")]
    public bool HideEmojis { get; set; }
}