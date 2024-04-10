using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

public class BaseCommercialBuildingInfo : BaseRealityInfo
{
    public int FloorsCount { get; init; }
    public bool Entry { get; init; }
    public string Address { get; init; }
    public bool InUse { get; init; } 
    public bool IsAccess { get; init; } 
    public Building Building { get; init; } 
}