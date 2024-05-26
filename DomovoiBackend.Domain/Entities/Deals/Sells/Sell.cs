namespace DomovoiBackend.Domain.Entities.Deals.Sells;

/// <summary>
/// Продажа
/// </summary>
public class Sell : Deal
{
    /// <summary>
    /// Условия продажи.
    /// </summary>
    public virtual SellConditions? Conditions { get; set; }

    public override void Update(Deal entity)
    {
        if (entity is not Sell sell) return;
        Price = entity.Price;
        Conditions!.Update(sell.Conditions!);
    }
}