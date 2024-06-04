namespace DomovoiBackend.Application.Information.CounterAgents;


/// <summary>
/// Общая информация о контр-агенте для запроса/ответа.
/// </summary>
public class CounterAgentInformation
{
    /// <summary>
    /// Id Контрагента.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Номер для контакта.
    /// </summary>
    public string? ContactNumber { get; set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }
}