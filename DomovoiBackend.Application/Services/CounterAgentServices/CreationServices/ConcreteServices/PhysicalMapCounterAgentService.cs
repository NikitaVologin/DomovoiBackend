using AutoMapper;
using DomovoiBackend.Application.Models.CounterAgents.ConcreteRequests;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.ConcreteServices;

public class PhysicalMapCounterAgentService : ConcreteMapCounterAgentServiceBase<PhysicalCounterAgentRequestInfo, PhysicalCounterAgentInfo>
{
    public PhysicalMapCounterAgentService(IMapper mapper) : base(mapper) { }
}