using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;

public class Building
{
    [Key]
    public Guid Id { get; set; }
    public string? Class { get; set; }
    public int BuildingYear { get; set; }
    public string? CenterName { get; set; }
    public bool HaveParking { get; set; }
    public bool IsEquipment { get; set; }
}