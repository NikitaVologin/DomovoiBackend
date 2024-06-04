using DomovoiBackend.Application.Information.Announcements;
using DomovoiBackend.Application.Parameters;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Application.Requests.Announcements;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;
using DomovoiBackend.Application.Services.MappingServices.Interfaces;
using DomovoiBackend.Domain.Entities.Announcements;

namespace DomovoiBackend.Application.Services.AnnouncementServices;

/// <summary>
/// Сервис объявлений.
/// </summary>
public class AnnouncementService : IAnnouncementService
{
    /// <summary>
    /// Сервис отображений сделок.
    /// </summary>
    private readonly IDealMappingService _dealMappingService;
    
    /// <summary>
    /// Сервис отображений недвижимости.
    /// </summary>
    private readonly IRealityMappingService _realityMappingService;
    
    /// <summary>
    /// Репозиторий объявлений
    /// </summary>
    private readonly IAnnouncementRepository _announcementRepository;
    
    /// <summary>
    /// Репозиторий контр-агентов.
    /// </summary>
    private readonly ICounterAgentRepository _counterAgentRepository;
    
    /// <summary>
    /// Сервис отображений контр-агентов.
    /// </summary>
    private readonly ICounterAgentMappingService _counterAgentMappingService;
    
    public AnnouncementService(IDealMappingService dealMappingService, IRealityMappingService realityMappingService,
        IAnnouncementRepository announcementRepository, ICounterAgentRepository counterAgentRepository, ICounterAgentMappingService counterAgentMappingService)
    {
        _dealMappingService = dealMappingService;
        _realityMappingService = realityMappingService;
        _announcementRepository = announcementRepository;
        _counterAgentRepository = counterAgentRepository;
        _counterAgentMappingService = counterAgentMappingService;
    }

    public async Task<Guid> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken cancellationToken)
    {
        var announcementGuid = Guid.NewGuid();
        var realityInfo = request.RealityInfo;
        var dealInfo = request.DealInfo;
        var deal = _dealMappingService.MapEntityFromInformation(dealInfo);
        var reality = _realityMappingService.MapEntityFromInformation(realityInfo);
        var counterAgent = await _counterAgentRepository.GetAsync(request.CounterAgentId, cancellationToken);
        
        var announcement = new Announcement
        {
            Id = announcementGuid,
            Description = request.Description,
            ConnectionType = request.ConnectionType,
            Deal = deal,
            Reality = reality,
            CounterAgent = counterAgent
        };

        await _announcementRepository.AddAnnouncementAsync(announcement, cancellationToken);
        
        return announcementGuid;
    }

    public async Task<AnnouncementInformation> GetAnnouncementAsync(Guid id, CancellationToken cancellationToken)
    {
        var announcement =  await _announcementRepository.GetAnnouncementAsync(id, cancellationToken);
        return new AnnouncementInformation
        {
            Id = announcement.Id,
            Description = announcement.Description!,
            ConnectionType = announcement.ConnectionType!,
            CounterAgentInfo = _counterAgentMappingService.MapInformationFromEntity(announcement.CounterAgent!),
            DealInfo = _dealMappingService.MapInformationFromEntity(announcement.Deal!),
            RealityInfo = _realityMappingService.MapInformationFromEntity(announcement.Reality!)
        };
    }

    public async Task<AnnouncementInformationCollection> GetAnnouncementsAsync(int count, CancellationToken cancellationToken)
    {
        var announcements = await 
            _announcementRepository.GetAnnouncementsAsync(count, cancellationToken);

        var announcementInfos = announcements.Select(TransformToInformation).ToList();

        return new AnnouncementInformationCollection { AnnouncementInformation = announcementInfos };
    }

    public async Task<AnnouncementInformationCollection> GetAnnouncementsAsync(CancellationToken cancellationToken)
    {
        var announcements = await 
            _announcementRepository.GetAnnouncementsAsync(cancellationToken);

        var announcementInfos = announcements.Select(TransformToInformation).ToList();

        return new AnnouncementInformationCollection { AnnouncementInformation = announcementInfos };
    }

    public async Task<AnnouncementInformationCollection> GetLimitedAnnouncementsAsync(int toIndex, CancellationToken cancellationToken)
    {
        var announcements = await 
            _announcementRepository.GetLimitedAnnouncementsAsync(toIndex, cancellationToken);

        var announcementInfos = announcements.Select(TransformToInformation).ToList();

        return new AnnouncementInformationCollection { AnnouncementInformation = announcementInfos };
    }

    public async Task<AnnouncementInformationCollection> GetLimitedAnnouncementsAsync(int fromIndex, int toIndex, CancellationToken cancellationToken)
    {
        var announcements = await 
            _announcementRepository.GetLimitedAnnouncementsAsync(fromIndex, toIndex, cancellationToken);

        var announcementInfos = announcements.Select(TransformToInformation).ToList();

        return new AnnouncementInformationCollection { AnnouncementInformation = announcementInfos };
    }

    public async Task UpdateAnnouncementAsync(Guid announcementId, UpdateAnnouncementRequest request, CancellationToken cancellationToken)
    {
        var realityInfo = request.RealityInfo;
        var dealInfo = request.DealInfo;
        var deal = _dealMappingService.MapEntityFromInformation(dealInfo);
        var reality = _realityMappingService.MapEntityFromInformation(realityInfo);
        var counterAgent = await _counterAgentRepository.GetAsync(request.CounterAgentId, cancellationToken);

        var announcement = new Announcement
        {
            Id = announcementId,
            Description = request.Description,
            ConnectionType = request.ConnectionType,
            Deal = deal,
            Reality = reality,
            CounterAgent = counterAgent
        };

        await _announcementRepository.UpdateAnnouncementAsync(announcementId, announcement, cancellationToken);
    }

    public async Task RemoveAnnouncementAsync(Guid announcementId, Guid counterAgentId, CancellationToken cancellationToken) =>
        await _announcementRepository.RemoveAnnouncementAsync(counterAgentId, announcementId, cancellationToken);

    public async Task<AnnouncementInformationCollection> GetFilteredAnnouncementsAsync(FilterParameters filterParameters, CancellationToken cancellationToken)
    {
        var announcements = await 
            _announcementRepository.GetAnnouncementsByParametersAsync(filterParameters, cancellationToken);

        var announcementInfos = announcements.Select(TransformToInformation).ToList();

        return new AnnouncementInformationCollection { AnnouncementInformation = announcementInfos };
    }

    public async Task<AnnouncementInformationCollection> GetAnnouncementByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var announcements = await
            _announcementRepository.GetAnnouncementsByUserIdAsync(userId, cancellationToken);

        var announcementInfos = announcements.Select(TransformToInformation).ToList();

        return new AnnouncementInformationCollection() { AnnouncementInformation = announcementInfos };
    }

    private AnnouncementInformation TransformToInformation(Announcement announcement) => new()
    {
        Id = announcement.Id,
        Description = announcement.Description!,
        ConnectionType = announcement.ConnectionType!,
        CounterAgentInfo = _counterAgentMappingService.MapInformationFromEntity(announcement.CounterAgent!),
        DealInfo = _dealMappingService.MapInformationFromEntity(announcement.Deal!),
        RealityInfo = _realityMappingService.MapInformationFromEntity(announcement.Reality!)
    };
}