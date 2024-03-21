using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

public record OfficeBuildingInfo(
    double Area,
    string Type,
    int FloorsCount,
    bool Entry,
    string Address,
    bool InUse,
    bool IsAccess,
    string Name,
    int RoomsCount,
    Building Building) : BaseCommercialBuildingInfo(Area, Type, FloorsCount, Entry, Address, InUse, IsAccess, Building);