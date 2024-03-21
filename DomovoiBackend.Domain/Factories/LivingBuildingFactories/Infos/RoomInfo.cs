using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos;

public record RoomInfo(
    double Area,
    string Type,
    int Floor,
    int NeighboursCount,
    Flat Flat) : BaseLivingBuildingInfo(Area, Type, Floor);