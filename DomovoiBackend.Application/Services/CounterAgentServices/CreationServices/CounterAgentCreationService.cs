using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Application.Mapping.Tools;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Factories.CounterAgentFactories;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices;

public class CounterAgentCreationService
{
    private static readonly Dictionary<Type, Func<IMapperBase, object, BaseCounterAgentInfo>> ToDealInfoMap =
        MapCollector.GetToMappingsFromAssembly<BaseCounterAgentInfo>(Assembly.GetExecutingAssembly());
    
    private static readonly Dictionary<Type, Func<IMapperBase, object, CounterAgentInformation>> ToDealInformationMap =
        MapCollector.GetFromMappingsFromAssembly<CounterAgentInformation>(Assembly.GetExecutingAssembly());

    private readonly IMapper _mapper;

    public CounterAgentCreationService(IMapper mapper) => _mapper = mapper;
    
    public CounterAgent CreateDealFromRequest(AddCounterAgentRequest info)
    {
        var counterAgentFactory = new BaseCounterAgentFactory();
        var counterAgentTypeInfo = info.GetType();
        var counterAgentInfo = ToDealInfoMap[counterAgentTypeInfo](_mapper, info);
        var counterAgent = counterAgentFactory.Generate(counterAgentInfo);
        return counterAgent;
    }

    public CounterAgentInformation CreateInfoFromEntity(CounterAgent counterAgent)
    {
        var counterAgentTypeInfo = counterAgent.GetType();
        var counterAgentInformation = ToDealInformationMap[counterAgentTypeInfo](_mapper, counterAgent);
        return counterAgentInformation;
    }
}