using System.ComponentModel.DataAnnotations;
using DomovoiBackend.Domain.Abstraction;

namespace DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;

public class Building : UpdatableEntity<Building>
{
    [Key]
    public Guid Id { get; set; }
    public string? Class { get; set; }
    public int BuildingYear { get; set; }
    public string? CenterName { get; set; }
    public bool HaveParking { get; set; }
    public bool IsEquipment { get; set; }
    public override void Update(Building entity)
    {
        Class = entity.Class;
        BuildingYear = entity.BuildingYear;
        CenterName = entity.CenterName;
        HaveParking = entity.HaveParking;
        IsEquipment = entity.IsEquipment;
    }
}