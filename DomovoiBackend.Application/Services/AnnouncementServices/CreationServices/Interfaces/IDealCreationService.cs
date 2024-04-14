using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Domain.Entities.Deals;

namespace DomovoiBackend.Application.Services.AnnouncementServices.CreationServices.Interfaces;

public interface IDealCreationService
{
    Deal CreateDealFromRequest(DealInformation information, Guid announcementId);

    DealInformation CreateInfoFromEntity(Deal entity);
}