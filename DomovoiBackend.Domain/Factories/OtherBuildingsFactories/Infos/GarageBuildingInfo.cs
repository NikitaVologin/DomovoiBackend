using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos;

public record GarageBuildingInfo(
    double Area,
    string Type,
    string State,
    string GKSName,
    bool Access,
    bool Security,
    bool Electricity,
    bool Heating,
    bool WaterSupply,
    bool Infrastructure) : BaseOtherBuildingInfo(Area, Type);