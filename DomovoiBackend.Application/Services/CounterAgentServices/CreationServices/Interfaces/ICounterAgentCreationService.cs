using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos.Base;
using DomovoiBackend.Domain.Entities.CounterAgents;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;

public interface ICounterAgentCreationService
{
    CounterAgent CreateCounterAgent(CounterAgentInformation info);
}