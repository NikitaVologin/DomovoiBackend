using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;

public interface IConcreteMapCounterAgentService
{
    Type CounterAgentType => typeof(CounterAgentRequestInfo);

    BaseCounterAgentInfo CreateCounterAgent(CounterAgentRequestInfo requestInfo);
}