using System.ComponentModel.DataAnnotations;
namespace RoleBot.Infrastructure.Entities;

public class Category : IEntity
{
  public long id { get; set; }

  [Required]
  public string guildId { get; set; }

  [Required]
  [MaxLength(64)]
  public string name { get; set; }

  [MaxLength(500)]
  public string? description { get; set; }

  [Required]
  public bool mutuallyExclusive { get; set; }
}
