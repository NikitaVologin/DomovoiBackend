using DomovoiBackend.Application.Information.Realities;
using DomovoiBackend.Domain.Entities.Realities;

namespace DomovoiBackend.Application.Services.AnnouncementServices.CreationServices.Interfaces;

public interface IRealityCreationService
{
    Reality CreateRealityFromRequest(RealityInformation information, Guid announcementId);

    RealityInformation CreateInfoFromEntity(Reality reality);
}