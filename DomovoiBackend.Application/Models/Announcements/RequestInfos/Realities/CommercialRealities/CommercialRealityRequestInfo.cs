using AutoMapper;
using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities.CommercialRealities.Common;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities.CommercialRealities;

public class CommercialRealityRequestInfo : RealityRequestInfo
{
    public int FloorsCount { get; set; }
    public bool Entry { get; set; }
    public string? Address { get; set; }
    public bool IsUse { get; set; }
    public bool IsAccess { get; set; }
    public virtual BuildingRequestInfo? Building { get; set; }
}