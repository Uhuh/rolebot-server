using System.ComponentModel.DataAnnotations.Schema;

namespace RoleBot.Infrastructure.Entities;

public class JoinRole : IEntity
{
    [Column("id")]
    public string Id { get; set; }
    
    [Column("roleId")]
    public string RoleId { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("guildId")]
    public string GuildId { get; set; }
}