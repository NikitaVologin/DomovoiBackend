using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

namespace DomovoiBackend.Application.Models.CounterAgents.ConcreteRequests;

public class PhysicalCounterAgentRequestInfo : CounterAgentRequestInfo, IMapTo<Domain.Factories.CounterAgentFactories.Infos.PhysicalCounterAgentInfo>
{
    public string? FIO { get; set; }
    public string? PassportData { get; set; }
}