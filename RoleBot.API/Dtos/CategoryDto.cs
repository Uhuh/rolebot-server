using System.ComponentModel.DataAnnotations;
using DisplayOrderInfra = RoleBot.Infrastructure.Enums.DisplayOrder;
using CategoryDtoInfra = RoleBot.Infrastructure.Dtos.CategoryDto;
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
  public static DisplayOrderInfra To(DisplayType type) =>
    type switch
    {
      DisplayType.Alpha => DisplayOrderInfra.Alpha,
      DisplayType.ReversedAlpha => DisplayOrderInfra.ReversedAlpha,
      DisplayType.Time => DisplayOrderInfra.Time,
      DisplayType.ReversedTime => DisplayOrderInfra.ReversedTime,
      _ => DisplayOrderInfra.Alpha
    };
  
  public static DisplayType From(DisplayOrderInfra type) =>
    type switch
    {
      DisplayOrderInfra.Alpha => DisplayType.Alpha,
      DisplayOrderInfra.ReversedAlpha => DisplayType.ReversedAlpha,
      DisplayOrderInfra.Time => DisplayType.Time,
      DisplayOrderInfra.ReversedTime => DisplayType.ReversedTime,
      _ => DisplayType.Alpha
    };
  public static CategoryDtoInfra To(CategoryDto dto) => new(dto.Id, dto.GuildId, dto.Name, dto.Description, dto.MutuallyExclusive,
    dto.RequiredRoleId, dto.ExcludedRoleId, To(dto.DisplayOrder));
  
  public static CategoryDto From(CategoryDtoInfra dto) => new(dto.Id, dto.GuildId, dto.Name, dto.Description, dto.MutuallyExclusive,
    dto.RequiredRoleId, dto.ExcludedRoleId, From(dto.DisplayOrder));
}
