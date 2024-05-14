using DomovoiBackend.Application.Information.Other;

namespace DomovoiBackend.Application.Information.Realities;

/// <summary>
/// Информация о коммерческой недвижимости для запроса/ответа (базовая).
/// </summary>
public class CommercialRealityInformation : RealityInformation
{
    /// <summary>
    /// Количество этажей.
    /// </summary>
    public int FloorsCount { get; set; }

    /// <summary>
    /// Вход в здание.
    /// </summary>
    public string Entry { get; set; } = null!;
    
    /// <summary>
    /// В использовании.
    /// </summary>
    public bool IsUse { get; set; }

    /// <summary>
    /// Доступ (свободный/пропускной).
    /// </summary>
    public string Access { get; set; } = null!;
    
    public BuildingInformation? Building { get; set; }
}