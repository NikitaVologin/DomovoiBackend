namespace DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;

public class CounterAgentUpdateRequest
{
    /// <summary>
    /// Номер для контакта.
    /// </summary>
    public string? ContactNumber { get; set; }
    
    /// <summary>
    /// Email.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string? Password { get; set; }
}