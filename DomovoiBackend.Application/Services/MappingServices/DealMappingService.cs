using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Application.Mapping.Tools;
using DomovoiBackend.Application.Services.MappingServices.Interfaces;
using DomovoiBackend.Domain.Entities.Deals;

namespace DomovoiBackend.Application.Services.MappingServices;

/// <summary>
/// Сервис сопоставления сделок.
/// </summary>
public class DealMappingService : IDealMappingService
{
    /// <summary>
    /// Словарь отображений сделок.
    /// </summary>
    private static readonly Dictionary<Type, Func<IMapperBase, object, Deal>> ToDealMapDictionary =
        MapCollector.GetToMappingsFromAssembly<Deal>(Assembly.GetExecutingAssembly());
    
    /// <summary>
    /// Словарь отображений информация о сделке.
    /// </summary>
    private static readonly Dictionary<Type, Func<IMapperBase, object, DealInformation>> ToDealInformationMapDictionary =
        MapCollector.GetFromMappingsFromAssembly<DealInformation>(Assembly.GetExecutingAssembly());

    /// <summary>
    /// Маппер.
    /// </summary>
    private readonly IMapper _mapper;
    
    public DealMappingService(IMapper mapper) => _mapper = mapper;

    public Deal MapEntityFromInformation(DealInformation information)
    {
        var dealInformationType = information.GetType();
        var deal = ToDealMapDictionary[dealInformationType](_mapper, information);
        return deal;
    }

    public DealInformation MapInformationFromEntity(Deal deal)
    {
        var dealType = deal.GetType();
        var dealInformation = ToDealInformationMapDictionary[dealType](_mapper, deal);
        return dealInformation;
    }
}