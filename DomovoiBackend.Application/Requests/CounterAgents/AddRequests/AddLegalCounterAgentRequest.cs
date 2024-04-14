using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

namespace DomovoiBackend.Application.Requests.CounterAgents.AddRequests;

public class AddLegalCounterAgentRequest : AddCounterAgentRequest, IMapTo<LegalCounterAgentInfo> { }