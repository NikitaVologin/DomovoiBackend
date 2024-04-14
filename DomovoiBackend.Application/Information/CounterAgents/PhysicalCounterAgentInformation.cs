using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;

namespace DomovoiBackend.Application.Information.CounterAgents;

/// <summary>
/// Информация о физическом контр-агента для запроса/ответа.
/// </summary>
public class PhysicalCounterAgentInformation : CounterAgentInformation, IMapFrom<PhysicalCounterAgent>
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