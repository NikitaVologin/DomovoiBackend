namespace DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;

/// <summary>
/// Комерческая недвижимость.
/// </summary>
public class CommercialBuilding : Reality
{    
    /// <summary>
    /// Количество этажей.
    /// </summary>
    public int FloorsCount { get; set; }
    
    /// <summary>
    /// Вход (общий/отдельный).
    /// </summary>
    public string? Entry { get; set; }
    
    /// <summary>
    /// В использовании.
    /// </summary>
    public bool IsUse { get; set; }
    
    /// <summary>
    /// Доступ (по пропускам/свободный)
    /// </summary>
    public string? Access { get; set; }
    
    /// <summary>
    /// Строение.
    /// </summary>
    public virtual Building? Building { get; set; }
}