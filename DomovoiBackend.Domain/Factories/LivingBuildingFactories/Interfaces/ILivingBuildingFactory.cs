using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Interfaces;

public interface ILivingBuildingFactory<in TIn, out TOut>
    where TIn : BaseLivingBuildingInfo
    where TOut : LivingBuilding
{
    TOut Generate(TIn info);
}

public interface ILivingBuildingFactory
{
    LivingBuilding Generate(BaseLivingBuildingInfo info);
}