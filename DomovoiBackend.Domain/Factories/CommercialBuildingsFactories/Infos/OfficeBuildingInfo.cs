using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

public class OfficeBuildingInfo : BaseCommercialBuildingInfo
{
    public string Name { get; init; }
    public int RoomsCount { get; init; }
}