using DomovoiBackend.Application.Models.Announcements;
using DomovoiBackend.Application.Persistence;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.Interfaces;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;
using DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices.Interfaces;
using DomovoiBackend.Domain.Entities.Announcements;

namespace DomovoiBackend.Application.Services.AnnouncementServices;

public class AnnouncementService : IAnnouncementService
{
    private readonly IRealityCreationService _realityCreationService;
    private readonly IDealCreationService _dealCreationService;
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly ICounterAgentRepository _counterAgentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AnnouncementService(
        IRealityCreationService realityCreationService,
        IDealCreationService dealCreationService,
        IAnnouncementRepository announcementRepository,
        ICounterAgentRepository counterAgentRepository,
        IUnitOfWork unitOfWork)
    {
        _realityCreationService = realityCreationService;
        _dealCreationService = dealCreationService;
        _announcementRepository = announcementRepository;
        _counterAgentRepository = counterAgentRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Announcement> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken cancellationToken)
    {
        var announcementGuid = Guid.NewGuid();
        var realityInfo = request.RealityInfo;
        var dealInfo = request.DealInfo;
        var reality = _realityCreationService.CreateReality(realityInfo, announcementGuid);
        var deal = _dealCreationService.CreateDeal(dealInfo, announcementGuid);
        var counterAgent = await _counterAgentRepository.GetAsync(request.CounterAgentId, cancellationToken);
        
        var announcement = new Announcement
        {
            Id = announcementGuid,
            Description = request.Description,
            ConnectionType = request.ConnectionType,
            Reality = reality,
            Deal = deal,
            CounterAgent = counterAgent
        };
        
        var guid = await _announcementRepository.AddAnnouncementAsync(announcement, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return announcement;
    }
}