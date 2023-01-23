using System.ComponentModel.DataAnnotations;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Enums;

namespace RoleBot.Infrastructure.Models;

public record CategoryDto(
  long Id,
  [Required] string GuildId,
  [Required] [MaxLength(64)] string Name,
  string Description,
  [Required] bool MutuallyExclusive,
  string? RequiredRoleId,
  string? ExcludedRoleId,
  DisplayOrder DisplayOrder
)
{
  public static CategoryDto From(Category category) => new(category.Id, category.GuildId, category.Name,
    category.Description, category.MutuallyExclusive, category.RequiredRoleId, category.ExcludedRoleId,
    category.DisplayOrder);
}
