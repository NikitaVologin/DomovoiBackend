using DomovoiBackend.Application.Information.Announcements;
using DomovoiBackend.Application.Parameters;
using DomovoiBackend.Application.Requests.Announcements;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;

namespace DomovoiBackend.API.Logging.ServiceDecorators;

public class LoggerAnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementService _service;
    private readonly ILogger<IAnnouncementService> _logger;

    public LoggerAnnouncementService(IAnnouncementService service, ILogger<IAnnouncementService> logger) =>
        (_service, _logger) = (service, logger);
    
    public async Task<Guid> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var guid = await _service.AddAnnouncementAsync(request, cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@request} добавлен", request);
            return guid;
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task<AnnouncementInformation> GetAnnouncementAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var information = await _service.GetAnnouncementAsync(id, cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@information} получен", information);
            return information;
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task<AnnouncementInformationCollection> GetAnnouncementsAsync(int count, CancellationToken cancellationToken)
    {
        try
        {
            var collection = await _service.GetAnnouncementsAsync(count, cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@collection} получены", collection);
            return collection;
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task<AnnouncementInformationCollection> GetAnnouncementsAsync(CancellationToken cancellationToken)
    {
        try
        {
            var collection = await _service.GetAnnouncementsAsync(cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@collection} получены", collection);
            return collection;
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task<AnnouncementInformationCollection> GetLimitedAnnouncementsAsync(int toIndex, CancellationToken cancellationToken)
    {
        try
        {
            var collection = await _service.GetLimitedAnnouncementsAsync(toIndex, cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@collection} получены до индекса {@toIndex}", collection, toIndex);
            return collection;
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task<AnnouncementInformationCollection> GetLimitedAnnouncementsAsync(int fromIndex, int toIndex, CancellationToken cancellationToken)
    {
        try
        {
            var collection = await _service.GetLimitedAnnouncementsAsync(fromIndex, toIndex, cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@collection} получены от {@fromIndex} до индекса {@toIndex}", collection, fromIndex, toIndex);
            return collection;
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task UpdateAnnouncementAsync(Guid id, UpdateAnnouncementRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _service.UpdateAnnouncementAsync(id, request, cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@id} обновлён", id);
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task RemoveAnnouncementAsync(Guid announcementId, Guid counterAgentId, CancellationToken cancellationToken)
    {
        try
        {
            await _service.RemoveAnnouncementAsync(announcementId, counterAgentId, cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@id} удалён", announcementId);
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task<AnnouncementInformationCollection> GetFilteredAnnouncementsAsync(FilterParameters filterParameters, CancellationToken cancellationToken)
    {
        try
        {
            var collection = await _service.GetFilteredAnnouncementsAsync(filterParameters, cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@collection} получены с фильтром {@filter}", collection, filterParameters);
            return collection;
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task<AnnouncementInformationCollection> GetAnnouncementByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            var collection = await _service.GetAnnouncementByUserIdAsync(userId, cancellationToken);
            _logger.LogInformation("[ANNOUNCEMENT_SERVICE] {@collection} получены для {@userId}", collection, userId);
            return collection;
        }
        catch (Exception exception)
        {
            _logger.LogError("[ANNOUNCEMENT_SERVICE] {@error}", exception);
            throw;
        }
    }
}