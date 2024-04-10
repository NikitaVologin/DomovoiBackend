using AutoMapper;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.RentInformation;
using DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.Abstraction;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

namespace DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.ConcreteServices;

public class RentMapDealService : ConcreteMapDealServiceBase<RentRequestInfo, RentInfo>
{
    public RentMapDealService(IMapper mapper) : base(mapper) { }
}