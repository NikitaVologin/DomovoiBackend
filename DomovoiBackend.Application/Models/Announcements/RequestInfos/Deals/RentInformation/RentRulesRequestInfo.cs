using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.RentInformation;

public class RentRulesRequestInfo : IMapTo<RentRulesInfo>
{
    public string? Facilities { get; set; }
    public bool WithKids { get; set; }
    public bool WithAnimals { get; set; }
    public bool CanSmoke { get; set; }
}