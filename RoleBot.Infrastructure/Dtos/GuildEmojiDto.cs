using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Dtos;

public record GuildEmojiDto(
    string GuildId,
    string EmojiId,
    string Name,
    bool Animated
)
{
    public static GuildEmojiDto From(GuildEmoji emoji) => new
        (emoji.GuildId, emoji.EmojiId, emoji.Name, emoji.Animated);
}