using System.ComponentModel.DataAnnotations;
namespace Rolebot.API.Dtos;

public enum DisplayType
{
  Alpha = 0,
  ReversedAlpha,
  Time,
  ReversedTime
}

public record CategoryDto(
  [Required]
  string GuildId,
  [Required]
  [MaxLength(64)]
  string Name,
  string Description,
  [Required]
  bool MutuallyExclusive,
  string RequiredRoleId,
  string ExcludedRoleId,
  DisplayType DisplayOrder
);
