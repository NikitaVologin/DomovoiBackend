using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;

namespace DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;

public class PhysicalCounterAgentUpdateRequest : CounterAgentUpdateRequest, IMapTwoSide<PhysicalCounterAgent>
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