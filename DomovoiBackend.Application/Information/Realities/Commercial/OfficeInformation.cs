using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

namespace DomovoiBackend.Application.Information.Realities.Commercial;

/// <summary>
/// Информация об офисе для запроса/ответа.
/// </summary>
public class OfficeInformation : CommercialRealityInformation, IMapTo<OfficeBuildingInfo>, IMapFrom<Office>
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Количество комнат.
    /// </summary>
    public int RoomsCount { get; set; }
}