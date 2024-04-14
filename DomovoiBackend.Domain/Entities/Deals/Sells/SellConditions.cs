namespace DomovoiBackend.Domain.Entities.Deals.Sells;

/// <summary>
/// Условия продажи.
/// </summary>
public class SellConditions
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Цена.
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Тип.
    /// </summary>
    public string? Type { get; set; }
}