using DomovoiBackend.Application.Mapping.Interfaces;

namespace DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;

/// <summary>
/// Базовый запрос создания контр-агента.
/// </summary>
public class AddCounterAgentRequest
{
    /// <summary>
    /// Email.
    /// </summary>
    public string Email { get; set; } = null!;
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = null!;
}