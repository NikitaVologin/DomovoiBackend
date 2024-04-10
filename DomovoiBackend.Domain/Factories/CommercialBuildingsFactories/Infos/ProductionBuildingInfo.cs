using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

public class ProductionBuildingInfo : BaseCommercialBuildingInfo
{
    public bool Infrastructure { get; init; }
    public int RoomsQuantity { get; init; }
}