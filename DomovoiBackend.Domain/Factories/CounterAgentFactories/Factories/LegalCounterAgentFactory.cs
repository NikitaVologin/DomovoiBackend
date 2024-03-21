using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.CounterAgentFactories.Factories;

public class LegalCounterAgentFactory : ICounterAgentFactory<LegalCounterAgentInfo, LegalCounterAgent>
{
    public LegalCounterAgent Generate(LegalCounterAgentInfo info)
    {
        return new LegalCounterAgent
        {
            Id = Guid.NewGuid(),
            ContactNumber = info.ContactNumber,
            Name = info.Name,
            Tin = info.Tin,
            Trc = info.Trc
        };
    }
}