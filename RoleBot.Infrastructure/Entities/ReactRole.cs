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
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Required]
    [Column("roleId")]
    public string RoleId { get; set; }
    
    [Required]
    [Column("emojiId")]
    public string EmojiId { get; set; }
    
    [Column("emojiTag")]
    public string? EmojiTag { get; set; }
    
    [Required]
    [Column("guildId")]
    public string GuildId { get; set; }

    [Column("categoryId")]
    public long? CategoryId { get; set; }
    
    [Column("categoryAddDate")]
    public DateTime? CategoryAddDate { get; set; }
    
    [Column("type")]
    public ReactRoleType Type { get; set; }
    
    [JsonIgnore]
    public Category? Category { get; set; }
}