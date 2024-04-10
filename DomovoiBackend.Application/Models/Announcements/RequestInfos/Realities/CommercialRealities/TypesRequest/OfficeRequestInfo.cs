using AutoMapper;
using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities.CommercialRealities.TypesRequest;

public class OfficeRequestInfo : CommercialRealityRequestInfo, IMapTo<OfficeBuildingInfo>
{
    public string? Name { get; set; }
    public int RoomsCount { get; set; }
}