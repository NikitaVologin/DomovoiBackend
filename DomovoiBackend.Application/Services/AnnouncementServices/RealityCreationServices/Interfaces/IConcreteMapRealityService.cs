using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities;
using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;

namespace DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices.Interfaces;

public interface IConcreteMapRealityService
{
    Type RealityInfoType => typeof(Reality);

    BaseRealityInfo MapReality(RealityRequestInfo request);
}