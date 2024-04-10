using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.RentInformation;

public class RentConditionRequestInfo : IMapTo<RentConditionInfo>
{
    public double Price { get; set; }
    public string? Period { get; set; }
    public double Deposit { get; set; }
    public double CommunalPays { get; set; }
    public double Prepay { get; set; }
}