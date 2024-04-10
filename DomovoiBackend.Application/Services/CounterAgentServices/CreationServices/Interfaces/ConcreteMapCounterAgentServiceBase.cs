using AutoMapper;
using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;

public class ConcreteMapCounterAgentServiceBase<TRequestInfo, TInfo> : IConcreteMapCounterAgentService
    where TRequestInfo : CounterAgentRequestInfo
    where TInfo : BaseCounterAgentInfo
{
    private readonly IMapper _mapper;

    protected ConcreteMapCounterAgentServiceBase(IMapper mapper) => _mapper = mapper;

    private TInfo CreateCounterAgent(TRequestInfo requestInfo) =>
        _mapper.Map<TInfo>(requestInfo);

    BaseCounterAgentInfo IConcreteMapCounterAgentService.CreateCounterAgent(CounterAgentRequestInfo info)
    {
        if (info is TRequestInfo requestInfo)
        {
            return CreateCounterAgent(requestInfo);
        }

        throw new ArgumentException();
    }
}