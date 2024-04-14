namespace DomovoiBackend.Domain.Entities.Deals.Sells;

public class Sell : Deal
{
    public virtual SellConditions? SellConditions { get; set; }
    public virtual SellFeatures? SellFeatures { get; set; }
}