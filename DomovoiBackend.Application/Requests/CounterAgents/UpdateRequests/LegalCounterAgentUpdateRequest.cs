using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;

namespace DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;

public class LegalCounterAgentUpdateRequest : CounterAgentUpdateRequest, IMapTwoSide<LegalCounterAgent>
{
    /// <summary>
    /// Название.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// ИНН.
    /// </summary>
    public string? Tin { get; set; }
}