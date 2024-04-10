using AutoMapper;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.ConcreteServices;

public class LegalMapCounterAgentService : ConcreteMapCounterAgentServiceBase<LegalCounterAgentInformation, LegalCounterAgentInfo>
{
    public LegalMapCounterAgentService(IMapper mapper) : base(mapper) { }
}