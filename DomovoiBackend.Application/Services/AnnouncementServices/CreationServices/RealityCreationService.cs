using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Information.Realities;
using DomovoiBackend.Application.Mapping.Tools;
using DomovoiBackend.Application.Services.AnnouncementServices.CreationServices.Interfaces;
using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;
using DomovoiBackend.Domain.Factories.RealityFactories.Factories;

namespace DomovoiBackend.Application.Services.AnnouncementServices.CreationServices;

public class RealityCreationService : IRealityCreationService
{
    private static readonly Dictionary<Type, Func<IMapperBase, object, BaseRealityInfo>> ToRealityInfoMap =
        MapCollector.GetToMappingsFromAssembly<BaseRealityInfo>(Assembly.GetExecutingAssembly());

    private static readonly Dictionary<Type, Func<IMapperBase, object, RealityInformation>> ToDealInformationMap =
        MapCollector.GetFromMappingsFromAssembly<RealityInformation>(Assembly.GetExecutingAssembly());

    private readonly IMapper _mapper;

    public RealityCreationService(IMapper mapper) => _mapper = mapper;
    
    public Reality CreateRealityFromRequest(RealityInformation info, Guid announcementId)
    {
        var realityFactory = new RealityFactory();
        var infoRequestType = info.GetType();
        var realityInfo = ToRealityInfoMap[infoRequestType](_mapper, info);
        var reality = realityFactory.GenerateReality(realityInfo, announcementId);
        return reality;
    }
    
    public RealityInformation CreateInfoFromEntity(Reality counterAgent)
    {
        var counterAgentTypeInfo = counterAgent.GetType();
        var counterAgentInformation = ToDealInformationMap[counterAgentTypeInfo](_mapper, counterAgent);
        return counterAgentInformation;
    }
}