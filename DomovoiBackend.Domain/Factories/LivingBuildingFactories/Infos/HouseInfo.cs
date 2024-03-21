using DomovoiBackend.Domain.Entities.Realities.Areas;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.ValueTypes;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos;

public record HouseInfo(
    double Area,
    string Type,
    int Floor,
    int BuildYear,
    int RoomsCount,
    int FloorsCount,
    bool IsRenovated,
    bool IsHeating,
    bool IsAccess,
    bool IsInfrastructure,
    bool IsLandscaping,
    Bathroom Bathroom,
    Area HouseArea) : BaseLivingBuildingInfo(Area, Type, Floor);