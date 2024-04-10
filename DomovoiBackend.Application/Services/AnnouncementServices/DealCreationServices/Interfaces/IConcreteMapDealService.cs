using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.Interfaces;

public interface IConcreteMapDealService
{
    Type CounterAgentType => typeof(DealRequestInfo);

    BaseDealInfo MapDealInfo(DealRequestInfo request);
}