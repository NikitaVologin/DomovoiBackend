using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.CounterAgentFactories.Factories;

public class PhysicalCounterAgentFactory : ICounterAgentFactory<PhysicalCounterAgentInfo, PhysicalCounterAgent>
{
    public PhysicalCounterAgent Generate(PhysicalCounterAgentInfo info)
    {
        return new PhysicalCounterAgent
        {
            Id = Guid.NewGuid(),
            ContactNumber = info.ContactNumber,
            FIO = info.FIO,
            PassportData = info.PassportData
        };
    }
}