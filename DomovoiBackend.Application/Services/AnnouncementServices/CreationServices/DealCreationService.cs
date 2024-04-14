using System.Reflection;
using AutoMapper;
using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Application.Mapping.Tools;
using DomovoiBackend.Application.Services.AnnouncementServices.CreationServices.Interfaces;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Factories.DealsFactories;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Application.Services.AnnouncementServices.CreationServices;

public class DealCreationService : IDealCreationService
{
    private static readonly Dictionary<Type, Func<IMapperBase, object, BaseDealInfo>> ToDealInfoMap =
        MapCollector.GetToMappingsFromAssembly<BaseDealInfo>(Assembly.GetExecutingAssembly());

    private static readonly Dictionary<Type, Func<IMapperBase, object, DealInformation>> ToDealInformationMap =
        MapCollector.GetFromMappingsFromAssembly<DealInformation>(Assembly.GetExecutingAssembly());

    private readonly IMapper _mapper;

    public DealCreationService(IMapper mapper) => _mapper = mapper;
    
    public Deal CreateDealFromRequest(DealInformation info, Guid announcementId)
    {
        var dealFactory = new BaseDealFactory();
        var dealRequestInfo = info.GetType();
        var dealInfo = ToDealInfoMap[dealRequestInfo](_mapper, info);
        var deal = dealFactory.Generate(dealInfo, announcementId);
        return deal;
    }
    
    public DealInformation CreateInfoFromEntity(Deal deal)
    {
        var counterAgentTypeInfo = deal.GetType();
        var counterAgentInformation = ToDealInformationMap[counterAgentTypeInfo](_mapper, deal);
        return counterAgentInformation;
    }
}