using AutoMapper;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals;
using DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.Interfaces;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.Abstraction;

public abstract class ConcreteMapDealServiceBase<TRequestInfo, TInfo> : IConcreteMapDealService
    where TRequestInfo : DealRequestInfo
    where TInfo : BaseDealInfo
{
    private readonly IMapper _mapper;

    protected ConcreteMapDealServiceBase(IMapper mapper) => _mapper = mapper;

    private TInfo CreateDeal(TRequestInfo requestInfo) =>
        _mapper.Map<TInfo>(requestInfo);

    BaseDealInfo IConcreteMapDealService.MapDealInfo(DealRequestInfo request)
    {
        if (request is TRequestInfo requestInfo)
        {
            return CreateDeal(requestInfo);
        }

        throw new ArgumentException();
    }
}