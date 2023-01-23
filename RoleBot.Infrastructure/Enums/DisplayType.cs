using NpgsqlTypes;

namespace RoleBot.Infrastructure.Enums;

[PgName("category_displayorder_enum")]
public enum DisplayOrder
{
    [PgName("0")]
    Alpha = 0,
    [PgName("1")]
    ReversedAlpha,
    [PgName("2")]
    Time,
    [PgName("3")]
    ReversedTime
}