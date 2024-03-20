using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;

public class HousePart : LivingBuilding
{
    public int Part { get; set; }
    public virtual House? House { get; set; }
}