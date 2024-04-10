using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals;
using DomovoiBackend.Domain.Entities.Deals;

namespace DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.Interfaces;

public interface IDealCreationService
{
    Deal CreateDeal(DealRequestInfo requestInfo, Guid announcementId);
}