using NpgsqlTypes;

namespace RoleBot.Infrastructure.Enums;

/**
 * Due to some funky stuff with TypeORM and PSQL the PSQL name in the DB
 * Is equal to the value. :)
 */
[PgName("guild_config_reacttype_enum")]
public enum GuildReactType
{
    [PgName("0")]
    Reaction = 0,
    [PgName("1")]
    Button,
    [PgName("2")]
    Select
}