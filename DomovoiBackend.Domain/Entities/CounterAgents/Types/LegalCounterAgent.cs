namespace DomovoiBackend.Domain.Entities.CounterAgents.Types;

/// <summary>
/// Юридический  контр-агент.
/// </summary>
public class LegalCounterAgent : CounterAgent
{
    /// <summary>
    /// Название.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// ИНН.
    /// </summary>
    public string? Tin { get; set; }
    
    /// <summary>
    /// КПП.
    /// </summary>
    public string? Trc { get; set; }
}