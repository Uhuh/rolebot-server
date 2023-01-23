using System.ComponentModel.DataAnnotations;
using DisplayOrderInfra = RoleBot.Infrastructure.Enums.DisplayOrder;
namespace Rolebot.API.Dtos;

public enum DisplayType
{
  Alpha = 0,
  ReversedAlpha,
  Time,
  ReversedTime
}

public record CategoryDto(
  long Id,
  [Required] string GuildId,
  [Required] [MaxLength(64)] string Name,
  string? Description,
  [Required] bool MutuallyExclusive,
  string? RequiredRoleId,
  string? ExcludedRoleId,
  DisplayType DisplayOrder
)
{
  public static DisplayOrderInfra DisplayTo(DisplayType type) =>
    type switch
    {
      DisplayType.Alpha => DisplayOrderInfra.Alpha,
      DisplayType.ReversedAlpha => DisplayOrderInfra.ReversedAlpha,
      DisplayType.Time => DisplayOrderInfra.Time,
      DisplayType.ReversedTime => DisplayOrderInfra.ReversedTime,
      _ => DisplayOrderInfra.Alpha
    };
  public static RoleBot.Infrastructure.Models.CategoryDto To(CategoryDto dto) => new(dto.Id, dto.GuildId, dto.Name, dto.Description, dto.MutuallyExclusive,
    dto.RequiredRoleId, dto.ExcludedRoleId, DisplayTo(dto.DisplayOrder));
}
