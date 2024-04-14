using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

public class RentInfo : BaseDealInfo
{
    public RentConditionInfo RentConditions { get; init; }
    public RentRulesInfo RentRules { get; init; }
}