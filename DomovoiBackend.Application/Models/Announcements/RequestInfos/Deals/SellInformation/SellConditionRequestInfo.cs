using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.SellInformation;

public class SellConditionRequestInfo : IMapTo<SellConditionInfo>
{
    public double Price { get; set; }
    public string Type { get; set; } = null!;
}