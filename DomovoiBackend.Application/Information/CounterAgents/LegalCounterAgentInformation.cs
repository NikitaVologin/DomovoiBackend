using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;

namespace DomovoiBackend.Application.Information.CounterAgents;

/// <summary>
/// Информация о юридическом контр-агенте для запроса/ответа.
/// </summary>
public class LegalCounterAgentInformation : CounterAgentInformation, IMapTwoSide<LegalCounterAgent>
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