using System.Text.Json.Serialization;
using RoleBot.API.Middleware;
using RoleBot.Infrastructure;
using Refit;
using RoleBot.API.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new AuthData(
    builder.Configuration["AuthData:ClientId"],
    builder.Configuration["AuthData:ClientSecret"],
    "",
    builder.Configuration["AuthData:GrantType"],
    builder.Configuration["AuthData:RedirectUri"]
));

builder.Services.AddRefitClient<IDiscordApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://discordapp.com/api"));

builder.Services.SetupInfrastructureServices();
builder.Services.SetupJwt(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
