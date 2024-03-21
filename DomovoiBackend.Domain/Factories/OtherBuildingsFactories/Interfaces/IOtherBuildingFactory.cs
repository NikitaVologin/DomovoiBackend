using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Interfaces;

public interface IOtherBuildingFactory<in TIn, out TOut> : IOtherBuildingFactory
    where TIn : BaseOtherBuildingInfo
    where TOut : Reality
{
    TOut Generate(TIn info);

    Reality IOtherBuildingFactory.Generate(BaseOtherBuildingInfo info)
    {
        if (info is TIn specialInfo)
            return Generate(specialInfo);
        throw new ArgumentException();
    }
}

public interface IOtherBuildingFactory
{
    Reality Generate(BaseOtherBuildingInfo info);
}