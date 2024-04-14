using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Sells;

namespace DomovoiBackend.Application.Information.Deals.Sells;

/// <summary>
/// Информация о условиях продажи для запроса/ответа.
/// </summary>
public class SellConditionInformation : IMapTwoSide<SellConditions>
{
    /// <summary>
    /// Цена.
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Тип сделки.
    /// </summary>
    public string Type { get; set; } = null!;
}