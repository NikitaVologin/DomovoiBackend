using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities.CommercialRealities.TypesRequest;

public class ProductionRequestInfo : CommercialRealityRequestInfo, IMapTo<ProductionBuildingInfo>
{
    public bool Infrastructure { get; set; }
    public int RoomsQuantity { get; set; }
}