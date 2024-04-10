using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

public class WarehouseBuildingInfo : BaseCommercialBuildingInfo
{
    public bool Infrastructure { get; init; }
}