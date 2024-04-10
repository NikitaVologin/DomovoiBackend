using DomovoiBackend.Application.Models.Announcements;
using DomovoiBackend.Domain.Entities.Announcements;

namespace DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;

public interface IAnnouncementService
{
    Task<Announcement> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken cancellationToken);
    Task<Announcement> GetAnnouncementAsync(Guid id, CancellationToken cancellationToken);

}