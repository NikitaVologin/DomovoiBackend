using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Sells;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

namespace DomovoiBackend.Application.Information.Deals.Sells;

/// <summary>
/// Информация о условиях продажи для запроса/ответа.
/// </summary>
public class SellConditionInformation : IMapTo<SellConditionInfo>, IMapFrom<SellConditions>
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