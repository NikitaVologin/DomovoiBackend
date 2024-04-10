using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;

namespace DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos.Abstraction;

public record BaseOtherBuildingInfo(
    double Area,
    string Type); //: BaseRealityInfo(Area, Type);