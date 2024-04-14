using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;

namespace DomovoiBackend.Application.Information.Other;


/// <summary>
/// Информация о здании (для запросов/ответов)
/// </summary>
public class BuildingInformation : IMapTo<Building>, IMapFrom<Building>
{
    /// <summary>
    /// Id строения.
    /// </summary>
    public Guid Id => Guid.NewGuid();
    
    /// <summary>
    /// Класс строения.
    /// </summary>
    public string? Class { get; set; }
    
    /// <summary>
    /// Год постройки.
    /// </summary>
    public int BuildingYear { get; set; }
    
    public string? CenterName { get; set; }
    
    /// <summary>
    /// Есть ли парковка.
    /// </summary>
    public bool HaveParking { get; set; }
    
    /// <summary>
    /// Отремонтирован.
    /// </summary>
    public bool IsEquipment { get; set; }   
}