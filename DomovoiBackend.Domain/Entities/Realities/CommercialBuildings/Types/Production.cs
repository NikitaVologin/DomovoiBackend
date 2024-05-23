using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;

public class Production : CommercialBuilding
{
    public bool Infrastructure { get; set; }
    public int RoomsQuantity { get; set; }
    public override void Update(Reality entity)
    {
        throw new NotImplementedException();
    }
}