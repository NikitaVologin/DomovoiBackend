using AutoMapper;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities.CommercialRealities.TypesRequest;
using DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices.Abstraction;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

namespace DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices.ConcreteServices;

public class OfficeService : ConcreteMapRealityServiceBase<OfficeRequestInfo, OfficeBuildingInfo>
{
    public OfficeService(IMapper mapper) : base(mapper) { }
}