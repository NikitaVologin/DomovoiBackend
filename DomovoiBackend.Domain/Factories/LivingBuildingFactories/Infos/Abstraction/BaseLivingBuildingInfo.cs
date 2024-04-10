using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;

public record BaseLivingBuildingInfo(
    double Area,
    string Type,
    int Floor); //: BaseRealityInfo(Area, Type);