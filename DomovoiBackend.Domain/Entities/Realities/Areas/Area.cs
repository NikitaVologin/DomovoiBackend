using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.Areas;

public class Area : Reality
{
    public bool Electricity {get; set;}
    public bool WaterSupply {get; set;}
    public bool Gas {get; set;}
    public bool Sewage {get; set;}
    public override void Update(Reality entity)
    {
        throw new NotImplementedException();
    }
}