using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CounterAgentFactories.Interfaces;

public interface ICounterAgentFactory<in TIn, out TOut>
    where TIn : BaseCounterAgentInfo
    where TOut : CounterAgent
{
    TOut Generate(TIn info);
}

public interface ICounterAgentFactory
{
    CounterAgent Generate(BaseCounterAgentInfo info);
}