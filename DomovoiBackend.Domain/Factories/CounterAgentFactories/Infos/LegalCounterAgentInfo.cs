using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

public record LegalCounterAgentInfo(
    string ContactNumber,
    string Name, 
    string Tin,
    string Trc) : BaseCounterAgentInfo(ContactNumber);