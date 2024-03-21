using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos;

public record HousePartInfo(
    double Area,
    string Type,
    int Floor,
    int Part,
    House House) : BaseLivingBuildingInfo(Area, Type, Floor);