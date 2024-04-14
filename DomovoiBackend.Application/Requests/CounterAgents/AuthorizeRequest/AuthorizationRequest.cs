namespace DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;

/// <summary>
/// Запрос на авторизацию.
/// </summary>
public class AuthorizationRequest
{
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = null!;
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = null!;
}