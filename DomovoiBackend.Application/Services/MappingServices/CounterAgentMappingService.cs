using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Mapping.Tools;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;
using DomovoiBackend.Application.Services.MappingServices.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents;

namespace DomovoiBackend.Application.Services.MappingServices;

/// <summary>
/// Сервис сопоставления контр-агентов.
/// </summary>
public class CounterAgentMappingService : ICounterAgentMappingService
{
    /// <summary>
    /// Словарь отображений контр-агентов.
    /// </summary>
    private static readonly Dictionary<Type, Func<IMapperBase, object, CounterAgent>> ToCounterAgentMapDictionary =
        MapCollector.GetToMappingsFromAssembly<CounterAgent>(Assembly.GetExecutingAssembly());
    
    /// <summary>
    /// Словарь отображений информация о контр-агенте.
    /// </summary>
    private static readonly Dictionary<Type, Func<IMapperBase, object, CounterAgentInformation>> ToCounterAgentInformationMapDictionary =
        MapCollector.GetFromMappingsFromAssembly<CounterAgentInformation>(Assembly.GetExecutingAssembly());

    /// <summary>
    /// Маппер.
    /// </summary>
    private readonly IMapper _mapper;
    
    public CounterAgentMappingService(IMapper mapper) => _mapper = mapper;

    public CounterAgent MapEntityFromInformation(CounterAgentInformation information)
    {
        var counterAgentInformationType = information.GetType();
        var counterAgent = ToCounterAgentMapDictionary[counterAgentInformationType](_mapper, information);
        return counterAgent;
    }

    public CounterAgentInformation MapInformationFromEntity(CounterAgent counterAgent)
    {
        var counterAgentType = counterAgent.GetType();
        var counterAgentInformation = ToCounterAgentInformationMapDictionary[counterAgentType](_mapper, counterAgent);
        return counterAgentInformation;
    }

    public CounterAgent MapEntityFromRequest(AddCounterAgentRequest request)
    {
        var requestType = request.GetType();
        var counterAgent = ToCounterAgentMapDictionary[requestType](_mapper, request);
        return counterAgent;
    }

    public CounterAgent MapEntityFromRequest(CounterAgentUpdateRequest request)
    {
        var requestType = request.GetType();
        var counterAgent = ToCounterAgentMapDictionary[requestType](_mapper, request);
        return counterAgent;
    }
}