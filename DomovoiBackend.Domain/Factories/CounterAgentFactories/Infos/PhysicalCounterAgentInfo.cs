using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

public record PhysicalCounterAgentInfo(
    string ContactNumber,
    string FIO,
    string PassportData) : BaseCounterAgentInfo(ContactNumber);