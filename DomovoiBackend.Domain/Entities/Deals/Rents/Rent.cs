namespace DomovoiBackend.Domain.Entities.Deals.Rents;

/// <summary>
/// Аренда
/// </summary>
public class Rent : Deal
{
    /// <summary>
    /// Условия аренды.
    /// </summary>
    public virtual RentConditions? Conditions { get; set; }
}