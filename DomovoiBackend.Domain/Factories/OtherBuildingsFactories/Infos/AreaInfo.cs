using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos;

public record AreaInfo(
    double Area,
    string Type,
    bool Electricity,
    bool WaterSupply,
    bool Gas,
    bool Sewage) : BaseOtherBuildingInfo(Area, Type);