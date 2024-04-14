using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Rents;
using DomovoiBackend.Domain.Entities.Deals.Types.Rent;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

namespace DomovoiBackend.Application.Information.Deals.Rents;

/// <summary>
/// Информация о аренде для запроса/ответа.
/// </summary>
public class RentInformation : DealInformation, IMapTo<RentInfo>, IMapFrom<Rent>
{
    /// <summary>
    /// Условия аренды.
    /// </summary>
    public RentConditionInfo RentConditions { get; set; }
    
    /// <summary>
    /// Правила аренды.
    /// </summary>
    public RentRulesInformation RentRules { get; set; }
}