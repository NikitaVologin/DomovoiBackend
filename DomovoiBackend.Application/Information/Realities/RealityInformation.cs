namespace DomovoiBackend.Application.Information.Realities;

/// <summary>
/// Информация о недвижимости.
/// </summary>
public class RealityInformation
{
    /// <summary>
    /// Площадь.
    /// </summary>
    public double Area { get; set; }
    
    /// <summary>
    /// Адрес.
    /// </summary>
    public string? Address { get; set; }
}