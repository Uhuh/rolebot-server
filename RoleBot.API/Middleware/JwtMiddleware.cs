using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.API.Middleware;

internal class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext ctx, IJwtService jwtService)
    {
        // Get Bearer token
        var token = ctx.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            jwtService.VerifyAuthToken(ctx, token);
        }
        
        return _next(ctx);
    }
}