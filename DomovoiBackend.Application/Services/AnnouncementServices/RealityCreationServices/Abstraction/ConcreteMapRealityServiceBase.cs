using AutoMapper;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities;
using DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices.Interfaces;
using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;

namespace DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices.Abstraction;

public abstract class ConcreteMapRealityServiceBase<TRequestInfo, TRealityInfo> : IConcreteMapRealityService
    where TRequestInfo : RealityRequestInfo
    where TRealityInfo : BaseRealityInfo
{
    private readonly IMapper _mapper;

    protected ConcreteMapRealityServiceBase(IMapper mapper) => _mapper = mapper;

    Type IConcreteMapRealityService.RealityInfoType => typeof(TRequestInfo);

    private TRealityInfo MapReality(TRequestInfo info) =>
        _mapper.Map<TRealityInfo>(info);

    BaseRealityInfo IConcreteMapRealityService.MapReality(RealityRequestInfo info)
    {
        if (info is TRequestInfo requestInfo)
        {
            return MapReality(requestInfo);
        }

        throw new ArgumentException();
    }
}