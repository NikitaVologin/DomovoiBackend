using System.Data;
using Microsoft.Data.Sqlite;

namespace DomovoiBackend.AuthService.Persistence.Factory;

public class SqliteConnectionFactory : IConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqliteConnectionFactory(IConfiguration configuration) => _configuration = configuration;
    
    public IDbConnection Create()
    {
        var connectionString = _configuration.GetConnectionString("UsersConnection");
        if (connectionString == null) throw new NullReferenceException(connectionString);
        return new SqliteConnection(connectionString);
    }
}