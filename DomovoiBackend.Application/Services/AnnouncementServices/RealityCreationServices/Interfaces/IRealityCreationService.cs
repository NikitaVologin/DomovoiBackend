using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities;
using DomovoiBackend.Domain.Entities.Realities;

namespace DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices.Interfaces;

public interface IRealityCreationService
{
    Reality CreateReality(RealityRequestInfo request, Guid announcementId);
}