using Dapper;
using DomovoiBackend.AuthService.Models;
using DomovoiBackend.AuthService.Persistence.Factory;

namespace DomovoiBackend.AuthService.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConnectionFactory _factory;

    public UserRepository(IConnectionFactory factory) => _factory = factory;
    
    public async Task<User> GetUserAsync(string email, string password)
    {
        using var connection = _factory.Create();
        var user = await connection.QuerySingleOrDefaultAsync<User>(@"SELECT * FROM Users 
                                                                        WHERE Email = @Email AND Password = @Password",
            new { Email = email, Password = password });
        if (user == null) throw new NullReferenceException();
        return user;
    }

    public async Task<Guid> AddUserAsync(User user)
    {
        using var connection = _factory.Create();
        var id = await connection.QuerySingleAsync<Guid>(@"INSERT INTO Users (Id, CounterAgentId, Email, Password)
                                                                VALUES (@Id, @CounterAgentId, @Email, @Password);
                                                                SELECT last_insert_rowid();", user);
        return id;
    }

    public async Task<bool> IsUserExistAsync(string email)
    {
        using var connection = _factory.Create();
        var user = await connection.QuerySingleOrDefaultAsync<User>(@"SELECT * FROM Users 
                                                                        WHERE Email = @Email",
            new { Email = email });
        return user == null;
    }
}