using NpgsqlTypes;

namespace RoleBot.Infrastructure.Enums;

/**
 * Due to some funky stuff with TypeORM and PSQL the PSQL name in the DB
 * Is equal to the value. :)
 */
public enum GuildReactType
{
    [PgName("0")]
    Reaction = 0,
    [PgName("1")]
    Button,
    [PgName("2")]
    Select
}