namespace DomovoiBackend.Domain.Entities.Deals.Sells;

/// <summary>
/// Продажа
/// </summary>
public class Sell : Deal
{
    /// <summary>
    /// Условия продажи.
    /// </summary>
    public virtual SellConditions? SellConditions { get; set; }
    
    /// <summary>
    /// Описание продажи.
    /// </summary>
    public virtual SellFeatures? SellFeatures { get; set; }
}