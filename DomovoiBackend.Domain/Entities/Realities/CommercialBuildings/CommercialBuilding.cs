namespace DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;

public class CommercialBuilding : Reality
{    
    public int FloorsCount { get; set; }
    public bool Entry { get; set; }
    public string? Address { get; set; }
    public bool IsUse { get; set; }
    public bool IsAccess { get; set; }
    public virtual Building? Building { get; set; }
}