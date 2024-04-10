using AutoMapper;
using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.SellInformation;

public class SellRequestInfo : DealRequestInfo, IMapTo<SellInfo>
{
    public SellConditionRequestInfo SellConditionInfo { get; set; } = null!;
    public SellFeaturesRequestInfo SellFeaturesInfo { get; set; } = null!;

    public void Mapping(Profile profile) =>
        profile.CreateMap<SellRequestInfo, SellInfo>();
}