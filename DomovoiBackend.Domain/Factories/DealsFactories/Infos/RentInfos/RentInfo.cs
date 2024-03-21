using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

public record RentInfo(
    RentConditionInfo ConditionInfo,
    RentRulesInfo RulesInfo) : BaseDealInfo;