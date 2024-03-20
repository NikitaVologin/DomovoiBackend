using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;

public class Office : CommercialBuilding
{
    public string? Name { get; set; }
    public int RoomsCount { get; set; }
}