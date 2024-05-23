using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Sells;

namespace DomovoiBackend.Application.Information.Deals.Sells;

/// <summary>
/// Информация о условиях продажи для запроса/ответа.
/// </summary>
public class SellConditionInformation : IMapTwoSide<SellConditions>
{
    /// <summary>
    /// Тип сделки.
    /// </summary>
    public string Type { get; set; } = null!;
    
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
    /// Есть ли дети владельцы.
    /// </summary>
    public bool HaveChildOwners { get; set; }
    
    /// <summary>
    /// Есть ли дети подписаны.
    /// </summary>
    public bool HaveChildPrescribers { get; set; }
}