namespace DomovoiBackend.Domain.Entities.Deals.Rents;

/// <summary>
/// Правила аренды.
/// </summary>
public class RentRules
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Удобства.
    /// </summary>
    public string? Facilities { get; set; }
    
    /// <summary>
    /// С детьми.
    /// </summary>
    public bool WithKids { get; set; }
    
    /// <summary>
    /// С животными.
    /// </summary>
    public bool WithAnimals { get; set; }
    
    /// <summary>
    /// Можно курить.
    /// </summary>
    public bool CanSmoke { get; set; }
}