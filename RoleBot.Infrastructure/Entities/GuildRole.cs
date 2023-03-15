using System.ComponentModel.DataAnnotations.Schema;

namespace RoleBot.Infrastructure.Entities;

public class GuildRole : IEntity
{
    [Column("id")]
    public long Id { get; set; }
    [Column("guildId")]
    public string GuildId { get; set; }
    [Column("roleId")]
    public string RoleId { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("color")]
    public long Color { get; set; }
    [Column("position")]
    public long Position { get; set; }
    [Column("permissions")]
    public string Permissions { get; set; }
    
    public GuildInfo GuildInfo { get; }
}