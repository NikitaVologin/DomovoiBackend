using DomovoiBackend.API.Auth.ServiceDecorators;
using DomovoiBackend.API.JsonInheritance;
using DomovoiBackend.Application;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;
using DomovoiBackend.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
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

// TODO: Доделать ApplicationLayer и PersistenceLayer (RUD);
builder.Services.AddApplicationLayer()
    .AddMappers()
    .AddPersistence(builder.Configuration)
    .CreateDatabase()
    .FillDatabase();

builder.Services.Decorate<ICounterAgentService, AuthCounterAgentService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthorization();
builder.Services.AddSession();

builder.Services.AddCors();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
        options.LoginPath = "/CounterAgent/Login";
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AuthenticatedCounterAgent", policy => policy.RequireClaim("CounterAgentId"));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseCors(corsBuilder =>
{
    corsBuilder.AllowAnyOrigin();
    corsBuilder.AllowAnyHeader();
    corsBuilder.AllowAnyMethod();
});

app.UseAuthentication();
app.UseAuthorization();

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