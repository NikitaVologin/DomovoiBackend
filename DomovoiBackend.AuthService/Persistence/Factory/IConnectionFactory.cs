using System.Data;

namespace DomovoiBackend.AuthService.Persistence.Factory;

public interface IConnectionFactory
{
    IDbConnection Create();
}