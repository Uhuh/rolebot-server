using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RoleBot.Infrastructure.Enums;

namespace RoleBot.Infrastructure.Entities;

public class ReactRole : IEntity
{
    [Column("id")]
    public long Id { get; set;  }
    
    [Required]
    [Column("name")]
    public string Name { get; set; }
    
    [Required]
    [Column("guildId")]
    public string RoleId { get; set; }
    
    [Required]
    [Column("emojiId")]
    public string EmojiId { get; set; }
    
    [Required]
    [Column("guildId")]
    public string GuildId { get; set; }

    [Column("categoryId")]
    public long? CategoryId { get; set; }
    
    [JsonIgnore]
    public Category? Category { get; set; }
}