using AutoMapper;
using DomovoiBackend.Application.Models.CounterAgents.ConcreteRequests;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.ConcreteServices;

public class LegalMapCounterAgentService : ConcreteMapCounterAgentServiceBase<LegalCounterAgentRequestInfo, LegalCounterAgentInfo>
{
    public LegalMapCounterAgentService(IMapper mapper) : base(mapper) { }
}