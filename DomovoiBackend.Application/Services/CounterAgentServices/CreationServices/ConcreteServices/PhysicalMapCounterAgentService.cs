using AutoMapper;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.ConcreteServices;

public class PhysicalMapCounterAgentService : ConcreteMapCounterAgentServiceBase<PhysicalCounterAgentInformation, PhysicalCounterAgentInfo>
{
    public PhysicalMapCounterAgentService(IMapper mapper) : base(mapper) { }
}