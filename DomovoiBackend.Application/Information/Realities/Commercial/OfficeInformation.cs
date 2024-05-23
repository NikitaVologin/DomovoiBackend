using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;

namespace DomovoiBackend.Application.Information.Realities.Commercial;

/// <summary>
/// Информация об офисе для запроса/ответа.
/// </summary>
public class OfficeInformation : CommercialRealityInformation, IMapTwoSide<Office>
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Количество комнат.
    /// </summary>
    public int RoomsCount { get; set; }
    
    /// <summary>
    /// ЭТАЖ. ВРЕМЕНО!!! СНЕСЁМ ВСЕ ОФИСЫ ПОТОМ В МИРЕ!
    /// </summary>
    public int Floor { get; set; }
}