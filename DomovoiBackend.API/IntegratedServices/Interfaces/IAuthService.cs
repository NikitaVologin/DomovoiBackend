namespace DomovoiBackend.API.IntegratedServices.Interfaces;

public interface IAuthService
{
    Task<Guid> CreateUser(Guid counterAgentId, string email, string password);
    Task<Guid> Login(string email, string password);
}