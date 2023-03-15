using NpgsqlTypes;

namespace RoleBot.Infrastructure.Enums;

[PgName("react_role_type_enum")]
public enum ReactRoleType
{
    Normal = 1,
    AddOnly,
    RemoveOnly,
}