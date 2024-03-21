using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

public record WarehouseBuildingInfo(
    double Area,
    string Type,
    int FloorsCount,
    bool Entry,
    string Address,
    bool InUse,
    bool IsAccess,
    Building Building,
    bool Infrastructure) : BaseCommercialBuildingInfo(Area, Type, FloorsCount, Entry, Address, InUse, IsAccess, Building);