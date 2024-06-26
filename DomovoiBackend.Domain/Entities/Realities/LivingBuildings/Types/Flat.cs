using DomovoiBackend.Domain.Entities.Common;
using DomovoiBackend.Domain.Interfaces;

namespace DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;

public class Flat : LivingBuilding, IFloorCountable
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
    public virtual ApartmentHouse? Building { get; set; }
    
    public override void Update(Reality entity)
    {
        if (entity is not Flat flat) return;
        Building = flat.Building;
        IsFresh = flat.IsFresh;
        RoomsCount = flat.RoomsCount;
        IsRepaired = flat.IsRepaired;
        KitchenArea = flat.KitchenArea;
        BalconyType = flat.BalconyType;
        ViewFromBalcony = flat.ViewFromBalcony;
        Floor = flat.Floor;
        FloorsCount = flat.FloorsCount;
        Area = flat.Area;
        Address = flat.Address;
        Type = flat.Type;
    }
}