using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.LivingBuildings;

public class LivingBuilding : Reality
{
    public int Floor {get; set;}
    public override void Update(Reality entity)
    {
        throw new NotImplementedException();
    }
}