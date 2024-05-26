using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;

public class Warehouse : CommercialBuilding
{
    public bool Infrastructure { get; set; }
    public override void Update(Reality entity)
    {
        throw new NotImplementedException();
    }
}