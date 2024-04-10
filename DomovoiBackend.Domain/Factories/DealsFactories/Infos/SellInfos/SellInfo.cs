using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

public class SellInfo : BaseDealInfo
{
    public SellConditionInfo SellConditionInfo { get; init; }
    public SellFeaturesInfo SellFeaturesInfo { get; init; }
}