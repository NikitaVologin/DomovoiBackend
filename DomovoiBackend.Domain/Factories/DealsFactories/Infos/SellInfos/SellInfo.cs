using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

public class SellInfo : BaseDealInfo
{
    public SellConditionInfo SellConditions { get; init; }
    public SellFeaturesInfo SellFeatures { get; init; }
}