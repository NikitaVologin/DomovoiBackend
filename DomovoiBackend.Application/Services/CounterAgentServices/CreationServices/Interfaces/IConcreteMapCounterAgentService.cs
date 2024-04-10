using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos.Base;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;

public interface IConcreteMapCounterAgentService
{
    Type CounterAgentType => typeof(CounterAgentInformation);

    BaseCounterAgentInfo CreateCounterAgent(CounterAgentInformation information);
}