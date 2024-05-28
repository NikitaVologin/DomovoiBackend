using DomovoiBackend.Application.Information.Other;
using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;

namespace DomovoiBackend.Application.Information.Realities.Living;

public class FlatInformation : LivingBuildingInformation, IMapTwoSide<Flat>
{
    /// <summary>
    /// "Свежая" (TODO: что это)
    /// </summary>
    public bool IsFresh { get; set; }
    
    /// <summary>
    /// Количество комнат.
    /// </summary>
    public int RoomsCount { get; set; }
    
    /// <summary>
    /// Отремонтирована.
    /// </summary>
    public bool IsRepaired { get; set; }
    
    /// <summary>
    /// Площадь кухни.
    /// </summary>
    public double KitchenArea { get; set; }
    
    /// <summary>
    /// Тип балкона.
    /// </summary>
    public string? BalconyType { get; set; }
    
    /// <summary>
    /// Вид из балкона.
    /// </summary>
    public string? ViewFromBalcony { get; set; }
    
    /// <summary>
    /// Дома (В котором живёт Джек)
    /// </summary>
    public ApartmentHouseInformation? Building { get; set; }
}