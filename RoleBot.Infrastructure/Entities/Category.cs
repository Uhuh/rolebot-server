using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RoleBot.Infrastructure.Enums;
using RoleBot.Infrastructure.Models;

namespace RoleBot.Infrastructure.Entities;

public class Category : IEntity
{
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [Column("guildId")]
    public string GuildId { get; set; }

    [Required]
    [MaxLength(64)]
    [Column("name")]
    public string Name { get; set; }

    [MaxLength(500)]
    [Column("description")]
    public string? Description { get; set; }

    [Required]
    [Column("mutuallyExclusive")]
    public bool MutuallyExclusive { get; set; }
    
    [Column("displayOrder")]
    public DisplayOrder DisplayOrder { get; set; }
    
    [Column("requiredRoleId")]
    public string? RequiredRoleId { get; set; }
    
    [Column("excludedRoleId")]
    public string? ExcludedRoleId { get; set; }
    
    public ICollection<ReactRole> ReactRoles { get; set; }
}
