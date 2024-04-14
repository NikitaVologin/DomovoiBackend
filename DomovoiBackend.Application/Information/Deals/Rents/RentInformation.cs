using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Rents;

namespace DomovoiBackend.Application.Information.Deals.Rents;

/// <summary>
/// Информация о аренде для запроса/ответа.
/// </summary>
public class RentInformation : DealInformation, IMapTwoSide<Rent>
{
    /// <summary>
    /// Условия аренды.
    /// </summary>
    public RentConditionInformation RentConditions { get; set; }
    
    /// <summary>
    /// Правила аренды.
    /// </summary>
    public RentRulesInformation RentRules { get; set; }
}