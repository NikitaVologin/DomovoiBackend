using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities.CommercialRealities.TypesRequest;

public class WarehouseRequestInfo : CommercialRealityRequestInfo, IMapTo<WarehouseBuildingInfo>
{
    public bool Infrastructure { get; set; } 
}