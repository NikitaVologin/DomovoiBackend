using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

namespace DomovoiBackend.Application.Information.Realities.Commercial;

/// <summary>
/// Информация о складе для запроса/ответа.
/// </summary>
public class WarehouseInformation : CommercialRealityInformation, IMapTo<WarehouseBuildingInfo>
{
    /// <summary>
    /// Инфраструктура.
    /// </summary>
    public List<string> Infrastructure { get; set; } = new();
}