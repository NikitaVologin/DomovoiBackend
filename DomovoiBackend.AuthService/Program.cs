using Dapper;
using DomovoiBackend.AuthService.Models;
using DomovoiBackend.AuthService.Persistence.Factory;using DomovoiBackend.AuthService.Persistence.Repositories;
using DomovoiBackend.AuthService.Requests;
using DomovoiBackend.AuthService.TypeHandlers;

SqlMapper.AddTypeHandler(new GuidTypeHandler());

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var dbInitializer = new DbInitializer(new SqliteConnectionFactory(builder.Configuration));

dbInitializer.CreateDatabaseSchema()
    .InsertTestData();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IConnectionFactory, SqliteConnectionFactory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapGet("Check/{email}",
    async (string email, IUserRepository repository) => await repository.IsUserExistAsync(email));

app.MapPost("Registration", async (RegistrationRequest request, IUserRepository repository) =>
{
    var user = new User
    {
        CounterAgentId = request.CounterAgentId,
        Email = request.Email,
        Password = request.Password,
        Id = Guid.NewGuid()
    };

    await repository.AddUserAsync(user);
});

app.Run();