using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Interfaces;

public interface ICommercialBuildingFactory<in TIn, out TOut>
    where TIn : BaseCommercialBuildingInfo
    where TOut : CommercialBuilding
{
    TOut Generate(TIn info);
}

public interface ICommercialBuildingFactory
{
    CommercialBuilding Generate(BaseCommercialBuildingInfo info);
}