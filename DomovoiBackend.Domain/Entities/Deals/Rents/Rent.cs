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

    public override void Update(Deal entity)
    {
        if (entity is not Rent rent) return;
        Price = entity.Price;
        Conditions!.Update(rent.Conditions!);
    }
}