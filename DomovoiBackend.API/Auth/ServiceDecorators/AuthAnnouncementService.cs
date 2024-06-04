using DomovoiBackend.Application.Information.Announcements;
using DomovoiBackend.Application.Parameters;
using DomovoiBackend.Application.Requests.Announcements;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;

namespace DomovoiBackend.API.Auth.ServiceDecorators;

public class AuthAnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementService _service;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthAnnouncementService(IAnnouncementService service, IHttpContextAccessor httpContextAccessor) =>
        (_service, _httpContextAccessor) = (service, httpContextAccessor);
    
    public async Task<Guid> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken cancellationToken)
    {
        var context = _httpContextAccessor.HttpContext ?? throw new NullReferenceException();
        
        if(!context.Request.Cookies.TryGetValue("CounterAgentId",
               out var cookieCounterAgentId) ||
           Guid.Parse(cookieCounterAgentId) != request.CounterAgentId) throw new ArgumentException("ID пользователя не равен ID в COOKIE");
        
        return await _service.AddAnnouncementAsync(request, cancellationToken);
    }

    public async Task<AnnouncementInformation> GetAnnouncementAsync(Guid id, CancellationToken cancellationToken) => await
        _service.GetAnnouncementAsync(id, cancellationToken);


    public async Task<AnnouncementInformationCollection> GetAnnouncementsAsync(int count,
        CancellationToken cancellationToken) => await
        _service.GetAnnouncementsAsync(count, cancellationToken);

    public async Task<AnnouncementInformationCollection> GetAnnouncementsAsync(CancellationToken cancellationToken) => await
        _service.GetAnnouncementsAsync(cancellationToken);

    public async Task<AnnouncementInformationCollection> GetLimitedAnnouncementsAsync(int toIndex,
        CancellationToken cancellationToken) => await
        _service.GetLimitedAnnouncementsAsync(toIndex, cancellationToken);

    public async Task<AnnouncementInformationCollection> GetLimitedAnnouncementsAsync(int fromIndex, int toIndex,
        CancellationToken cancellationToken) => await
        _service.GetLimitedAnnouncementsAsync(fromIndex, toIndex, cancellationToken);

    public async Task UpdateAnnouncementAsync(Guid id, UpdateAnnouncementRequest request, CancellationToken cancellationToken)
    {
        var context = _httpContextAccessor.HttpContext ?? throw new NullReferenceException();
        
        if(!context.Request.Cookies.TryGetValue("CounterAgentId",
               out var cookieCounterAgentId) ||
           Guid.Parse(cookieCounterAgentId) != id) throw new ArgumentException("ID пользователя не равен ID в COOKIE");
        
        await _service.UpdateAnnouncementAsync(id, request, cancellationToken);
    }

    public async Task RemoveAnnouncementAsync(Guid announcementId, Guid counterAgentId, CancellationToken cancellationToken)
    {
        var context = _httpContextAccessor.HttpContext ?? throw new NullReferenceException();
        
        if(!context.Request.Cookies.TryGetValue("CounterAgentId",
               out var cookieCounterAgentId) ||
           Guid.Parse(cookieCounterAgentId) != counterAgentId) throw new ArgumentException("ID пользователя не равен ID в COOKIE");

        await _service.RemoveAnnouncementAsync(announcementId, counterAgentId, cancellationToken);
    }

    public async Task<AnnouncementInformationCollection> GetFilteredAnnouncementsAsync(
        FilterParameters filterParameters, CancellationToken cancellationToken) => await
        _service.GetFilteredAnnouncementsAsync(filterParameters, cancellationToken);

    public async Task<AnnouncementInformationCollection> GetAnnouncementByUserIdAsync(Guid userId,
        CancellationToken cancellationToken) => await
        _service.GetAnnouncementByUserIdAsync(userId, cancellationToken);
}