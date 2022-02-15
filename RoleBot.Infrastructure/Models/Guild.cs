namespace RoleBot.Infrastructure.Models;

public record Guild(
    string id,
    string icon,
    string name,
    bool owner,
    int permissions,
    string permissions_new,
    string[] features
);