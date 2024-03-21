using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

public record SellInfo(
    SellConditionInfo SellConditionInfo,
    SellFeaturesInfo SellFeaturesInfo) : BaseDealInfo;