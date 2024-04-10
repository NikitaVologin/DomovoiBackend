using DomovoiBackend.Domain.Entities.Announcements;

namespace DomovoiBackend.Application.Persistence.Interfaces;

public interface IAnnouncementRepository
{
    Task<Guid> AddAnnouncementAsync(Announcement announcement, CancellationToken cancellationToken);
}