using DomovoiBackend.Domain.Abstraction;

namespace DomovoiBackend.Domain.Entities.Deals.Sells;

/// <summary>
/// Условия продажи.
/// </summary>
public class SellConditions : UpdatableEntity<SellConditions>
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Тип.
    /// </summary>
    public string? Type { get; set; }
    
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

    public override void Update(SellConditions entity)
    {
        Type = entity.Type;
        YearInOwn = entity.YearInOwn;
        OwnersCount = entity.OwnersCount;
        PrescribersCount = entity.PrescribersCount;
        HaveChildOwners = entity.HaveChildOwners;
        HaveChildPrescribers = entity.HaveChildPrescribers;
    }
}