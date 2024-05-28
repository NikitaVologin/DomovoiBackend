using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Common;

namespace DomovoiBackend.Application.Information.Other;

public class ApartmentHouseInformation : IMapTwoSide<ApartmentHouse>
{
    /// <summary>
    /// Год постройки.
    /// </summary>
    public int BuildingYear { get; set; }
    
    /// <summary>
    /// Тип дома.
    /// </summary>
    public string? Type { get; set; }
    
    /// <summary>
    /// Высота крыши.
    /// </summary>
    public double CeilingHeight { get; set; }
    
    /// <summary>
    /// Есть газ.
    /// </summary>
    public bool IsGas { get; set; }
    
    /// <summary>
    /// Есть мусоропровод.
    /// </summary>
    public bool HaveGarbageChute { get; set; }
    
    /// <summary>
    /// Безопасен.
    /// </summary>
    public bool IsSecurity { get; set; }
    
    /// <summary>
    /// Есть парковка.
    /// </summary>
    public bool HaveParking { get; set; }
    
    /// <summary>
    /// Инфраструктура.
    /// </summary>
    public List<string> Infrastructures { get; set; } = [];

    /// <summary>
    /// Благоустройства.
    /// </summary>
    public List<string> Landscaping { get; set; } = [];
}