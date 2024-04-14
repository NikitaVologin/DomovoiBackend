using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

namespace DomovoiBackend.Application.Information.Deals.Rents;

/// <summary>
/// Информация о правилах аренды для запроса/ответа.
/// </summary>
public class RentRulesInformation : IMapTo<RentRulesInfo>, IMapFrom<RentRules>
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