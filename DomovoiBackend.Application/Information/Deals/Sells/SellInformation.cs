using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Sells;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

namespace DomovoiBackend.Application.Information.Deals.Sells;

/// <summary>
/// Информация о продаже для запроса/ответа.
/// </summary>
public class SellInformation : DealInformation, IMapTo<SellInfo>, IMapFrom<Sell>
{
    /// <summary>
    /// Условия продажи.
    /// </summary>
    public SellConditionInformation SellConditions { get; set; }
    
    /// <summary>
    /// Характеристика продажи.
    /// </summary>
    public SellFeaturesInformation SellFeatures { get; set; }
}