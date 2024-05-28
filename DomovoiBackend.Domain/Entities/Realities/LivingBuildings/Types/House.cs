using System.ComponentModel.DataAnnotations.Schema;
using DomovoiBackend.Domain.Entities.Realities.Areas;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.ValueTypes;

namespace DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;

public class House : LivingBuilding
{
    public int BuildYear { get; set; }
    public int RoomsCount { get; set; }
    public bool IsRenovated { get; set; }
    public bool IsHeating { get; set; }
    public bool IsAccess { get; set; }
    public bool IsInfrastructure { get; set; }
    public bool IsLandscaping { get; set; }
    public virtual Bathroom? Bathroom { get; set; }
    public virtual Area? HouseArea { get; set; }
    public override void Update(Reality entity)
    {
        throw new NotImplementedException();
    }
}