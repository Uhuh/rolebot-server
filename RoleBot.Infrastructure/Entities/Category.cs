using System.ComponentModel.DataAnnotations;
namespace RoleBot.Infrastructure.Entities;

public class Category : IEntity
{
  public long Id { get; set; }

  [Required]
  public string GuildId { get; set; }

  [Required]
  [MaxLength(64)]
  public string Name { get; set; }

  [MaxLength(500)]
  public string? Description { get; set; }

  [Required]
  public bool MutuallyExclusive { get; set; }
}
