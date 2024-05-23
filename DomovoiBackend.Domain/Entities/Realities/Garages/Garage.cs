using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Realities.Garages;

public class Garage : Reality
{
    public string? State {get; set;}
    public string? GKSName {get; set;}
    public bool Access {get; set;}
    public bool Security {get; set;}
    public bool Electricity {get; set;}
    public bool Heating {get; set;}
    public bool WaterSupply {get; set;}
    public bool Infrastructure {get; set;}
    public override void Update(Reality entity)
    {
        throw new NotImplementedException();
    }
}