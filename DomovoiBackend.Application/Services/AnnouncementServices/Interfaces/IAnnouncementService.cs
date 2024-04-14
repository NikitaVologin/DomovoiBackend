using DomovoiBackend.Application.Information.Announcements;
using DomovoiBackend.Application.Requests.Announcements;

namespace DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;

public interface IAnnouncementService
{
    Task<Guid> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken cancellationToken);
    Task<AnnouncementInformation> GetAnnouncementAsync(Guid id, CancellationToken cancellationToken);
}