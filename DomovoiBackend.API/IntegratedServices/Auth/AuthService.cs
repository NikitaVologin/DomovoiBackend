using DomovoiBackend.API.IntegratedServices.Interfaces;

namespace DomovoiBackend.API.IntegratedServices.Auth;

public class AuthService : IAuthService
{
    private readonly HttpClient _client;

    public AuthService(HttpClient client) => _client = client;
    
    public async Task<Guid> CreateUser(Guid counterAgentId, string email, string password)
    {
        var response = await _client.PostAsJsonAsync("Registration", new { counterAgentId, email, password });
        return await response.Content.ReadFromJsonAsync<Guid>();
    }

    public async Task<Guid> Login(string email, string password)
    {
        var response = await _client.PostAsJsonAsync("Login", new { email, password });
        return await response.Content.ReadFromJsonAsync<Guid>();
    }
}