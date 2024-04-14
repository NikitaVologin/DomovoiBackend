using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Rents;

namespace DomovoiBackend.Application.Information.Deals.Rents;

/// <summary>
/// Информация о правилах аренды для запроса/ответа.
/// </summary>
public class RentRulesInformation : IMapTwoSide<RentRules>
{
    /// <summary>
    /// Удобства.
    /// </summary>
    public string? Facilities { get; set; }
    
    /// <summary>
    /// Разрешено с детьми.
    /// </summary>
    public bool WithKids { get; set; }
    
    /// <summary>
    /// Разрешено с животными.
    /// </summary>
    public bool WithAnimals { get; set; }
    
    /// <summary>
    /// Разрешено курить.
    /// </summary>
    public bool CanSmoke { get; set; }
}