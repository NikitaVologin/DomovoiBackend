using System.ComponentModel.DataAnnotations.Schema;
using DomovoiBackend.Domain.Entities.Common;

namespace DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;

public class Flat : LivingBuilding
{
    public bool IsFresh { get; set; }
    public int RoomsCount { get; set; }
    public bool IsRepaired { get; set; }
    public double KitchenArea { get; set; }
    public string? BalconyType { get; set; }
    public string? ViewFromBalcony { get; set; }
    public virtual ApartmentHouse? ApartmentHouse { get; set; }
}