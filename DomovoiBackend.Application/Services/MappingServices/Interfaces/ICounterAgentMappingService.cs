using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;
using DomovoiBackend.Domain.Entities.CounterAgents;

namespace DomovoiBackend.Application.Services.MappingServices.Interfaces;

/// <summary>
/// Интерфейс сервиса сопоставления контр-агентов.
/// </summary>
public interface ICounterAgentMappingService
{
    /// <summary>
    /// Создать контр-агента из информации.
    /// </summary>
    /// <param name="information">Информация о контр-агенте.</param>
    /// <returns>Контр-агент.</returns>
    CounterAgent MapEntityFromInformation(CounterAgentInformation information);
    
    /// <summary>
    /// Создать информацию из контр-агента.
    /// </summary>
    /// <param name="counterAgent">Контр-агент.</param>
    /// <returns>Информация о контр-агенте.</returns>
    CounterAgentInformation MapInformationFromEntity(CounterAgent counterAgent);
    
    /// <summary>
    /// Создать контр-агента из запроса.
    /// </summary>
    /// <param name="request">Контр-агент.</param>
    /// <returns>Информация о контр-агенте.</returns>
    CounterAgent MapEntityFromRequest(AddCounterAgentRequest request);
    
    /// <summary>
    /// Создать контр-агента из запроса.
    /// </summary>
    /// <param name="request">Контр-агент.</param>
    /// <returns>Информация о контр-агенте.</returns>
    CounterAgent MapEntityFromRequest(CounterAgentUpdateRequest request);
}