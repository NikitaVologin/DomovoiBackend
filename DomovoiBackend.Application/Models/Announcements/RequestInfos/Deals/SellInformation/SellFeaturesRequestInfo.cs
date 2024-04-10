using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.SellInformation;

public class SellFeaturesRequestInfo : IMapTo<SellFeaturesInfo>
{
    public int YearInOwn { get; set; }
    public int OwnersCount { get; set; }
    public int PrescribersCount { get; set; }
    public bool HaveChildOwners { get; set; }
    public bool HaveChildPrescribers { get; set; }
}