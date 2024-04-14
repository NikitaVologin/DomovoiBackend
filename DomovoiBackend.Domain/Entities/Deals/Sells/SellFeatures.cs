namespace DomovoiBackend.Domain.Entities.Deals.Sells;

/// <summary>
/// Характеристики продажи.
/// </summary>
public class SellFeatures
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Лет во владении.
    /// </summary>
    public int YearInOwn { get; set; }
    
    /// <summary>
    /// Количество владельцев.
    /// </summary>
    public int OwnersCount { get; set; }
    
    /// <summary>
    /// Количество прописантов.
    /// </summary>
    public int PrescribersCount { get; set; }
    
    /// <summary>
    /// Есть дети владельцы.
    /// </summary>
    public bool HaveChildOwners { get; set; }
    
    /// <summary>
    /// Есть дети подписаны.
    /// </summary>
    public bool HaveChildPrescribers { get; set; }
}