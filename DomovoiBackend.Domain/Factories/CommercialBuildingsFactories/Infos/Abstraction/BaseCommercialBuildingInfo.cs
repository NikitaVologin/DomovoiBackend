using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

public record BaseCommercialBuildingInfo(
    double Area,
    string Type,
    int FloorsCount,
    bool Entry,
    string Address,
    bool InUse,
    bool IsAccess,
    Building Building) : BaseRealityInfo(Area, Type);