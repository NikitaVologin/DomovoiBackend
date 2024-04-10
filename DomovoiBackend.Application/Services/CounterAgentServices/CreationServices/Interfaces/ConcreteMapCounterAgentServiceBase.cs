using AutoMapper;
using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos.Base;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;

public class ConcreteMapCounterAgentServiceBase<TRequestInfo, TInfo> : IConcreteMapCounterAgentService
    where TRequestInfo : CounterAgentInformation
    where TInfo : BaseCounterAgentInfo
{
    private readonly IMapper _mapper;

    protected ConcreteMapCounterAgentServiceBase(IMapper mapper) => _mapper = mapper;

    private TInfo CreateCounterAgent(TRequestInfo requestInfo) =>
        _mapper.Map<TInfo>(requestInfo);

    BaseCounterAgentInfo IConcreteMapCounterAgentService.CreateCounterAgent(CounterAgentInformation info)
    {
        if (info is TRequestInfo requestInfo)
        {
            return CreateCounterAgent(requestInfo);
        }

        throw new ArgumentException();
    }
}