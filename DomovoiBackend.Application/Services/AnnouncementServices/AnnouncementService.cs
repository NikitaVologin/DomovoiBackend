using DomovoiBackend.Application.Information.Announcements;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Application.Requests.Announcements;
using DomovoiBackend.Application.Services.AnnouncementServices.CreationServices.Interfaces;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices;
using DomovoiBackend.Domain.Entities.Announcements;

namespace DomovoiBackend.Application.Services.AnnouncementServices;

public class AnnouncementService : IAnnouncementService
{

    private readonly IDealCreationService _dealCreationService;
    private readonly IRealityCreationService _realityCreationService;
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly ICounterAgentRepository _counterAgentRepository;
    private readonly CounterAgentCreationService _counterAgentCreationService;

    public AnnouncementService(IDealCreationService dealCreationService, IRealityCreationService realityCreationService,
        IAnnouncementRepository announcementRepository, ICounterAgentRepository counterAgentRepository, CounterAgentCreationService counterAgentCreationService)
    {
        _dealCreationService = dealCreationService;
        _realityCreationService = realityCreationService;
        _announcementRepository = announcementRepository;
        _counterAgentRepository = counterAgentRepository;
        _counterAgentCreationService = counterAgentCreationService;
    }

    public async Task<Guid> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken cancellationToken)
    {
        var announcementGuid = Guid.NewGuid();
        var realityInfo = request.RealityInfo;
        var dealInfo = request.DealInfo;
        var deal = _dealCreationService.CreateDealFromRequest(dealInfo, announcementGuid);
        var reality = _realityCreationService.CreateRealityFromRequest(realityInfo, announcementGuid);
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
            Description = announcement.Description,
            ConnectionType = announcement.ConnectionType,
            CounterAgentInfo = _counterAgentCreationService.CreateInfoFromEntity(announcement.CounterAgent),
            DealInfo = _dealCreationService.CreateInfoFromEntity(announcement.Deal),
            RealityInfo = _realityCreationService.CreateInfoFromEntity(announcement.Reality)
        };
    }
}