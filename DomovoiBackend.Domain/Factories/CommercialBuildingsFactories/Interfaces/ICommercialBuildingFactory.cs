using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Interfaces;

public interface ICommercialBuildingFactory<in TIn, out TOut> : ICommercialBuildingFactory
    where TIn : BaseCommercialBuildingInfo
    where TOut : CommercialBuilding
{
    TOut Generate(TIn info);

    CommercialBuilding ICommercialBuildingFactory.Generate(BaseCommercialBuildingInfo info)
    {
        if (info is TIn specialInfo)
            return Generate(specialInfo);
        throw new ArgumentException();
    }
}

public interface ICommercialBuildingFactory
{
    CommercialBuilding Generate(BaseCommercialBuildingInfo info);
}