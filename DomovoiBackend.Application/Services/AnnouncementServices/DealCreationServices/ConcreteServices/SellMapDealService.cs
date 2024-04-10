using AutoMapper;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.SellInformation;
using DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.Abstraction;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

namespace DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.ConcreteServices;

public class SellMapDealService : ConcreteMapDealServiceBase<SellRequestInfo, SellInfo>
{
    public SellMapDealService(IMapper mapper) : base(mapper) { }
}