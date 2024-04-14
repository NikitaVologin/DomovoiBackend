using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;

namespace DomovoiBackend.Application.Information.Realities.Commercial;

/// <summary>
/// Информация о производстве для запросов/ответов.
/// </summary>
public class ProductionInformation : CommercialRealityInformation, IMapTo<ProductionBuildingInfo>
{
    /// <summary>
    /// Инфрастурктура
    /// </summary>
    public List<string> Infrastructure { get; set; } = new();
    
    /// <summary>
    /// Количество комнат.
    /// </summary>
    public int RoomsQuantity { get; set; }
}