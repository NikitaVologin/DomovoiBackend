using Dapper;
using DomovoiBackend.AuthService.Models;
using DomovoiBackend.AuthService.Persistence.Factory;

namespace DomovoiBackend.AuthService.Persistence.Repositories;

public class DbInitializer
{
    private readonly SqliteConnectionFactory _factory;

    public DbInitializer(SqliteConnectionFactory factory) => _factory = factory;
    
    public DbInitializer CreateDatabaseSchema()
    {
        using var connection = _factory.Create();
        connection.Execute(@"DROP TABLE IF EXISTS Users");
        connection.Execute(@"CREATE TABLE Users (Id STRING PRIMARY KEY,
                                CounterAgentId STRING,
                                Email TEXT,
                                Password TEXT)");
        return this;
    }

    public DbInitializer InsertTestData()
    {
        using var connection = _factory.Create();
        connection.Execute(@"DELETE FROM Users");
        var insertQuery = @"INSERT INTO Users (Id, CounterAgentId, Email, Password)
                                      VALUES (@Id, @CounterAgentId, @Email, @Password)";

        IEnumerable<User> users =
        [
            new User
            {
                Id = Guid.NewGuid(),
                CounterAgentId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474"),
                Email = "123@mail.ru",
                Password = "123456"
            },
            new User
            {
                Id = Guid.NewGuid(),
                CounterAgentId = Guid.Parse("31518932-1c49-4397-8b2d-63bab308fd12"),
                Email = "124@mail.ru",
                Password = "Pudge"
            }
        ];
        
        foreach (var user in users) connection.Execute(insertQuery, user);
        
        return this;
    }
}