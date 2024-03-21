using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CounterAgentFactories.Interfaces;

public interface ICounterAgentFactory<in TIn, out TOut> : ICounterAgentFactory
    where TIn : BaseCounterAgentInfo
    where TOut : CounterAgent
{
    TOut Generate(TIn info);

    CounterAgent ICounterAgentFactory.Generate(BaseCounterAgentInfo info)
    {
        if (info is TIn specialInfo)
            return Generate(specialInfo);
        throw new ArgumentException();
    }
}

public interface ICounterAgentFactory
{
    CounterAgent Generate(BaseCounterAgentInfo info);
}