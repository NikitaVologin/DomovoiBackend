using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;

public class Room : LivingBuilding
{
    public int NeighboursCount { get; set; }
    public virtual Flat? Flat { get; set; }
}