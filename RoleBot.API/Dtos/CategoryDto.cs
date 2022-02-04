using System.ComponentModel.DataAnnotations;
namespace Rolebot.API.Dtos;

public record CategoryDto(
  [Required]
  string GuildId,
  [Required]
  [MaxLength(64)]
  string Name,
  [MaxLength(500)]
  string Description,
  [Required]
  bool MutuallyExclusive
);
