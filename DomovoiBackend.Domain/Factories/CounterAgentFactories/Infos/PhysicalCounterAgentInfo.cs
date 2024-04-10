using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

public class PhysicalCounterAgentInfo : BaseCounterAgentInfo
{
    public string? FIO { get; init; }
    public string? PassportData { get; init; } 
}