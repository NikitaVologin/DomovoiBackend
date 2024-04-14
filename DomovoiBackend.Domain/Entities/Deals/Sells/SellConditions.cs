namespace DomovoiBackend.Domain.Entities.Deals.Sells;

public class SellConditions
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public string? Type { get; set; }
}