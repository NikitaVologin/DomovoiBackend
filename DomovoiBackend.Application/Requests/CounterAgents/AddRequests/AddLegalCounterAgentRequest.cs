using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;

namespace DomovoiBackend.Application.Requests.CounterAgents.AddRequests;

/// <summary>
/// Запрос создания юр. контр-агента.
/// </summary>
public class AddLegalCounterAgentRequest : AddCounterAgentRequest, IMapTwoSide<LegalCounterAgent> { }