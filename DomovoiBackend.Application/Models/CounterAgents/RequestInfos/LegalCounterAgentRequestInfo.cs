using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

namespace DomovoiBackend.Application.Models.CounterAgents.ConcreteRequests;

public class LegalCounterAgentRequestInfo : CounterAgentRequestInfo, IMapTo<Domain.Factories.CounterAgentFactories.Infos.LegalCounterAgentInfo>
{
    public string? Name { get; set; }
    public string? Tin { get; set; }
    public string? Trc { get; set; }    
}