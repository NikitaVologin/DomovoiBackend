using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;

namespace DomovoiBackend.Application.Information.CounterAgents;

/// <summary>
/// Информация о физическом контр-агента для запроса/ответа.
/// </summary>
public class PhysicalCounterAgentInformation : CounterAgentInformation, IMapTwoSide<PhysicalCounterAgent>
{
    /// <summary>
    /// ФИО.
    /// </summary>
    public string? FIO { get; set; }
}