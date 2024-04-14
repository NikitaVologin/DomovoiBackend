namespace DomovoiBackend.Domain.Entities.Deals.Rents;

/// <summary>
/// Аренда
/// </summary>
public class Rent : Deal
{
    /// <summary>
    /// Условия аренды.
    /// </summary>
    public virtual RentConditions? RentConditions { get; set; }
    
    /// <summary>
    /// Правила аренды.
    /// </summary>
    public virtual RentRules? RentRules { get; set; }
}