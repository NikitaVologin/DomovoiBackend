using DomovoiBackend.Domain.Interfaces;

namespace DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;

public class Office : CommercialBuilding, IFloorCountable
{
    public string? Name { get; set; }
    public int RoomsCount { get; set; } 
    
    public int Floor { get; set; }
    
    public override void Update(Reality entity)
    {
        if(entity is not Office office) return;
        Access = office.Access;
        Address = office.Address;
        Area = office.Area;
        Building!.Update(office.Building!);
        Entry = office.Entry;
        FloorsCount = office.FloorsCount;
        IsUse = office.IsUse;
        Name = office.Name;
        RoomsCount = office.RoomsCount;
    }
}