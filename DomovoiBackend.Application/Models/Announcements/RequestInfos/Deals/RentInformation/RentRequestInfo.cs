using AutoMapper;
using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.RentInformation;

public class RentRequestInfo : DealRequestInfo, IMapTo<RentInfo>
{
    public RentConditionInfo RentConditionInfo { get; set; }
    public RentRulesRequestInfo RentRulesInfo { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<RentRequestInfo, RentInfo>();
}