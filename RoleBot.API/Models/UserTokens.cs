namespace RoleBot.API.Models;

public class UserTokens
{
    public string Token { get; set; }
    public string Username { get; set; }
    public TimeSpan Validity { get; set; }
    public string RefreshToken { get; set; }
    public Guid Id { get; set; }
    public Guid GuidId { get; set; }
    public DateTime ExpiredTime { get; set; }
}