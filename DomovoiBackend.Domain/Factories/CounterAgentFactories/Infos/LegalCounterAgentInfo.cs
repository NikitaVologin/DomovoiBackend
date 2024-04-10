using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

public class LegalCounterAgentInfo : BaseCounterAgentInfo
{
    public string Name { get; init; }
    public string Tin { get; init; }
    public string Trc { get; init; }
}