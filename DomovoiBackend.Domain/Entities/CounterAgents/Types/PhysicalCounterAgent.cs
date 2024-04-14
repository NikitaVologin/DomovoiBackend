namespace DomovoiBackend.Domain.Entities.CounterAgents.Types;

/// <summary>
/// Физический контр-агент.
/// </summary>
public class PhysicalCounterAgent : CounterAgent
{
    /// <summary>
    /// ФИО.
    /// </summary>
    public string? FIO { get; set; }
    
    /// <summary>
    /// Пасспортные данные.
    /// </summary>
    public string? PassportData { get; set; }
}