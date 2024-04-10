using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

public class RentInfo : BaseDealInfo
{
    public RentConditionInfo RentConditionInfo { get; init; }
    public RentRulesInfo RentRulesInfo { get; init; }
}