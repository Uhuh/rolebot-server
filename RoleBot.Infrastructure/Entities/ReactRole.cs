using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RoleBot.Infrastructure.Enums;

namespace RoleBot.Infrastructure.Entities;

public class ReactRole : IEntity
{
    public long id { get; set;  }
    
    [Required]
    public string name { get; set; }
    
    [Required]
    public string roleId { get; set; }
    
    [Required]
    public string emojiId { get; set; }
    
    [Required]
    public string guildId { get; set; }
    
    [Required]
    public ReactRoleType type { get; set; }
    
    public long? categoryId { get; set; }
    [JsonIgnore]
    public Category? category { get; set; }

    [required] 
    public button type {get; set;}
}