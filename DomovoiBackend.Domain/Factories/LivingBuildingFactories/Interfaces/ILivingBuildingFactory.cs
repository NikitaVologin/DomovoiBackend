using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Interfaces;

public interface ILivingBuildingFactory<in TIn, out TOut> : ILivingBuildingFactory
    where TIn : BaseLivingBuildingInfo
    where TOut : LivingBuilding
{
    TOut Generate(TIn info);

    LivingBuilding ILivingBuildingFactory.Generate(BaseLivingBuildingInfo info)
    {
        if (info is TIn specialInfo)
            return Generate(specialInfo);
        throw new ArgumentException();
    }
}

public interface ILivingBuildingFactory
{
    LivingBuilding Generate(BaseLivingBuildingInfo info);
}