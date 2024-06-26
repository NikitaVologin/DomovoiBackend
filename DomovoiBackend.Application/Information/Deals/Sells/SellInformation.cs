using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Sells;

namespace DomovoiBackend.Application.Information.Deals.Sells;

/// <summary>
/// Информация о продаже для запроса/ответа.
/// </summary>
public class SellInformation : DealInformation, IMapTwoSide<Sell>
{
    /// <summary>
    /// Условия продажи.
    /// </summary>
    public SellConditionInformation Conditions { get; set; }
}