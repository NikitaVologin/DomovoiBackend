using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities.CommercialRealities.Common;

public class BuildingRequestInfo : IMapTo<Building>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Class { get; set; }
    public int BuildingYear { get; set; }
    public string? CenterName { get; set; }
    public bool HaveParking { get; set; }
    public bool IsEquipment { get; set; }   
}