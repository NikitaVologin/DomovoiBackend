using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Information.Realities;
using DomovoiBackend.Application.Mapping.Tools;
using DomovoiBackend.Application.Services.MappingServices.Interfaces;
using DomovoiBackend.Domain.Entities.Realities;

namespace DomovoiBackend.Application.Services.MappingServices;

/// <summary>
/// Сервис сопоставления контр-агентов.
/// </summary>
public class RealityMappingService : IRealityMappingService
{
    /// <summary>
    /// Словарь отображений контр-агентов.
    /// </summary>
    private static readonly Dictionary<Type, Func<IMapperBase, object, Reality>> ToRealityMapDictionary =
        MapCollector.GetToMappingsFromAssembly<Reality>(Assembly.GetExecutingAssembly());
    
    /// <summary>
    /// Словарь отображений информация о контр-агенте.
    /// </summary>
    private static readonly Dictionary<Type, Func<IMapperBase, object, RealityInformation>> ToRealityInformationMapDictionary =
        MapCollector.GetFromMappingsFromAssembly<RealityInformation>(Assembly.GetExecutingAssembly());

    /// <summary>
    /// Маппер.
    /// </summary>
    private readonly IMapper _mapper;
    
    public RealityMappingService(IMapper mapper) => _mapper = mapper;
    
    public Reality MapEntityFromInformation(RealityInformation information)
    {
        var realityInformationType = information.GetType();
        var reality = ToRealityMapDictionary[realityInformationType](_mapper, information);
        return reality;
    }

    public RealityInformation MapInformationFromEntity(Reality reality)
    {
        var realityType = reality.GetType();
        var realityInformation = ToRealityInformationMapDictionary[realityType](_mapper, reality);
        return realityInformation;
    }
}