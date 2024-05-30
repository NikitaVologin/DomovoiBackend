using DomovoiBackend.API.JsonInheritance;
using DomovoiBackend.API.Middlewares;
using DomovoiBackend.Application;
using DomovoiBackend.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.SignalR;
using DomovoiBackend.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "DomovoiBackend.API",
            Version = "v1"
        });
    options.UseAllOfToExtendReferenceSchemas();
    options.UseAllOfForInheritance();
    options.UseOneOfForPolymorphism();
});

var inheritanceConfigurations =
    new AssemblyInheritanceConfiguration()
        .CreateAllConfigurations();

// TODO: Сделать нормальную конфигурацию сериализации подтипов.
builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
    {
        foreach(var inheritanceConfiguration in inheritanceConfigurations)
            options.SerializerSettings.Converters.Add(inheritanceConfiguration);
    });

// TODO: Доделать ApplicationLayer и PersistenceLayer (RUD);
builder.Services.AddApplicationLayer()
    .AddMappers()
    .AddPersistence(builder.Configuration)
    .CreateDatabase()
    .FillDatabase();


builder.Services.AddCors();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
        options.LoginPath = "/CounterAgent/Login";
    });

var app = builder.Build();

app.UseCors(corsBuilder =>
{
    corsBuilder.AllowAnyOrigin();
    corsBuilder.AllowAnyHeader();
    corsBuilder.AllowAnyMethod();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapHub<ChatHub>("/Chat");

// TODO: Сделать одно middleware для каждого вида запросов с подтипами.
// app.UseMiddleware<AnnouncementRouteTransformerMiddleware>();
// app.UseMiddleware<CounterAgentRouteTransformerMiddleware>();

app.MapControllers();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

public partial class Program;