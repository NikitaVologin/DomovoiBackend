using DomovoiBackend.API.Auth.ServiceDecorators;
using DomovoiBackend.API.Hubs;
using DomovoiBackend.API.JsonInheritance;
using DomovoiBackend.API.Logging.ServiceDecorators;
using DomovoiBackend.Application;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;
using DomovoiBackend.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SignalR;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddApplicationLayer()
    .AddMappers()
    .AddPersistence(builder.Configuration)
    .CreateDatabase()
    .FillDatabase();

builder.Services.AddLogging();

builder.Services.Decorate<ICounterAgentService, AuthCounterAgentService>();
builder.Services.Decorate<IAnnouncementService, AuthAnnouncementService>();

builder.Services.Decorate<ICounterAgentService>((inner, provider) =>
{
    var logger = provider.GetRequiredService<ILogger<ICounterAgentService>>();
    return new LoggerCounterAgentService(inner, logger);
});

builder.Services.Decorate<IAnnouncementService>((inner, provider) =>
{
    var logger = provider.GetRequiredService<ILogger<IAnnouncementService>>();
    return new LoggerAnnouncementService(inner, logger);
});



builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthorization();
builder.Services.AddSession();

builder.Services.AddCors(); 

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.SlidingExpiration = true;
        options.LoginPath = "/CounterAgent/Login";
        options.LogoutPath = "/CounterAgent/Logout";
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AuthenticatedCounterAgent", policy => policy.RequireClaim("CounterAgentId"));

builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors(policyBuilder =>
{
    policyBuilder.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});

app.MapHub<ChatHub>("Hubs/Chat");

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

public partial class Program;
